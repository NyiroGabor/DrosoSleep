using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for Analyse.xaml
    /// </summary>
    public partial class Analyse : Window
    {
        private List<ResultParameter> Results; //Ez tartalmazza a kísérletben használt összes paramétert. A paraméterek tartalmazzák a hozzájuk tartozó csoportokat. A csoportok tartalmazzák a hozzájuk tartozó értékek eredményeit.
        List<LoadedDAMFile> DAMFiles;

        public Analyse(List<LoadedDAMFile> DAMFiles)
        {
            InitializeComponent();
            this.DAMFiles = DAMFiles;
        }

        private void CalculateTimeValues(LoadedDAMFile DAMFile)
        {
            for(int i = 0; i < DAMFile.LoadedDAMValues.Length; i++)
            {
                string[] timeFormatted = DAMFile.LoadedDAMValues[i][2].Split(':');
                if(timeFormatted[1] == "00" && timeFormatted[2] == "00")
                {
                    TimeValues.WholeHour = timeFormatted;
                    TimeValues.WholeHourRow = i;
                    TimeValues.FirstDayDate = DAMFile.LoadedDAMValues[i][1];
                    break;
                }
            }
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            Results = new List<ResultParameter>();
            CalculateTimeValues(DAMFiles[0]); //Elég a legelső DAM fájlt megvizsgálni ezekhez az adatokhoz, mert a többinek pontosan ugyan azokat az időpontokat kell tartalmaznia. Ha mégse, azt a betöltés kiszűri.
            TimeValues.NumberOfDaysAndNumberOfRowsInADay(DAMFiles[0]);
            TimeValues.LastRowOfDays = TimeValues.WholeHourRow + (TimeValues.NumberOfRowsInADay * TimeValues.NumberOfDays);
            TimeValues.LastRowOfHours = TimeValues.WholeHourRow + (TimeValues.NumberOfRowsInAnHour * TimeValues.NumberOfHours);
            Parameters.Run(Results, DAMFiles);

            //Az OFD azért kell, hogy csak akkor nyissa meg az excelt, ha a program már nem használja.
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FileName = FilesExportImport.WriteToExcel(Results);
            if (ofd.FileName != "")
            {
                bool fileClosed = false;
                while (!fileClosed) //Addig vár, míg a program nem használja már az excelt
                {
                    try
                    {
                        ofd.OpenFile(); //Megnézi, hogy be van-e már zárva a program által
                        Process.Start(ofd.FileName); //Ha nem dob exceptiont, akkor igen és megnyitja az excelt
                        fileClosed = true; //Nem ismétli meg többet a ciklust
                    }
                    catch
                    { }
                }
            }
            Application.Current.Shutdown(); //Bezárja a programot magát
        }
    }
}
