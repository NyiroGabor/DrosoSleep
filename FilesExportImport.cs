using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Win32;
using System.Windows;
using Excel = Microsoft.Office.Interop.Excel;
using System.Threading;
using System.Diagnostics;

namespace DrosoSleep
{
    public class FilesExportImport
    {

        public static void WriteFile(string filename, string values)
        {
            File.WriteAllText(filename, values, Encoding.Default);
        }

        public static string[] LoadFile(string filename)
        {
            try
            {
                return File.ReadAllLines(filename, Encoding.Default);
            }
            catch (FileNotFoundException e)
            {
                return null;
            }
        }

        public static string WriteToExcel(List<ResultParameter> Results)
        {
            List<Task> taskList = new List<Task>(); //Lista a taskokhoz
            Excel.Application excelFile = new Excel.Application(); //Létrejön az Excel fájl
            Excel.Workbook workbook = excelFile.Workbooks.Add(); //Ebben vannak a worksheet-ek

            List<Excel.Worksheet> wsheets = new List<Excel.Worksheet>(); //Lista a worksheet-ekhez, azért kell, hogy mikor hozzáadom a worksheeteket a dokumentumhoz, akkor le is legyenek mentve, hogy később lehessen címezni és ezáltal szerkeszteni mindet
            for(int i = 0;i<Results.Count;i++) //Feltölti a worksheetek listáját elemekkel. Annyi worksheet lesz mindig, ahány paraméter
            {
                if (i == 0)
                {
                    wsheets.Add(workbook.ActiveSheet); //A legelső elemnél a már meglévő üres worksheet-et lehet felhasználni
                }
                else
                {
                    wsheets.Add(excelFile.Worksheets.Add()); //Nem az első elemnél mindig hozzáadja az újat és ezt az újat tárolja el a listában
                }
            }

            foreach (ResultParameter rp in Results) //Végigmegy a végeredmény paramétereken
            {
                
                taskList.Add(new Task(() => //Minden task megkap egy oldalt, amit fel kell tölteniük az adatokkal.
                {
                    //wsheets[Results.IndexOf(rp)] - Ez azt jelenti, hogy az az elem, amelyikkel éppen dolgozik a Results-ból, ugyan azt az elemet kell nézni a worksheetek között is. Mindig pontos megegyezés lesz a paraméterek és a worksheetek között, ezért ez mindig működik.
                    wsheets[Results.IndexOf(rp)].Name = rp.Name; //Mindig az aktuális paraméter lesz a worksheet neve
                    
                    int groupsAdditionalRows = 4; //Minden új csoporttal hozzá kell adni az előző csoportban lévő sorok számát, plusz 2-t, hogy a következő csoport annyival lejjebb legyen
                                                  // Az Excel 1,1-től indexel, viszont az első sor a paraméter neve és mértékegysége lesz. Ez azt jelenti hogy a harmadik sortól lesz releváns, mert kihagyunk egy plusz helyet. Egyszerűbb egyszer változó - 2-t írni.

                    if (rp.Groups[0].ResultsForFlies[0].Length == TimeValues.NumberOfDays) //Ha az eredmények száma annyi, mint a napok száma, akkor óra paramétereket kell kiírni épp.
                    {
                        wsheets[Results.IndexOf(rp)].Cells[groupsAdditionalRows - 3, "A"] = rp.Name + " " + rp.Unit; //A paraméter neve és mértékegysége az első sor
                        wsheets[Results.IndexOf(rp)].Cells[groupsAdditionalRows - 3, "A"].Font.Bold = true; //Vastag szöveg
                        wsheets[Results.IndexOf(rp)].Cells[groupsAdditionalRows - 2, "A"] = TimeValues.FirstDayDate; //A paraméter neve és mértékegysége az első sor
                        wsheets[Results.IndexOf(rp)].Cells[groupsAdditionalRows - 2, "A"].Font.Bold = true; //Vastag szöveg
                    }
                    else if (rp.Groups[0].ResultsForFlies[0].Length == TimeValues.NumberOfHours) //Ha az eredmények száma annyi, mint az órák száma, akkor óra paramétereket kell kiírni épp.
                    {
                        groupsAdditionalRows = 5;
                        wsheets[Results.IndexOf(rp)].Cells[groupsAdditionalRows - 4, "A"] = rp.Name + " " + rp.Unit; //A paraméter neve és mértékegysége az első sor
                        wsheets[Results.IndexOf(rp)].Cells[groupsAdditionalRows - 4, "A"].Font.Bold = true; //Vastag szöveg
                    }

                    for (int j = 0; j < rp.Groups.Count; j++) //A csoportokon megy végig, köztük annyi sort hagy, amennyi a NumberOfThisGroup + 2 hogy legyen köztük hézag
                    {
                        if (rp.Groups[j].ResultsForFlies[0].Length == TimeValues.NumberOfHours)
                        {
                            wsheets[Results.IndexOf(rp)].Cells[groupsAdditionalRows - 2, "A"] = "Hour - ";
                            wsheets[Results.IndexOf(rp)].Cells[groupsAdditionalRows - 2, "A"].Font.Bold = true; //Vastag szöveg
                            wsheets[Results.IndexOf(rp)].Cells[groupsAdditionalRows - 1, "A"] = "Time - ";
                            wsheets[Results.IndexOf(rp)].Cells[groupsAdditionalRows - 1, "A"].Font.Bold = true; //Vastag szöveg
                        }

                        wsheets[Results.IndexOf(rp)].Cells[groupsAdditionalRows, "A"] = "Group: " + rp.Groups[j].GetName(); //A csoport neve
                        wsheets[Results.IndexOf(rp)].Cells[groupsAdditionalRows, "A"].Font.Bold = true; //Vastag szöveg

                        if (rp.Groups[j].ResultsForFlies[0].Length == TimeValues.NumberOfDays)
                        {
                            for (int columnHeaders = 0; columnHeaders < rp.Groups[j].ResultsForFlies[0].Length; columnHeaders++)
                            { //Akár nap, vagy óra alapú a végeredmény, az oszlopokat annak megfelelően kiírja
                                wsheets[Results.IndexOf(rp)].Cells[groupsAdditionalRows, columnHeaders + 2] = "Day " + (columnHeaders + 1);
                                wsheets[Results.IndexOf(rp)].Cells[groupsAdditionalRows, columnHeaders + 2].Font.Bold = true;
                            } //A +2 az excelben való indexeléshez kell. Az első elem a csoport neve és 1-től indexel az Excel
                        }
                        else if (rp.Groups[j].ResultsForFlies[0].Length == TimeValues.NumberOfHours)
                        {
                            for (int columnHeaders = 0; columnHeaders < rp.Groups[j].ResultsForFlies[0].Length; columnHeaders++)
                            { //Akár nap, vagy óra alapú a végeredmény, az oszlopokat annak megfelelően kiírja
                                wsheets[Results.IndexOf(rp)].Cells[groupsAdditionalRows - 2, columnHeaders + 2] = (columnHeaders + 1).ToString();
                                wsheets[Results.IndexOf(rp)].Cells[groupsAdditionalRows - 2, columnHeaders + 2].Font.Bold = true;
                                wsheets[Results.IndexOf(rp)].Cells[groupsAdditionalRows - 1, columnHeaders + 2] = TimeValues.ExactHourValueForHours[columnHeaders] + ":00:00";
                                wsheets[Results.IndexOf(rp)].Cells[groupsAdditionalRows - 1, columnHeaders + 2].Font.Bold = true;
                                wsheets[Results.IndexOf(rp)].Cells[groupsAdditionalRows, columnHeaders + 2] = TimeValues.GetIndexOfDarkLightValuesForHours(columnHeaders);
                                wsheets[Results.IndexOf(rp)].Cells[groupsAdditionalRows, columnHeaders + 2].Font.Bold = true;
                            } //A +2 az excelben való indexeléshez kell. Az első elem a csoport neve és 1-től indexel az Excel
                        }

                        int rowsInCaseOfExcludeDead = 0; //Ahhoz, hogy ugyan azt a sort felül tudja írni a rendszer, mikor az Exclude Dead érvényesül, ahhoz kell egy második szám, ami nem a ciklusért felel, de meghatározza a sorokat, ahova ír a program.
                        for (int rows = 0; rows < rp.Groups[j].ResultsForFlies.Count; rows++)
                        {
                            for (int columns = -1; columns < rp.Groups[j].ResultsForFlies[rows].Length; columns++) //-1-ről indul, mert az mutatja, hogy a legelső oszlopot tölti épp fel és az indexelés így lesz jó a +2-vel később
                            {
                                if (columns == -1)
                                {
                                    wsheets[Results.IndexOf(rp)].Cells[groupsAdditionalRows + 1 + rowsInCaseOfExcludeDead, "A"] = rp.Groups[j].GetName() + (rows + 1);
                                    wsheets[Results.IndexOf(rp)].Cells[groupsAdditionalRows + 1 + rowsInCaseOfExcludeDead, "A"].Font.Bold = true;
                                }
                                else
                                {
                                    if (rp.Groups[j].ResultsForFlies[rows][columns] == "DEAD" && ExperimentSettingsValues.ExcludeDead)
                                    { //Ha Exclude Dead mellett halott muslicát talál, akkor azt a sort semmiképp ne írja be az excel-be. Eddig az első találatot mindig beírta.
                                        for(int deleteCells = columns + 1;deleteCells > 0;deleteCells--) //Visszamenőlegesen kitörli az eddig beírt mezőket a halott muslica csoportjának sorába
                                        {
                                            wsheets[Results.IndexOf(rp)].Cells[groupsAdditionalRows + 1 + rowsInCaseOfExcludeDead, deleteCells] = "";
                                        }
                                        rowsInCaseOfExcludeDead--;
                                        break;
                                    }

                                    wsheets[Results.IndexOf(rp)].Cells[groupsAdditionalRows + 1 + rowsInCaseOfExcludeDead, columns + 2] = rp.Groups[j].ResultsForFlies[rows][columns];
                                }
                            }
                            rowsInCaseOfExcludeDead++;
                        }

                        if (rp.Groups[j].ResultsForFlies[0].Length == TimeValues.NumberOfDays)
                        {
                            groupsAdditionalRows += rp.Groups[j].NumberOfThisGroup + 4; //Ez a növelés jelöli ki a következő sort, ahova a következő csoport beírása kerül majd.
                        }
                        else if (rp.Groups[j].ResultsForFlies[0].Length == TimeValues.NumberOfHours)
                        {
                            groupsAdditionalRows += rp.Groups[j].NumberOfThisGroup + 6; //Ez a növelés jelöli ki a következő sort, ahova a következő csoport beírása kerül majd.
                        }

                    }

                }, TaskCreationOptions.LongRunning));
            }

            foreach (Task t in taskList) //A taskok futtatása egyenként
            {
                t.Start();
            }

            Task.WaitAll(taskList.ToArray()); //Task-ok bevárása

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            if (sfd.ShowDialog() == true)
            {
                try
                {
                    workbook.SaveAs(sfd.FileName);
                }
                catch
                {
                    workbook.Saved = true; 
                    sfd.FileName = "";
                }
            }
            else
            {
                workbook.Saved = true; //Azért kell, hogy ne kérdezzen rá az excel bezárásánál, hogy akarod-e menteni a munkalapot
                sfd.FileName = "";
            }
            excelFile.Quit();

            return sfd.FileName;

        }

    }
}
