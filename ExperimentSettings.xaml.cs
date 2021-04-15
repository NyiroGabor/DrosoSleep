using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Interaction logic for ExperimentBasicSettings.xaml
    /// </summary>
    public partial class ExperimentBasicSettings : Window
    {
        public ExperimentBasicSettings(bool firstTime)
        {
            InitializeComponent();
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-us"); //Ettől az exception hibaüzenetek angol nyelvűek lesznek magyar helyett
            if (firstTime) //Csak akkor töltse be a fájlból, ha először nyitom meg, egyébként egyszerűbb a programon belüli változókból
            {
                string[] elements = new string[6];
                string[] savedSettings = FilesExportImport.LoadFile("expset.dat"); //Az első elem lesz csak feltöltve de tömb kell a fájl betöltés általánosításához
                if (savedSettings != null)
                {
                    elements = savedSettings[0].Split(';');
                    ExperimentSettingsValues.BinLength = int.Parse(elements[0]);
                    ExperimentSettingsValues.Sleep = int.Parse(elements[1]);
                    ExperimentSettingsValues.Treshold = int.Parse(elements[2]);
                    ExperimentSettingsValues.Dead = int.Parse(elements[3]);
                    ExperimentSettingsValues.ExcludeDead = bool.Parse(elements[4]);
                    ExperimentSettingsValues.SaveSettings = bool.Parse(elements[5]);
                }
            }

            Bin_Length.Text = ExperimentSettingsValues.BinLength.ToString();
            Sleep.Text = ExperimentSettingsValues.Sleep.ToString();
            Treshold.Text = ExperimentSettingsValues.Treshold.ToString();
            Dead.Text = ExperimentSettingsValues.Dead.ToString();
            Exclude_dead.IsChecked = ExperimentSettingsValues.ExcludeDead;
            Save_settings.IsChecked = ExperimentSettingsValues.SaveSettings;
            ChangeNumberOfRowsInASomethingContext(CanHourlyCondition()); //Megnézi, hogy a Bin Length osztható-e 60-al, mert attól függ, hogy van-e értelme Hourly értékeknek.
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(!CanHourlyCondition())
                {
                    throw new Exception();
                }
                ExperimentSettingsValues.BinLength = int.Parse(Bin_Length.Text);
                ExperimentSettingsValues.Sleep = int.Parse(Sleep.Text);
                ExperimentSettingsValues.Treshold = int.Parse(Treshold.Text);
                ExperimentSettingsValues.Dead = int.Parse(Dead.Text);
                ExperimentSettingsValues.ExcludeDead = Exclude_dead.IsChecked.Value;
                ExperimentSettingsValues.SaveSettings = Save_settings.IsChecked.Value;

                if (ExperimentSettingsValues.BinLength < 0 || ExperimentSettingsValues.Sleep < 0 || ExperimentSettingsValues.Treshold < 0 || ExperimentSettingsValues.Dead < 0)
                {
                    throw new ExceptionExpSetMinusNumber("Input value must be greater or equal than 0."); //Negatív értékek nem megengedettek
                }

                string resultsInString = ""; //Az átalakított értékek String-é
                if (ExperimentSettingsValues.SaveSettings)
                {
                    resultsInString = ExperimentSettingsValues.BinLength + ";" + ExperimentSettingsValues.Sleep + ";" + ExperimentSettingsValues.Treshold + ";" + ExperimentSettingsValues.Dead + ";" + ExperimentSettingsValues.ExcludeDead + ";" + ExperimentSettingsValues.SaveSettings;
                }
                else
                {
                    resultsInString = 0 + ";" + 0 + ";" + 0 + ";" + 0 + ";" + false + ";" + false;
                }
                FilesExportImport.WriteFile("expset.dat", resultsInString);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please use reasonable number characters for the values.\nCause of the error: " + ex.Message, "Invalid input", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Bin_Length_KeyUp(object sender, KeyEventArgs e)
        {
            ChangeNumberOfRowsInASomethingContext(CanHourlyCondition()); //Megnézi, hogy a Bin Length osztható-e 60-al, mert attól függ, hogy van-e értelme Hourly értékeknek.
        }

        private bool CanHourlyCondition()
        {
            try
            {
                if (TimeValues.MinutesOfHour % int.Parse(Bin_Length.Text) == 0) //Ha a Bin Length osztható 60-al, csak akkor számoljon hourly értékeket, különben rossz eredmények jönnének ki.
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return true;
            }
        }

        private void ChangeNumberOfRowsInASomethingContext(bool canHourly)
        {
            try //Napok összeszámolásához a try/catch
            {
                Number_Of_Rows_In_A_Day.Foreground = new SolidColorBrush(Colors.Black);
                Number_Of_Rows_In_A_Day.Content = (TimeValues.MinutesOfHour / int.Parse(Bin_Length.Text)) * TimeValues.HoursOfDay;
            }
            catch
            {
                Number_Of_Rows_In_A_Day.Foreground = new SolidColorBrush(Colors.DarkRed);
                Number_Of_Rows_In_A_Day.Content = "Invalid input in the Bin Length field!";
            }

            if(canHourly)
            {
                try //Órák összeszámolásához a try/catch
                {
                    Number_Of_Rows_In_An_Hour.Foreground = new SolidColorBrush(Colors.Black);
                    Number_Of_Rows_In_An_Hour.Content = TimeValues.MinutesOfHour / int.Parse(Bin_Length.Text);
                    Can_Hourly_Calculate_Error.Content = "";
                }
                catch
                {
                    Number_Of_Rows_In_An_Hour.Foreground = new SolidColorBrush(Colors.DarkRed);
                    Number_Of_Rows_In_An_Hour.Content = "Invalid input in the Bin Length field!";
                    Can_Hourly_Calculate_Error.Content = "";
                }
            }
            else
            {
                Number_Of_Rows_In_An_Hour.Foreground = new SolidColorBrush(Colors.DarkRed);
                Number_Of_Rows_In_An_Hour.Content = "THE PARAMETERS CANNOT BE CALCULATED!";
                Number_Of_Rows_In_A_Day.Foreground = new SolidColorBrush(Colors.DarkRed);
                Number_Of_Rows_In_A_Day.Content = "THE PARAMETERS CANNOT BE CALCULATED!";
                Can_Hourly_Calculate_Error.Content = "The Bin Length has to be a divisor of 60!";
            }

        }
    }
}
