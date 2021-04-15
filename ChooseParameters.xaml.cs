using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Interaction logic for ChooseParameters.xaml
    /// </summary>
    public partial class ChooseParameters : Window
    {
        public ChooseParameters()
        {
            InitializeComponent();
            Daily_or_Hourly.SelectedIndex = 0;

            try
            {
                if (TimeValues.MinutesOfHour % ExperimentSettingsValues.BinLength != 0) //Ha a Bin Length alapján nincs értelme Hourly paramétereket számolni, akkor azt deaktiválja az ablak
                {
                    ComboBox_Hourly.IsEnabled = false;
                }
            }
            catch { }

            Total_Sleep_Day.IsChecked = Parameters.TotalSleepDay;
            Total_Sleep_Dark.IsChecked = Parameters.TotalSleepDark;
            Total_Sleep_Light.IsChecked = Parameters.TotalSleepLight;
            Total_Activity_Day.IsChecked = Parameters.TotalActivityDay;
            Total_Activity_Dark.IsChecked = Parameters.TotalActivityDark;
            Total_Activity_Light.IsChecked = Parameters.TotalActivityLight;
            Total_Inactivity_Day.IsChecked = Parameters.TotalInactivityDay;
            Total_Inactivity_Dark.IsChecked = Parameters.TotalInactivityDark;
            Total_Inactivity_Light.IsChecked = Parameters.TotalInactivityLight;
            Number_Of_Sleep_Bouts_Day.IsChecked = Parameters.NumberOfSleepBoutsDay;
            Number_Of_Sleep_Bouts_Dark.IsChecked = Parameters.NumberOfSleepBoutsDark;
            Number_Of_Sleep_Bouts_Light.IsChecked = Parameters.NumberOfSleepBoutsLight;
            Longest_Sleep_Bout_Length_Day.IsChecked = Parameters.LongestSleepBoutLengthDay;
            Longest_Sleep_Bout_Length_Dark.IsChecked = Parameters.LongestSleepBoutLengthDark;
            Longest_Sleep_Bout_Length_Light.IsChecked = Parameters.LongestSleepBoutLengthLight;
            Total_Activity_Level_Day.IsChecked = Parameters.TotalActivityLevelDay;
            Total_Activity_Level_Dark.IsChecked = Parameters.TotalActivityLevelDark;
            Total_Activity_Level_Light.IsChecked = Parameters.TotalActivityLevelLight;
            Average_Activity_Bout_Length_Day.IsChecked = Parameters.AverageActivityBoutLengthDay;
            Average_Activity_Bout_Length_Dark.IsChecked = Parameters.AverageActivityBoutLengthDark;
            Average_Activity_Bout_Length_Light.IsChecked = Parameters.AverageActivityBoutLengthLight;
            Average_Sleep_Bout_Length_Day.IsChecked = Parameters.AverageSleepBoutLengthDay;
            Average_Sleep_Bout_Length_Dark.IsChecked = Parameters.AverageSleepBoutLengthDark;
            Average_Sleep_Bout_Length_Light.IsChecked = Parameters.AverageSleepBoutLengthLight;

            Total_Activity_Hourly.IsChecked = Parameters.TotalActivityHourly;
            Total_Sleep_Hourly.IsChecked = Parameters.TotalSleepHourly;
            Number_Of_Sleep_Bouts_Hourly.IsChecked = Parameters.NumberOfSleepBoutsHourly;
            Average_Sleep_Bout_Length_Hourly.IsChecked = Parameters.AverageSleepBoutLengthHourly;
            Average_Activity_Bout_Length_Hourly.IsChecked = Parameters.AverageActivityBoutLengthHourly;
            Total_Inactivity_Hourly.IsChecked = Parameters.TotalInactivityHourly;
            Total_Activity_Level_Hourly.IsChecked = Parameters.TotalActivityLevelHourly;
            Average_Activity_Level_Hourly.IsChecked = Parameters.AverageActivityLevelHourly;
            
        }

        private void Cancel_Click(object sender, RoutedEventArgs e) //Nem menti el az elemeket az ablak bezárásánál
        {
            this.Close();
        }

        private void Save_Click(object sender, RoutedEventArgs e) //Elmenti a paramétereket az ablak bezárásánál
        {
            Parameters.TotalSleepDay = Total_Sleep_Day.IsChecked.Value;
            Parameters.TotalSleepDark = Total_Sleep_Dark.IsChecked.Value;
            Parameters.TotalSleepLight = Total_Sleep_Light.IsChecked.Value;
            Parameters.TotalActivityDay = Total_Activity_Day.IsChecked.Value;
            Parameters.TotalActivityDark = Total_Activity_Dark.IsChecked.Value;
            Parameters.TotalActivityLight = Total_Activity_Light.IsChecked.Value;
            Parameters.TotalInactivityDay = Total_Inactivity_Day.IsChecked.Value;
            Parameters.TotalInactivityDark = Total_Inactivity_Dark.IsChecked.Value;
            Parameters.TotalInactivityLight = Total_Inactivity_Light.IsChecked.Value;
            Parameters.NumberOfSleepBoutsDay = Number_Of_Sleep_Bouts_Day.IsChecked.Value;
            Parameters.NumberOfSleepBoutsDark = Number_Of_Sleep_Bouts_Dark.IsChecked.Value;
            Parameters.NumberOfSleepBoutsLight = Number_Of_Sleep_Bouts_Light.IsChecked.Value;
            Parameters.LongestSleepBoutLengthDay = Longest_Sleep_Bout_Length_Day.IsChecked.Value;
            Parameters.LongestSleepBoutLengthDark = Longest_Sleep_Bout_Length_Dark.IsChecked.Value;
            Parameters.LongestSleepBoutLengthLight = Longest_Sleep_Bout_Length_Light.IsChecked.Value;
            Parameters.TotalActivityLevelDay = Total_Activity_Level_Day.IsChecked.Value;
            Parameters.TotalActivityLevelDark = Total_Activity_Level_Dark.IsChecked.Value;
            Parameters.TotalActivityLevelLight = Total_Activity_Level_Light.IsChecked.Value;
            Parameters.AverageActivityBoutLengthDay = Average_Activity_Bout_Length_Day.IsChecked.Value;
            Parameters.AverageActivityBoutLengthDark = Average_Activity_Bout_Length_Dark.IsChecked.Value;
            Parameters.AverageActivityBoutLengthLight = Average_Activity_Bout_Length_Light.IsChecked.Value;
            Parameters.AverageSleepBoutLengthDay = Average_Sleep_Bout_Length_Day.IsChecked.Value;
            Parameters.AverageSleepBoutLengthDark = Average_Sleep_Bout_Length_Dark.IsChecked.Value;
            Parameters.AverageSleepBoutLengthLight = Average_Sleep_Bout_Length_Light.IsChecked.Value;
            Parameters.TotalActivityHourly = Total_Activity_Hourly.IsChecked.Value;
            Parameters.TotalSleepHourly = Total_Sleep_Hourly.IsChecked.Value;
            Parameters.NumberOfSleepBoutsHourly = Number_Of_Sleep_Bouts_Hourly.IsChecked.Value;
            Parameters.AverageSleepBoutLengthHourly = Average_Sleep_Bout_Length_Hourly.IsChecked.Value;
            Parameters.AverageActivityBoutLengthHourly = Average_Activity_Bout_Length_Hourly.IsChecked.Value;
            Parameters.TotalInactivityHourly = Total_Inactivity_Hourly.IsChecked.Value;
            Parameters.TotalActivityLevelHourly = Total_Activity_Level_Hourly.IsChecked.Value;
            Parameters.AverageActivityLevelHourly = Average_Activity_Level_Hourly.IsChecked.Value;
            this.Close();
        }

        private void Daily_or_Hourly_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(Daily_or_Hourly.SelectedIndex == 0)
            {
                Total_Activity_Hourly.Visibility = Visibility.Hidden;
                Total_Sleep_Hourly.Visibility = Visibility.Hidden;
                Number_Of_Sleep_Bouts_Hourly.Visibility = Visibility.Hidden;
                Average_Sleep_Bout_Length_Hourly.Visibility = Visibility.Hidden;
                Average_Activity_Bout_Length_Hourly.Visibility = Visibility.Hidden;
                Total_Inactivity_Hourly.Visibility = Visibility.Hidden;
                Total_Activity_Level_Hourly.Visibility = Visibility.Hidden;
                Average_Activity_Level_Hourly.Visibility = Visibility.Hidden;

                Total_Sleep_Day.Visibility = Visibility.Visible;
                Total_Sleep_Dark.Visibility = Visibility.Visible;
                Total_Sleep_Light.Visibility = Visibility.Visible;
                Total_Activity_Day.Visibility = Visibility.Visible;
                Total_Activity_Dark.Visibility = Visibility.Visible;
                Total_Activity_Light.Visibility = Visibility.Visible;
                Total_Inactivity_Day.Visibility = Visibility.Visible;
                Total_Inactivity_Dark.Visibility = Visibility.Visible;
                Total_Inactivity_Light.Visibility = Visibility.Visible;
                Number_Of_Sleep_Bouts_Day.Visibility = Visibility.Visible;
                Number_Of_Sleep_Bouts_Dark.Visibility = Visibility.Visible;
                Number_Of_Sleep_Bouts_Light.Visibility = Visibility.Visible;
                Longest_Sleep_Bout_Length_Day.Visibility = Visibility.Visible;
                Longest_Sleep_Bout_Length_Dark.Visibility = Visibility.Visible;
                Longest_Sleep_Bout_Length_Light.Visibility = Visibility.Visible;
                Total_Activity_Level_Day.Visibility = Visibility.Visible;
                Total_Activity_Level_Dark.Visibility = Visibility.Visible;
                Total_Activity_Level_Light.Visibility = Visibility.Visible;
                Average_Activity_Bout_Length_Day.Visibility = Visibility.Visible;
                Average_Activity_Bout_Length_Dark.Visibility = Visibility.Visible;
                Average_Activity_Bout_Length_Light.Visibility = Visibility.Visible;
                Average_Sleep_Bout_Length_Day.Visibility = Visibility.Visible;
                Average_Sleep_Bout_Length_Dark.Visibility = Visibility.Visible;
                Average_Sleep_Bout_Length_Light.Visibility = Visibility.Visible;
                TotalActivity_Label.Visibility = Visibility.Visible;
                LongestSleepBoutLength_Label.Visibility = Visibility.Visible;
                TotalSleep_Label.Visibility = Visibility.Visible;
                AverageSleepBoutLength_Label.Visibility = Visibility.Visible;
                TotalActivityLevel_Label.Visibility = Visibility.Visible;
                NumberOfSleepBouts_Label.Visibility = Visibility.Visible;
                AverageActivityBoutLength_Label.Visibility = Visibility.Visible;
                TotalInactivity_Label.Visibility = Visibility.Visible;
            }
            else if (Daily_or_Hourly.SelectedIndex == 1)
            {
                Total_Sleep_Day.Visibility = Visibility.Hidden;
                Total_Sleep_Dark.Visibility = Visibility.Hidden;
                Total_Sleep_Light.Visibility = Visibility.Hidden;
                Total_Activity_Day.Visibility = Visibility.Hidden;
                Total_Activity_Dark.Visibility = Visibility.Hidden;
                Total_Activity_Light.Visibility = Visibility.Hidden;
                Total_Inactivity_Day.Visibility = Visibility.Hidden;
                Total_Inactivity_Dark.Visibility = Visibility.Hidden;
                Total_Inactivity_Light.Visibility = Visibility.Hidden;
                Number_Of_Sleep_Bouts_Day.Visibility = Visibility.Hidden;
                Number_Of_Sleep_Bouts_Dark.Visibility = Visibility.Hidden;
                Number_Of_Sleep_Bouts_Light.Visibility = Visibility.Hidden;
                Longest_Sleep_Bout_Length_Day.Visibility = Visibility.Hidden;
                Longest_Sleep_Bout_Length_Dark.Visibility = Visibility.Hidden;
                Longest_Sleep_Bout_Length_Light.Visibility = Visibility.Hidden;
                Total_Activity_Level_Day.Visibility = Visibility.Hidden;
                Total_Activity_Level_Dark.Visibility = Visibility.Hidden;
                Total_Activity_Level_Light.Visibility = Visibility.Hidden;
                Average_Activity_Bout_Length_Day.Visibility = Visibility.Hidden;
                Average_Activity_Bout_Length_Dark.Visibility = Visibility.Hidden;
                Average_Activity_Bout_Length_Light.Visibility = Visibility.Hidden;
                Average_Sleep_Bout_Length_Day.Visibility = Visibility.Hidden;
                Average_Sleep_Bout_Length_Dark.Visibility = Visibility.Hidden;
                Average_Sleep_Bout_Length_Light.Visibility = Visibility.Hidden;
                TotalActivity_Label.Visibility = Visibility.Hidden;
                LongestSleepBoutLength_Label.Visibility = Visibility.Hidden;
                TotalSleep_Label.Visibility = Visibility.Hidden;
                AverageSleepBoutLength_Label.Visibility = Visibility.Hidden;
                TotalActivityLevel_Label.Visibility = Visibility.Hidden;
                NumberOfSleepBouts_Label.Visibility = Visibility.Hidden;
                AverageActivityBoutLength_Label.Visibility = Visibility.Hidden;
                TotalInactivity_Label.Visibility = Visibility.Hidden;

                Total_Activity_Hourly.Visibility = Visibility.Visible;
                Total_Sleep_Hourly.Visibility = Visibility.Visible;
                Number_Of_Sleep_Bouts_Hourly.Visibility = Visibility.Visible;
                Average_Sleep_Bout_Length_Hourly.Visibility = Visibility.Visible;
                Average_Activity_Bout_Length_Hourly.Visibility = Visibility.Visible;
                Total_Inactivity_Hourly.Visibility = Visibility.Visible;
                Total_Activity_Level_Hourly.Visibility = Visibility.Visible;
                Average_Activity_Level_Hourly.Visibility = Visibility.Visible;
            }
        }

        private void SelectAll_Click(object sender, RoutedEventArgs e)
        {
            if(Daily_or_Hourly.SelectedIndex == 0)
            {
                Total_Sleep_Day.IsChecked = true;
                Total_Sleep_Dark.IsChecked = true;
                Total_Sleep_Light.IsChecked = true;
                Total_Activity_Day.IsChecked = true;
                Total_Activity_Dark.IsChecked = true;
                Total_Activity_Light.IsChecked = true;
                Total_Inactivity_Day.IsChecked = true;
                Total_Inactivity_Dark.IsChecked = true;
                Total_Inactivity_Light.IsChecked = true;
                Number_Of_Sleep_Bouts_Day.IsChecked = true;
                Number_Of_Sleep_Bouts_Dark.IsChecked = true;
                Number_Of_Sleep_Bouts_Light.IsChecked = true;
                Longest_Sleep_Bout_Length_Day.IsChecked = true;
                Longest_Sleep_Bout_Length_Dark.IsChecked = true;
                Longest_Sleep_Bout_Length_Light.IsChecked = true;
                Total_Activity_Level_Day.IsChecked = true;
                Total_Activity_Level_Dark.IsChecked = true;
                Total_Activity_Level_Light.IsChecked = true;
                Average_Activity_Bout_Length_Day.IsChecked = true;
                Average_Activity_Bout_Length_Dark.IsChecked = true;
                Average_Activity_Bout_Length_Light.IsChecked = true;
                Average_Sleep_Bout_Length_Day.IsChecked = true;
                Average_Sleep_Bout_Length_Dark.IsChecked = true;
                Average_Sleep_Bout_Length_Light.IsChecked = true;
            }
            else if (Daily_or_Hourly.SelectedIndex == 1)
            {
                Total_Activity_Hourly.IsChecked = true;
                Total_Sleep_Hourly.IsChecked = true;
                Number_Of_Sleep_Bouts_Hourly.IsChecked = true;
                Average_Sleep_Bout_Length_Hourly.IsChecked = true;
                Average_Activity_Bout_Length_Hourly.IsChecked = true;
                Total_Inactivity_Hourly.IsChecked = true;
                Total_Activity_Level_Hourly.IsChecked = true;
                Average_Activity_Level_Hourly.IsChecked = true;
            }
        }

        private void ClearAll_Click(object sender, RoutedEventArgs e)
        {
            if (Daily_or_Hourly.SelectedIndex == 0)
            {
                Total_Sleep_Day.IsChecked = false;
                Total_Sleep_Dark.IsChecked = false;
                Total_Sleep_Light.IsChecked = false;
                Total_Activity_Day.IsChecked = false;
                Total_Activity_Dark.IsChecked = false;
                Total_Activity_Light.IsChecked = false;
                Total_Inactivity_Day.IsChecked = false;
                Total_Inactivity_Dark.IsChecked = false;
                Total_Inactivity_Light.IsChecked = false;
                Number_Of_Sleep_Bouts_Day.IsChecked = false;
                Number_Of_Sleep_Bouts_Dark.IsChecked = false;
                Number_Of_Sleep_Bouts_Light.IsChecked = false;
                Longest_Sleep_Bout_Length_Day.IsChecked = false;
                Longest_Sleep_Bout_Length_Dark.IsChecked = false;
                Longest_Sleep_Bout_Length_Light.IsChecked = false;
                Total_Activity_Level_Day.IsChecked = false;
                Total_Activity_Level_Dark.IsChecked = false;
                Total_Activity_Level_Light.IsChecked = false;
                Average_Activity_Bout_Length_Day.IsChecked = false;
                Average_Activity_Bout_Length_Dark.IsChecked = false;
                Average_Activity_Bout_Length_Light.IsChecked = false;
                Average_Sleep_Bout_Length_Day.IsChecked = false;
                Average_Sleep_Bout_Length_Dark.IsChecked = false;
                Average_Sleep_Bout_Length_Light.IsChecked = false;
            }
            else if (Daily_or_Hourly.SelectedIndex == 1)
            {
                Total_Activity_Hourly.IsChecked = false;
                Total_Sleep_Hourly.IsChecked = false;
                Number_Of_Sleep_Bouts_Hourly.IsChecked = false;
                Average_Sleep_Bout_Length_Hourly.IsChecked = false;
                Average_Activity_Bout_Length_Hourly.IsChecked = false;
                Total_Inactivity_Hourly.IsChecked = false;
                Total_Activity_Level_Hourly.IsChecked = false;
                Average_Activity_Level_Hourly.IsChecked = false;
            }
        }
    }
}
