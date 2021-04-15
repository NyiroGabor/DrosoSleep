using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DrosoSleep
{
    /// <summary>
    /// Interaction logic for DL_DAM.xaml
    /// </summary>
    public partial class DL_DAM : Window
    {
        private bool firstTime; //Ez az érték az Experiment Settings menühöz van, hogy az ES megnyitása nélkül ne lehessen analízist indítani
        private List<LoadedDAMFile> DAMFiles; //A DAM fájlok listája, ami tartalmazza a DAM nevét, a fájl értékeit és a hozzá kapcsolt csoport táblázat értékeit is
        private bool firstDAMImport; //Ez az első betöltött DAM-hoz van, hogy a group táblázat addig ne legyen elérhető, amíg ki nem lett választva egy DAM a listában

        public DL_DAM()
        {
            InitializeComponent();
            firstTime = true;
            firstDAMImport = true;
            DAMFiles = new List<LoadedDAMFile>();
            ListOfDAMs.ItemsSource = DAMFiles; //Hozzáköti a DAM-ok listáját a lista mezőkhöz
        }

        private void ExperimentSettings_Click(object sender, RoutedEventArgs e)
        {
            ExperimentBasicSettings ES = new ExperimentBasicSettings(firstTime);
            ES.ShowDialog();
            firstTime = false;
        }

        private void ChooseParameters_Click(object sender, RoutedEventArgs e)
        {
            ChooseParameters CP = new ChooseParameters();
            CP.ShowDialog();
        }

        private void AnalyseSleep_Click(object sender, RoutedEventArgs e)
        {
            bool DAMfilesNumber = false;
            bool groupsFilled = false;
            
            if(DAMFiles.Count == 0)
            {
                MessageBox.Show("You have to import at least one DAM file!", "No DAM files", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                DAMfilesNumber = true;
                for(int i = 0; i<DAMFiles.Count;i++)
                {
                    for(int j = 0;j<DAMFiles[i].GroupTableValues.Length;j++)
                    {
                        if(DAMFiles[i].GroupTableValues[j] != "")
                        {
                            groupsFilled = true;
                        }
                    }
                    if(!groupsFilled)
                    {
                        MessageBox.Show("You have to define at least one group for all DAM files!", "No groups added", MessageBoxButton.OK, MessageBoxImage.Error);
                        break;
                    }
                }
            }
            
            if(firstTime)
            {
                MessageBox.Show("You have to set the Experiment Settings first!", "Missing data", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            if(DAMfilesNumber && groupsFilled && !firstTime)
            {
                Analyse an = new Analyse(DAMFiles);
                an.Show();
                this.Close();
            }
        }

        private void Help_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("The order of the groups is defined from top to bottom and from left to right.\nYou can navigate through the boxes with the arrow keys.\nThe group details will only be applied to the selected DAM once you press the Enter key WHILE A BOX IS SELECTED!","Help",MessageBoxButton.OK,MessageBoxImage.Information);
        }

        private void ArrowKeyNavigation(TextBox leftBox, TextBox upBox, TextBox rightBox, TextBox downBox, KeyEventArgs e) //Ez magába foglalja az össze iránygomb megnyomását így csak ezt kell meghívni a metódusokban. Bemenetként azokat a mezőket tartalmazza, ahova léphet a program. Ha valamelyik irányba nem léphet, ott null-t kap
        {
            if(e.Key == Key.Left)
            {
                leftBox.Focus();
            }
            else if (e.Key == Key.Up)
            {
                upBox.Focus();
            }
            else if (e.Key == Key.Right)
            {
                rightBox.Focus();
            }
            else if (e.Key == Key.Down)
            {
                downBox.Focus();
            }
        }
        
        private bool PressEnterKey(KeyEventArgs e, bool enter) //A Group értékeinek mentése az adott DAM-hoz. Ezt használja a Load Template is, azért kell a bool enter
        {
            if(enter || e.Key == Key.Enter) //Ha enter, akkor a Load Template hívta meg, abban az esetben a KeyEventArgs értéke null lesz. Ha gombmegnyomás hívta meg, akkor az enter false lesz.
            {
                DAMFiles[ListOfDAMs.SelectedIndex].GroupTableValues = ConverterFromTableToGroup();
                SavedLabel.Foreground = Brushes.Green;
                SavedLabel.Content = "SAVED";
                return true;
            }
            return false;
        }

        private string[] ConverterFromTableToGroup() //Mikor a Group értékek elmentésre kerülnek a DAM-hoz egy string[]-be kell tárolni. Ez végzi el az átalakítást
        {
            return new string[] { Box1.Text, Box2.Text, Box3.Text, Box4.Text, Box5.Text, Box6.Text, Box7.Text, Box8.Text, Box9.Text, Box10.Text, Box11.Text, Box12.Text, Box13.Text, Box14.Text, Box15.Text, Box16.Text, Box17.Text, Box18.Text, Box19.Text, Box20.Text, Box21.Text, Box22.Text, Box23.Text, Box24.Text, Box25.Text, Box26.Text, Box27.Text, Box28.Text, Box29.Text, Box30.Text, Box31.Text, Box32.Text};
        }

        private void Navigate_ArrowKeys1(object sender, KeyEventArgs e)
        {
            if (!PressEnterKey(e, false))
            {
                ArrowKeyNavigation(Box32, Box25, Box2, Box9, e);
            }
        }

        private void Navigate_ArrowKeys2(object sender, KeyEventArgs e)
        {
            if (!PressEnterKey(e, false))
            {
                ArrowKeyNavigation(Box1, Box26, Box3, Box10, e);
            }
        }

        private void Navigate_ArrowKeys3(object sender, KeyEventArgs e)
        {
            if (!PressEnterKey(e, false))
            {
                ArrowKeyNavigation(Box2, Box27, Box4, Box11, e);
            }
        }

        private void Navigate_ArrowKeys4(object sender, KeyEventArgs e)
        {
            if (!PressEnterKey(e, false))
            {
                ArrowKeyNavigation(Box3, Box28, Box5, Box12, e);
            }
        }

        private void Navigate_ArrowKeys5(object sender, KeyEventArgs e)
        {
            if (!PressEnterKey(e, false))
            {
                ArrowKeyNavigation(Box4, Box29, Box6, Box13, e);
            }
        }

        private void Navigate_ArrowKeys6(object sender, KeyEventArgs e)
        {
            if (!PressEnterKey(e, false))
            {
                ArrowKeyNavigation(Box5, Box30, Box7, Box14, e);
            }
        }

        private void Navigate_ArrowKeys7(object sender, KeyEventArgs e)
        {
            if (!PressEnterKey(e, false))
            {
                ArrowKeyNavigation(Box6, Box31, Box8, Box15, e);
            }
        }

        private void Navigate_ArrowKeys8(object sender, KeyEventArgs e)
        {
            if (!PressEnterKey(e, false))
            {
                ArrowKeyNavigation(Box7, Box32, Box9, Box16, e);
            }
        }

        private void Navigate_ArrowKeys9(object sender, KeyEventArgs e)
        {
            if (!PressEnterKey(e, false))
            {
                ArrowKeyNavigation(Box16, Box1, Box10, Box17, e);
            }
        }

        private void Navigate_ArrowKeys10(object sender, KeyEventArgs e)
        {
            if (!PressEnterKey(e, false))
            {
                ArrowKeyNavigation(Box9, Box2, Box11, Box18, e);
            }
        }

        private void Navigate_ArrowKeys11(object sender, KeyEventArgs e)
        {
            if (!PressEnterKey(e, false))
            {
                ArrowKeyNavigation(Box10, Box3, Box12, Box19, e);
            }
        }

        private void Navigate_ArrowKeys12(object sender, KeyEventArgs e)
        {
            if (!PressEnterKey(e, false))
            {
                ArrowKeyNavigation(Box11, Box4, Box13, Box20, e);
            }
        }

        private void Navigate_ArrowKeys13(object sender, KeyEventArgs e)
        {
            if (!PressEnterKey(e, false))
            {
                ArrowKeyNavigation(Box12, Box5, Box14, Box21, e);
            }
        }

        private void Navigate_ArrowKeys14(object sender, KeyEventArgs e)
        {
            if (!PressEnterKey(e, false))
            {
                ArrowKeyNavigation(Box13, Box6, Box15, Box22, e);
            }
        }

        private void Navigate_ArrowKeys15(object sender, KeyEventArgs e)
        {
            if (!PressEnterKey(e, false))
            {
                ArrowKeyNavigation(Box14, Box7, Box16, Box23, e);
            }
        }

        private void Navigate_ArrowKeys16(object sender, KeyEventArgs e)
        {
            if (!PressEnterKey(e, false))
            {
                ArrowKeyNavigation(Box15, Box8, Box17, Box24, e);
            }
        }

        private void Navigate_ArrowKeys17(object sender, KeyEventArgs e)
        {
            if (!PressEnterKey(e, false))
            {
                ArrowKeyNavigation(Box24, Box9, Box18, Box25, e);
            }
        }

        private void Navigate_ArrowKeys18(object sender, KeyEventArgs e)
        {
            if (!PressEnterKey(e, false))
            {
                ArrowKeyNavigation(Box17, Box10, Box19, Box26, e);
            }
        }

        private void Navigate_ArrowKeys19(object sender, KeyEventArgs e)
        {
            if (!PressEnterKey(e, false))
            {
                ArrowKeyNavigation(Box18, Box11, Box20, Box27, e);
            }
        }

        private void Navigate_ArrowKeys20(object sender, KeyEventArgs e)
        {
            if (!PressEnterKey(e, false))
            {
                ArrowKeyNavigation(Box19, Box12, Box21, Box28, e);
            }
        }

        private void Navigate_ArrowKeys21(object sender, KeyEventArgs e)
        {
            if (!PressEnterKey(e, false))
            {
                ArrowKeyNavigation(Box20, Box13, Box22, Box29, e);
            }
        }

        private void Navigate_ArrowKeys22(object sender, KeyEventArgs e)
        {
            if (!PressEnterKey(e, false))
            {
                ArrowKeyNavigation(Box21, Box14, Box23, Box30, e);
            }
        }

        private void Navigate_ArrowKeys23(object sender, KeyEventArgs e)
        {
            if (!PressEnterKey(e, false))
            {
                ArrowKeyNavigation(Box22, Box15, Box24, Box31, e);
            }
        }

        private void Navigate_ArrowKeys24(object sender, KeyEventArgs e)
        {
            if (!PressEnterKey(e, false))
            {
                ArrowKeyNavigation(Box23, Box16, Box25, Box32, e);
            }
        }

        private void Navigate_ArrowKeys25(object sender, KeyEventArgs e)
        {
            if (!PressEnterKey(e, false))
            {
                ArrowKeyNavigation(Box32, Box17, Box26, Box1, e);
            }
        }

        private void Navigate_ArrowKeys26(object sender, KeyEventArgs e)
        {
            if (!PressEnterKey(e, false))
            {
                ArrowKeyNavigation(Box25, Box18, Box27, Box2, e);
            }
        }

        private void Navigate_ArrowKeys27(object sender, KeyEventArgs e)
        {
            if (!PressEnterKey(e, false))
            {
                ArrowKeyNavigation(Box26, Box19, Box28, Box3, e);
            }
        }

        private void Navigate_ArrowKeys28(object sender, KeyEventArgs e)
        {
            if (!PressEnterKey(e, false))
            {
                ArrowKeyNavigation(Box27, Box20, Box29, Box4, e);
            }
        }

        private void Navigate_ArrowKeys29(object sender, KeyEventArgs e)
        {
            if (!PressEnterKey(e, false))
            {
                ArrowKeyNavigation(Box28, Box21, Box30, Box5, e);
            }
        }

        private void Navigate_ArrowKeys30(object sender, KeyEventArgs e)
        {
            if (!PressEnterKey(e, false))
            {
                ArrowKeyNavigation(Box29, Box22, Box31, Box6, e);
            }
        }

        private void Navigate_ArrowKeys31(object sender, KeyEventArgs e)
        {
            if (!PressEnterKey(e, false))
            {
                ArrowKeyNavigation(Box30, Box23, Box32, Box7, e);
            }
        }

        private void Navigate_ArrowKeys32(object sender, KeyEventArgs e)
        {
            if (!PressEnterKey(e, false))
            {
                ArrowKeyNavigation(Box31, Box24, Box1, Box8, e);
            }
        }

        private void SaveTemplate_Click(object sender, RoutedEventArgs e)
        {
            string groupTableValues = Box1.Text + ";" + Box2.Text + ";" + Box3.Text + ";" + Box4.Text + ";" + Box5.Text + ";" + Box6.Text + ";" + Box7.Text + ";" + Box8.Text + ";" + Box9.Text + ";" + Box10.Text + ";" + Box11.Text + ";" + Box12.Text + ";" + Box13.Text + ";" + Box14.Text + ";" + Box15.Text + ";" + Box16.Text + ";" + Box17.Text + ";" + Box18.Text + ";" + Box19.Text + ";" + Box20.Text + ";" + Box21.Text + ";" + Box22.Text + ";" + Box23.Text + ";" + Box24.Text + ";" + Box25.Text + ";" + Box26.Text + ";" + Box27.Text + ";" + Box28.Text + ";" + Box29.Text + ";" + Box30.Text + ";" + Box31.Text + ";" + Box32.Text;
            //Ez a string tartalmazza a csoport értékeket, amik aztán a fájlba lesznek kimentve

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Template file|*.tmp";
            sfd.Title = "Save the template";
            if (sfd.ShowDialog() == true)
            {
                FilesExportImport.WriteFile(sfd.FileName, groupTableValues);
            }
        }

        private OpenFileDialog ofd = new OpenFileDialog(); //2 metódus is használja alább, ezért egyszerűbb 1db belőle

        private void FillTheGroups(string[] groups) //Meg lehet határozni a csoportok dobozainak tartalmát
        {
            Box1.Text = groups[0];
            Box2.Text = groups[1];
            Box3.Text = groups[2];
            Box4.Text = groups[3];
            Box5.Text = groups[4];
            Box6.Text = groups[5];
            Box7.Text = groups[6];
            Box8.Text = groups[7];
            Box9.Text = groups[8];
            Box10.Text = groups[9];
            Box11.Text = groups[10];
            Box12.Text = groups[11];
            Box13.Text = groups[12];
            Box14.Text = groups[13];
            Box15.Text = groups[14];
            Box16.Text = groups[15];
            Box17.Text = groups[16];
            Box18.Text = groups[17];
            Box19.Text = groups[18];
            Box20.Text = groups[19];
            Box21.Text = groups[20];
            Box22.Text = groups[21];
            Box23.Text = groups[22];
            Box24.Text = groups[23];
            Box25.Text = groups[24];
            Box26.Text = groups[25];
            Box27.Text = groups[26];
            Box28.Text = groups[27];
            Box29.Text = groups[28];
            Box30.Text = groups[29];
            Box31.Text = groups[30];
            Box32.Text = groups[31];
        }

        private void LoadTemplate_Click(object sender, RoutedEventArgs e)
        {
            ofd.Filter = "Template file|*.tmp";
            ofd.FileName = "";
            ofd.Title = "Open the template";
            if (ofd.ShowDialog() == true) //Megnyitás gombbal valamit betöltött a felhasználó sikeresen
            {
                string[] loadedGroupValues = FilesExportImport.LoadFile(ofd.FileName);
                string[] formattedGroupValues = loadedGroupValues[0].Split(';');
                FillTheGroups(formattedGroupValues);
                PressEnterKey(null, true); //Elmenti a csoport értékeit egyből a DAM fájlhoz
            }
        }

        private void ImportDAM_Click(object sender, RoutedEventArgs e)
        {
            
            if (ListOfDAMs.Items.Count < 10)
            {
                ofd.FileName = ""; //Hogy ne legyen már valamilyen érték a kifelölt mezőben
                ofd.Multiselect = true; //Egyszerre több elem is kiválasztható
                ofd.Filter = "Text file|*.txt";
                ofd.Title = "Import the DAM output";
                if (ofd.ShowDialog() == true) //Megnyitás gombbal valamit betöltött a felhasználó sikeresen
                {
                    foreach (string filename in ofd.FileNames)
                    {
                        string[] rawDAMFile = FilesExportImport.LoadFile(filename); //Egy sor a DAM-ban itt 1 tömb
                        LoadedDAMFile ldf = new LoadedDAMFile(filename, new string[rawDAMFile.Length][]);
                        for (int i = 0; i < rawDAMFile.Length; i++)
                        {
                            ldf.LoadedDAMValues[i] = rawDAMFile[i].Split('\t');
                        }

                        ldf.LoadedDAMValues = ErrorDataChecking(ldf.LoadedDAMValues); //Null-t kap vissza, ha a felhasználó nem akarja folytatni ezzel a DAM-mal
                        if (ldf.LoadedDAMValues != null)
                        {
                            DAMFiles.Add(ldf);
                            ListOfDAMs.Items.Refresh();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("You reached the maximum number of DAMs for this experiment!", "DAM number exceeded", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ErrorMessageForDateChecking()
        {
            MessageBox.Show("The dates and/or times in the DAM file are not continuous. Try again after fixing the issue.");
        }

        private string[][] ErrorDataChecking(string[][] loadedDAMValues) //A 4. oszlopban a DAM fájlban ha nem 1-es szerepel, az hiba
        { //Ha egyszer megy végig a DAM-on, az hatékonyabb, szóval itt nézi a dátumot is. Az idő túlságosan random értékeket vehet fel, ezért az nem jó minta felismeréshez és ezáltal a DAM fájl ellenőrzéséhez
            string[] date = new string[3]; //A dátum és idő mindig 3 mezőt tartalmaz
            string[] time = new string[3]; //Egy bizonyos hibatűréssel lehet vizsgálni az időt is. Ha nagyobb az eltérés, mint 1 óra, akkor meg kell nézni, hogy a napok megváltoztak-e.
            string[] prevDate = date;
            string[] prevTime = time;

            for (int i=0;i<loadedDAMValues.Length;i++)
            {
                date = loadedDAMValues[i][1].Split(' '); //Ez tartalmazza az aktuális sor dátumát, ami mindig 3 értékből áll (nap, hó, év)
                time = loadedDAMValues[i][2].Split(':'); //Ez tartalmazza az aktuális sor idejét, ami mindig 3 értékből áll (óra, perc, másodperc)
                if (i>0) //Az első körben nem vizsgálja, hogy a prevDate is kaphassonon értéket, így tudja onnantól összehasonlítani az elemeket
                {
                    if(date[2] == prevDate[2]) //Megegyezik az évszám
                    {
                        if(date[1] == prevDate[1]) //Megegyezik a hónap
                        {
                            if(date[0] == prevDate[0])
                            {
                                if ((int.Parse(time[0]) - int.Parse(prevTime[0])) > 2 || (int.Parse(time[0]) - int.Parse(prevTime[0])) < 0) //2 óránál nagyobb eltérés a sorok között hibát eredményez
                                {
                                    ErrorMessageForDateChecking();
                                    return null;
                                }
                            }
                            else if((int.Parse(date[0]) - int.Parse(prevDate[0])) > 1 || (int.Parse(date[0]) - int.Parse(prevDate[0])) < 0) //Ha több mint 1 nap eltérés van, hibát eredményez
                            {
                                ErrorMessageForDateChecking();
                                return null;
                            }
                        }
                        else
                        {
                            int indexOfDate = TimeValues.IndexOfMonth(date[1]);
                            int indexOfPrevDate = TimeValues.IndexOfMonth(prevDate[1]);
                            if(indexOfDate == -1 || indexOfDate == -1 || (indexOfDate - indexOfPrevDate > 1 || indexOfDate - indexOfPrevDate < 0)) //Ha normális hónapok vannak megadva és a különbségük több, mint 1 hónap, akkor hibaüzenet
                            {
                                ErrorMessageForDateChecking();
                                return null;
                            }
                        }
                    }
                    else if((int.Parse(date[2]) - int.Parse(prevDate[2])) > 1 || (int.Parse(date[2]) - int.Parse(prevDate[2])) < 0) //Ha több, mint 1 év a különbség, akkor hibaüzenet
                    {
                        ErrorMessageForDateChecking();
                        return null;
                    }
                }
                prevTime = time;
                prevDate = date;
                

                if (loadedDAMValues[i][3] != "1") //Az 1-es szám vizsgálatához a 4. oszlopban
                {
                    if(MessageBox.Show("An error was found in the DAM file!\nRow " + (i+1) +  " and column 4." + "\nDo you want to import the DAM file without the data from this row?", "Wrong input data", MessageBoxButton.YesNo,MessageBoxImage.Warning) == MessageBoxResult.Yes)
                    {
                        loadedDAMValues[i][0] = "-1";
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            return loadedDAMValues;
        }
        
        private void RemoveListElement() //A Remove gomb és a Delete gomb is ezt hívja meg, mert mindkettő ugyan arra van
        {
            if (ListOfDAMs.SelectedIndex != -1 && MessageBox.Show("Are you sure you want to remove the " + ListOfDAMs.SelectedItem.ToString() + " DAM file?", "Remove DAM", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                if (ListOfDAMs.Items.Count > 0)
                {
                    DAMFiles.RemoveAt(ListOfDAMs.SelectedIndex);
                    TurnGroupsOnOff(false); //Az Enabled értéket kikapcsolja a dobozokhoz
                    firstDAMImport = true; //Ha legközelebb focus kerül a listára, akkor aktiválja megint a dobozokat
                    Keyboard.ClearFocus();
                    ListOfDAMs.Items.Refresh();
                }
            }
        }

        private void RemoveDAM_Click(object sender, RoutedEventArgs e)
        {
            RemoveListElement();
        }

        private void ClearAllDAMs_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to remove all DAM files?", "Clear all DAMs", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                DAMFiles.Clear();
                TurnGroupsOnOff(false);
                firstDAMImport = true;
                ListOfDAMs.Items.Refresh();
            }
        }

        private void TurnGroupsOnOff(bool enable)
        {
            if(enable)
            {
                Box1.IsEnabled = true;
                Box2.IsEnabled = true;
                Box3.IsEnabled = true;
                Box4.IsEnabled = true;
                Box5.IsEnabled = true;
                Box6.IsEnabled = true;
                Box7.IsEnabled = true;
                Box8.IsEnabled = true;
                Box9.IsEnabled = true;
                Box10.IsEnabled = true;
                Box11.IsEnabled = true;
                Box12.IsEnabled = true;
                Box13.IsEnabled = true;
                Box14.IsEnabled = true;
                Box15.IsEnabled = true;
                Box16.IsEnabled = true;
                Box17.IsEnabled = true;
                Box18.IsEnabled = true;
                Box19.IsEnabled = true;
                Box20.IsEnabled = true;
                Box21.IsEnabled = true;
                Box22.IsEnabled = true;
                Box23.IsEnabled = true;
                Box24.IsEnabled = true;
                Box25.IsEnabled = true;
                Box26.IsEnabled = true;
                Box27.IsEnabled = true;
                Box28.IsEnabled = true;
                Box29.IsEnabled = true;
                Box30.IsEnabled = true;
                Box31.IsEnabled = true;
                Box32.IsEnabled = true;
                SaveTemplateButton.IsEnabled = true;
                LoadTemplateButton.IsEnabled = true;
            }
            else
            {
                FillTheGroups(new string[TimeValues.NumberOfGroups]);
                Box1.IsEnabled = false;
                Box2.IsEnabled = false;
                Box3.IsEnabled = false;
                Box4.IsEnabled = false;
                Box5.IsEnabled = false;
                Box6.IsEnabled = false;
                Box7.IsEnabled = false;
                Box8.IsEnabled = false;
                Box9.IsEnabled = false;
                Box10.IsEnabled = false;
                Box11.IsEnabled = false;
                Box12.IsEnabled = false;
                Box13.IsEnabled = false;
                Box14.IsEnabled = false;
                Box15.IsEnabled = false;
                Box16.IsEnabled = false;
                Box17.IsEnabled = false;
                Box18.IsEnabled = false;
                Box19.IsEnabled = false;
                Box20.IsEnabled = false;
                Box21.IsEnabled = false;
                Box22.IsEnabled = false;
                Box23.IsEnabled = false;
                Box24.IsEnabled = false;
                Box25.IsEnabled = false;
                Box26.IsEnabled = false;
                Box27.IsEnabled = false;
                Box28.IsEnabled = false;
                Box29.IsEnabled = false;
                Box30.IsEnabled = false;
                Box31.IsEnabled = false;
                Box32.IsEnabled = false;
                SaveTemplateButton.IsEnabled = false;
                LoadTemplateButton.IsEnabled = false;
            }
        } //Aktiválja, vagy deaktiválja a Group dobozokat

        private void FocusOnListOfDAMs(object sender, RoutedEventArgs e)
        {
            if(firstDAMImport) //Ha eddig deaktiválva voltak a dobozok, akkor amint focus kerül a listára, aktiválja a dobozokat
            {
                TurnGroupsOnOff(true);
                firstDAMImport = false;
            }
        }

        private void SelectionChangedForListOfDAMs(object sender, SelectionChangedEventArgs e)
        {
            if (!firstDAMImport) //Ha el false, akkor focus került a listára és valami biztosan ki van jelölve. Ez akkor true, ha nincs kijelölés a listán, ekkor pedig nem tudja a kijelölt DAM-hoz párosítani a csoportot, mert nincs is kijelölt DAM
            {
                FillTheGroups(DAMFiles[ListOfDAMs.SelectedIndex].GroupTableValues);
            }
        }

        private void SavedLabelChangeOnTextChange() //Ha megváltozik a tartalma egy doboznak, akkor a mentés szöveg megváltozik a dobozok alatt
        {
            SavedLabel.Foreground = Brushes.Firebrick;
            SavedLabel.Content = "Press Enter to Apply";
        }

        private void TextChangedInBOX1(object sender, TextChangedEventArgs e)
        {
            SavedLabelChangeOnTextChange();
        }

        private void TextChangedInBOX2(object sender, TextChangedEventArgs e)
        {
            SavedLabelChangeOnTextChange();
        }

        private void TextChangedInBOX3(object sender, TextChangedEventArgs e)
        {
            SavedLabelChangeOnTextChange();
        }

        private void TextChangedInBOX4(object sender, TextChangedEventArgs e)
        {
            SavedLabelChangeOnTextChange();
        }

        private void TextChangedInBOX5(object sender, TextChangedEventArgs e)
        {
            SavedLabelChangeOnTextChange();
        }

        private void TextChangedInBOX6(object sender, TextChangedEventArgs e)
        {
            SavedLabelChangeOnTextChange();
        }

        private void TextChangedInBOX7(object sender, TextChangedEventArgs e)
        {
            SavedLabelChangeOnTextChange();
        }

        private void TextChangedInBOX8(object sender, TextChangedEventArgs e)
        {
            SavedLabelChangeOnTextChange();
        }

        private void TextChangedInBOX9(object sender, TextChangedEventArgs e)
        {
            SavedLabelChangeOnTextChange();
        }

        private void TextChangedInBOX10(object sender, TextChangedEventArgs e)
        {
            SavedLabelChangeOnTextChange();
        }

        private void TextChangedInBOX11(object sender, TextChangedEventArgs e)
        {
            SavedLabelChangeOnTextChange();
        }

        private void TextChangedInBOX12(object sender, TextChangedEventArgs e)
        {
            SavedLabelChangeOnTextChange();
        }

        private void TextChangedInBOX13(object sender, TextChangedEventArgs e)
        {
            SavedLabelChangeOnTextChange();
        }

        private void TextChangedInBOX14(object sender, TextChangedEventArgs e)
        {
            SavedLabelChangeOnTextChange();
        }

        private void TextChangedInBOX15(object sender, TextChangedEventArgs e)
        {
            SavedLabelChangeOnTextChange();
        }

        private void TextChangedInBOX16(object sender, TextChangedEventArgs e)
        {
            SavedLabelChangeOnTextChange();
        }

        private void TextChangedInBOX17(object sender, TextChangedEventArgs e)
        {
            SavedLabelChangeOnTextChange();
        }

        private void TextChangedInBOX18(object sender, TextChangedEventArgs e)
        {
            SavedLabelChangeOnTextChange();
        }

        private void TextChangedInBOX19(object sender, TextChangedEventArgs e)
        {
            SavedLabelChangeOnTextChange();
        }

        private void TextChangedInBOX20(object sender, TextChangedEventArgs e)
        {
            SavedLabelChangeOnTextChange();
        }

        private void TextChangedInBOX21(object sender, TextChangedEventArgs e)
        {
            SavedLabelChangeOnTextChange();
        }

        private void TextChangedInBOX22(object sender, TextChangedEventArgs e)
        {
            SavedLabelChangeOnTextChange();
        }

        private void TextChangedInBOX23(object sender, TextChangedEventArgs e)
        {
            SavedLabelChangeOnTextChange();
        }

        private void TextChangedInBOX24(object sender, TextChangedEventArgs e)
        {
            SavedLabelChangeOnTextChange();
        }

        private void TextChangedInBOX25(object sender, TextChangedEventArgs e)
        {
            SavedLabelChangeOnTextChange();
        }

        private void TextChangedInBOX26(object sender, TextChangedEventArgs e)
        {
            SavedLabelChangeOnTextChange();
        }

        private void TextChangedInBOX27(object sender, TextChangedEventArgs e)
        {
            SavedLabelChangeOnTextChange();
        }

        private void TextChangedInBOX28(object sender, TextChangedEventArgs e)
        {
            SavedLabelChangeOnTextChange();
        }

        private void TextChangedInBOX29(object sender, TextChangedEventArgs e)
        {
            SavedLabelChangeOnTextChange();
        }

        private void TextChangedInBOX30(object sender, TextChangedEventArgs e)
        {
            SavedLabelChangeOnTextChange();
        }

        private void TextChangedInBOX31(object sender, TextChangedEventArgs e)
        {
            SavedLabelChangeOnTextChange();
        }

        private void TextChangedInBOX32(object sender, TextChangedEventArgs e)
        {
            SavedLabelChangeOnTextChange();
        }

        private void RemoveDelete_Key(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                RemoveListElement();
            }
        }
    }
}
