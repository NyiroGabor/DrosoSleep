using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DrosoSleep
{
    public static class Parameters
    {
        public static bool TotalSleepDay = true;
        public static bool TotalSleepDark = true;
        public static bool TotalSleepLight = true;
        public static bool TotalActivityDay = true;
        public static bool TotalActivityDark = true;
        public static bool TotalActivityLight = true;
        public static bool TotalInactivityDay = true;
        public static bool TotalInactivityDark = true;
        public static bool TotalInactivityLight = true;
        public static bool NumberOfSleepBoutsDay = true;
        public static bool NumberOfSleepBoutsDark = true;
        public static bool NumberOfSleepBoutsLight = true;
        public static bool LongestSleepBoutLengthDay = true;
        public static bool LongestSleepBoutLengthDark = true;
        public static bool LongestSleepBoutLengthLight = true;
        public static bool TotalActivityLevelDay = true;
        public static bool TotalActivityLevelDark = true;
        public static bool TotalActivityLevelLight = true;
        public static bool AverageActivityBoutLengthDay = true;
        public static bool AverageActivityBoutLengthDark = true;
        public static bool AverageActivityBoutLengthLight = true;
        public static bool AverageSleepBoutLengthDay = true;
        public static bool AverageSleepBoutLengthDark = true;
        public static bool AverageSleepBoutLengthLight = true;
        public static bool TotalActivityHourly = true;
        public static bool TotalSleepHourly = true;
        public static bool NumberOfSleepBoutsHourly = true;
        public static bool AverageSleepBoutLengthHourly = true;
        public static bool AverageActivityBoutLengthHourly = true;
        public static bool TotalInactivityHourly = true;
        public static bool TotalActivityLevelHourly = true;
        public static bool AverageActivityLevelHourly = true;

        private enum parameterType {Day, Hour }; //Meghatározza, hogy mi alapján kell a csoportokat feltölteni, ezáltal hogy a string[]-ben mennyi elem legyen (pl. Day esetén a napok számának megfelelő mennyiségű elem lesz egy-egy csoportnál)

        public static void Run(List<ResultParameter> Results, List<LoadedDAMFile> DAMFiles)
        {
            if (AverageActivityLevelHourly)
            {
                ResultParameter groupValuesForAllParametersHour = CreateGroupNumbersForParameters(DAMFiles, parameterType.Hour);
                groupValuesForAllParametersHour.Name = "AverageActivityLevelHourly";
                groupValuesForAllParametersHour.Unit = "(amount)";
                groupValuesForAllParametersHour = AverageActivityLevelHourlyCalculate(DAMFiles, groupValuesForAllParametersHour);
                Results.Add(groupValuesForAllParametersHour);
            }

            if (TotalActivityLevelHourly)
            {
                ResultParameter groupValuesForAllParametersHour = CreateGroupNumbersForParameters(DAMFiles, parameterType.Hour);
                groupValuesForAllParametersHour.Name = "TotalActivityLevelHourly";
                groupValuesForAllParametersHour.Unit = "(amount)";
                groupValuesForAllParametersHour = TotalActivityLevelHourlyCalculate(DAMFiles, groupValuesForAllParametersHour);
                Results.Add(groupValuesForAllParametersHour);
            }

            if (TotalInactivityHourly)
            {
                ResultParameter groupValuesForAllParametersHour = CreateGroupNumbersForParameters(DAMFiles, parameterType.Hour);
                groupValuesForAllParametersHour.Name = "TotalInactivityHourly";
                groupValuesForAllParametersHour.Unit = "(minute)";
                groupValuesForAllParametersHour = TotalInactivityHourlyCalculate(DAMFiles, groupValuesForAllParametersHour);
                Results.Add(groupValuesForAllParametersHour);
            }

            if (AverageActivityBoutLengthHourly)
            {
                ResultParameter groupValuesForAllParametersHour = CreateGroupNumbersForParameters(DAMFiles, parameterType.Hour);
                groupValuesForAllParametersHour.Name = "AverageActivityBoutLengthHourly";
                groupValuesForAllParametersHour.Unit = "(minute)";
                groupValuesForAllParametersHour = AverageActivityBoutLengthHourlyCalculate(DAMFiles, groupValuesForAllParametersHour);
                Results.Add(groupValuesForAllParametersHour);
            }

            if (AverageSleepBoutLengthHourly)
            {
                ResultParameter groupValuesForAllParametersHour = CreateGroupNumbersForParameters(DAMFiles, parameterType.Hour);
                groupValuesForAllParametersHour.Name = "AverageSleepBoutLengthHourly";
                groupValuesForAllParametersHour.Unit = "(minute)";
                groupValuesForAllParametersHour = AverageSleepBoutLengthHourlyCalculate(DAMFiles, groupValuesForAllParametersHour);
                Results.Add(groupValuesForAllParametersHour);
            }

            if (NumberOfSleepBoutsHourly)
            {
                ResultParameter groupValuesForAllParametersHour = CreateGroupNumbersForParameters(DAMFiles, parameterType.Hour);
                groupValuesForAllParametersHour.Name = "NumberOfSleepBoutsHourly";
                groupValuesForAllParametersHour.Unit = "(number)";
                groupValuesForAllParametersHour = NumberOfSleepBoutsHourlyCalculate(DAMFiles, groupValuesForAllParametersHour);
                Results.Add(groupValuesForAllParametersHour);
            }

            if (TotalActivityHourly)
            {
                ResultParameter groupValuesForAllParametersHour = CreateGroupNumbersForParameters(DAMFiles, parameterType.Hour);
                groupValuesForAllParametersHour.Name = "TotalActivityHourly";
                groupValuesForAllParametersHour.Unit = "(minute)";
                groupValuesForAllParametersHour = TotalActivityHourlyCalculate(DAMFiles, groupValuesForAllParametersHour);
                Results.Add(groupValuesForAllParametersHour);
            }

            if (TotalSleepHourly)
            {
                ResultParameter groupValuesForAllParametersHour = CreateGroupNumbersForParameters(DAMFiles, parameterType.Hour);
                groupValuesForAllParametersHour.Name = "TotalSleepHourly";
                groupValuesForAllParametersHour.Unit = "(minute)";
                groupValuesForAllParametersHour = TotalSleepHourlyCalculate(DAMFiles, groupValuesForAllParametersHour);
                Results.Add(groupValuesForAllParametersHour);
            }

            if (TotalInactivityLight)
            {
                ResultParameter groupValuesForAllParametersDay = CreateGroupNumbersForParameters(DAMFiles, parameterType.Day);
                groupValuesForAllParametersDay.Name = "TotalInactivityLight";
                groupValuesForAllParametersDay.Unit = "(minute)";
                groupValuesForAllParametersDay = TotalInactivityLightCalculate(DAMFiles, groupValuesForAllParametersDay);
                Results.Add(groupValuesForAllParametersDay);
            }

            if (TotalInactivityDark)
            {
                ResultParameter groupValuesForAllParametersDay = CreateGroupNumbersForParameters(DAMFiles, parameterType.Day);
                groupValuesForAllParametersDay.Name = "TotalInactivityDark";
                groupValuesForAllParametersDay.Unit = "(minute)";
                groupValuesForAllParametersDay = TotalInactivityDarkCalculate(DAMFiles, groupValuesForAllParametersDay);
                Results.Add(groupValuesForAllParametersDay);
            }

            if (TotalInactivityDay)
            {
                ResultParameter groupValuesForAllParametersDay = CreateGroupNumbersForParameters(DAMFiles, parameterType.Day);
                groupValuesForAllParametersDay.Name = "TotalInactivityDay";
                groupValuesForAllParametersDay.Unit = "(minute)";
                groupValuesForAllParametersDay = TotalInactivityDayCalculate(DAMFiles, groupValuesForAllParametersDay);
                Results.Add(groupValuesForAllParametersDay);
            }

            if (TotalActivityLevelLight)
            {
                ResultParameter groupValuesForAllParametersDay = CreateGroupNumbersForParameters(DAMFiles, parameterType.Day);
                groupValuesForAllParametersDay.Name = "TotalActivityLevelLight";
                groupValuesForAllParametersDay.Unit = "(amount)";
                groupValuesForAllParametersDay = TotalActivityLevelLightCalculate(DAMFiles, groupValuesForAllParametersDay);
                Results.Add(groupValuesForAllParametersDay);
            }

            if (TotalActivityLevelDark)
            {
                ResultParameter groupValuesForAllParametersDay = CreateGroupNumbersForParameters(DAMFiles, parameterType.Day);
                groupValuesForAllParametersDay.Name = "TotalActivityLevelDark";
                groupValuesForAllParametersDay.Unit = "(amount)";
                groupValuesForAllParametersDay = TotalActivityLevelDarkCalculate(DAMFiles, groupValuesForAllParametersDay);
                Results.Add(groupValuesForAllParametersDay);
            }

            if (TotalActivityLevelDay)
            {
                ResultParameter groupValuesForAllParametersDay = CreateGroupNumbersForParameters(DAMFiles, parameterType.Day);
                groupValuesForAllParametersDay.Name = "TotalActivityLevelDay";
                groupValuesForAllParametersDay.Unit = "(amount)";
                groupValuesForAllParametersDay = TotalActivityLevelDayCalculate(DAMFiles, groupValuesForAllParametersDay);
                Results.Add(groupValuesForAllParametersDay);
            }

            if (LongestSleepBoutLengthLight)
            {
                ResultParameter groupValuesForAllParametersDay = CreateGroupNumbersForParameters(DAMFiles, parameterType.Day);
                groupValuesForAllParametersDay.Name = "LongestSleepBoutLengthLight";
                groupValuesForAllParametersDay.Unit = "(minute)";
                groupValuesForAllParametersDay = LongestSleepBoutLengthLightCalculate(DAMFiles, groupValuesForAllParametersDay);
                Results.Add(groupValuesForAllParametersDay);
            }

            if (LongestSleepBoutLengthDark)
            {
                ResultParameter groupValuesForAllParametersDay = CreateGroupNumbersForParameters(DAMFiles, parameterType.Day);
                groupValuesForAllParametersDay.Name = "LongestSleepBoutLengthDark";
                groupValuesForAllParametersDay.Unit = "(minute)";
                groupValuesForAllParametersDay = LongestSleepBoutLengthDarkCalculate(DAMFiles, groupValuesForAllParametersDay);
                Results.Add(groupValuesForAllParametersDay);
            }

            if (LongestSleepBoutLengthDay)
            {
                ResultParameter groupValuesForAllParametersDay = CreateGroupNumbersForParameters(DAMFiles, parameterType.Day);
                groupValuesForAllParametersDay.Name = "LongestSleepBoutLengthDay";
                groupValuesForAllParametersDay.Unit = "(minute)";
                groupValuesForAllParametersDay = LongestSleepBoutLengthDayCalculate(DAMFiles, groupValuesForAllParametersDay);
                Results.Add(groupValuesForAllParametersDay);
            }

            if (AverageActivityBoutLengthLight)
            {
                ResultParameter groupValuesForAllParametersDay = CreateGroupNumbersForParameters(DAMFiles, parameterType.Day);
                groupValuesForAllParametersDay.Name = "AverageActivityBoutLengthLight";
                groupValuesForAllParametersDay.Unit = "(minute)";
                groupValuesForAllParametersDay = AverageActivityBoutLengthLightCalculate(DAMFiles, groupValuesForAllParametersDay);
                Results.Add(groupValuesForAllParametersDay);
            }

            if (AverageActivityBoutLengthDark)
            {
                ResultParameter groupValuesForAllParametersDay = CreateGroupNumbersForParameters(DAMFiles, parameterType.Day);
                groupValuesForAllParametersDay.Name = "AverageActivityBoutLengthDark";
                groupValuesForAllParametersDay.Unit = "(minute)";
                groupValuesForAllParametersDay = AverageActivityBoutLengthDarkCalculate(DAMFiles, groupValuesForAllParametersDay);
                Results.Add(groupValuesForAllParametersDay);
            }

            if (AverageActivityBoutLengthDay)
            {
                ResultParameter groupValuesForAllParametersDay = CreateGroupNumbersForParameters(DAMFiles, parameterType.Day);
                groupValuesForAllParametersDay.Name = "AverageActivityBoutLengthDay";
                groupValuesForAllParametersDay.Unit = "(minute)";
                groupValuesForAllParametersDay = AverageActivityBoutLengthDayCalculate(DAMFiles, groupValuesForAllParametersDay);
                Results.Add(groupValuesForAllParametersDay);
            }

            if (AverageSleepBoutLengthLight)
            {
                ResultParameter groupValuesForAllParametersDay = CreateGroupNumbersForParameters(DAMFiles, parameterType.Day);
                groupValuesForAllParametersDay.Name = "AverageSleepBoutLengthLight";
                groupValuesForAllParametersDay.Unit = "(minute)";
                groupValuesForAllParametersDay = AverageSleepBoutLengthLightCalculate(DAMFiles, groupValuesForAllParametersDay);
                Results.Add(groupValuesForAllParametersDay);
            }

            if (AverageSleepBoutLengthDark)
            {
                ResultParameter groupValuesForAllParametersDay = CreateGroupNumbersForParameters(DAMFiles, parameterType.Day);
                groupValuesForAllParametersDay.Name = "AverageSleepBoutLengthDark";
                groupValuesForAllParametersDay.Unit = "(minute)";
                groupValuesForAllParametersDay = AverageSleepBoutLengthDarkCalculate(DAMFiles, groupValuesForAllParametersDay);
                Results.Add(groupValuesForAllParametersDay);
            }

            if (AverageSleepBoutLengthDay)
            {
                ResultParameter groupValuesForAllParametersDay = CreateGroupNumbersForParameters(DAMFiles, parameterType.Day);
                groupValuesForAllParametersDay.Name = "AverageSleepBoutLengthDay";
                groupValuesForAllParametersDay.Unit = "(minute)";
                groupValuesForAllParametersDay = AverageSleepBoutLengthDayCalculate(DAMFiles, groupValuesForAllParametersDay);
                Results.Add(groupValuesForAllParametersDay);
            }

            if (NumberOfSleepBoutsLight)
            {
                ResultParameter groupValuesForAllParametersDay = CreateGroupNumbersForParameters(DAMFiles, parameterType.Day);
                groupValuesForAllParametersDay.Name = "NumberOfSleepBoutsLight";
                groupValuesForAllParametersDay.Unit = "(number)";
                groupValuesForAllParametersDay = NumberOfSleepBoutsLightCalculate(DAMFiles, groupValuesForAllParametersDay);
                Results.Add(groupValuesForAllParametersDay);
            }

            if (NumberOfSleepBoutsDark)
            {
                ResultParameter groupValuesForAllParametersDay = CreateGroupNumbersForParameters(DAMFiles, parameterType.Day);
                groupValuesForAllParametersDay.Name = "NumberOfSleepBoutsDark";
                groupValuesForAllParametersDay.Unit = "(number)";
                groupValuesForAllParametersDay = NumberOfSleepBoutsDarkCalculate(DAMFiles, groupValuesForAllParametersDay);
                Results.Add(groupValuesForAllParametersDay);
            }

            if (NumberOfSleepBoutsDay)
            {
                ResultParameter groupValuesForAllParametersDay = CreateGroupNumbersForParameters(DAMFiles, parameterType.Day);
                groupValuesForAllParametersDay.Name = "NumberOfSleepBoutsDay";
                groupValuesForAllParametersDay.Unit = "(number)";
                groupValuesForAllParametersDay = NumberOfSleepBoutsDayCalculate(DAMFiles, groupValuesForAllParametersDay);
                Results.Add(groupValuesForAllParametersDay);
            }

            if (TotalActivityLight)
            {
                ResultParameter groupValuesForAllParametersDay = CreateGroupNumbersForParameters(DAMFiles, parameterType.Day);
                groupValuesForAllParametersDay.Name = "TotalActivityLight";
                groupValuesForAllParametersDay.Unit = "(minutes)";
                groupValuesForAllParametersDay = TotalLightActivityDayCalculate(DAMFiles, groupValuesForAllParametersDay);
                Results.Add(groupValuesForAllParametersDay);
            }

            if (TotalActivityDark)
            {
                ResultParameter groupValuesForAllParametersDay = CreateGroupNumbersForParameters(DAMFiles, parameterType.Day);
                groupValuesForAllParametersDay.Name = "TotalActivityDark";
                groupValuesForAllParametersDay.Unit = "(minutes)";
                groupValuesForAllParametersDay = TotalDarkActivityDayCalculate(DAMFiles, groupValuesForAllParametersDay);
                Results.Add(groupValuesForAllParametersDay);
            }

            if (TotalActivityDay)
            {
                ResultParameter groupValuesForAllParametersDay = CreateGroupNumbersForParameters(DAMFiles, parameterType.Day);
                groupValuesForAllParametersDay.Name = "TotalActivityDay";
                groupValuesForAllParametersDay.Unit = "(minutes)";
                groupValuesForAllParametersDay = TotalActivityDayCalculate(DAMFiles, groupValuesForAllParametersDay);
                Results.Add(groupValuesForAllParametersDay);
            }

            if (TotalSleepLight)
            {
                ResultParameter groupValuesForAllParametersDay = CreateGroupNumbersForParameters(DAMFiles, parameterType.Day);
                groupValuesForAllParametersDay.Name = "TotalSleepLight";
                groupValuesForAllParametersDay.Unit = "(minutes)";
                groupValuesForAllParametersDay = TotalLightSleepCalculate(DAMFiles, groupValuesForAllParametersDay);
                Results.Add(groupValuesForAllParametersDay);
            }

            if (TotalSleepDark)
            {
                ResultParameter groupValuesForAllParametersDay = CreateGroupNumbersForParameters(DAMFiles, parameterType.Day);
                groupValuesForAllParametersDay.Name = "TotalSleepDark";
                groupValuesForAllParametersDay.Unit = "(minutes)";
                groupValuesForAllParametersDay = TotalDarkSleepCalculate(DAMFiles, groupValuesForAllParametersDay);
                Results.Add(groupValuesForAllParametersDay);
            }

            if (TotalSleepDay)
            {
                ResultParameter groupValuesForAllParametersDay = CreateGroupNumbersForParameters(DAMFiles, parameterType.Day); //Átlagosan tartalmazza a csoportokat azokhoz a paraméterekhez, amik napi lebontásban számolnak
                groupValuesForAllParametersDay.Name = "TotalSleepDay";
                groupValuesForAllParametersDay.Unit = "(minutes)";
                groupValuesForAllParametersDay = TotalSleepDayCalculate(DAMFiles, groupValuesForAllParametersDay);
                Results.Add(groupValuesForAllParametersDay);
            }

        }

        private static ResultParameter CreateGroupNumbersForParameters(List<LoadedDAMFile> DAMFiles, parameterType type)
        {
            ResultParameter groupValuesForAllParameters = new ResultParameter(); //A csoportok beosztása minden paraméter számításánál pontosan ugyan az, ezért azt elég csak egyszer meghatározni. Ezzel felül lesz írva a megoldások listája, így minden paraméter ugyan azt a csoport felosztást fogja birtokolni.
            for (int i = 0; i < DAMFiles.Count; i++) //Végigmegy a DAM fájlokon
            {
                for (int j = 0; j < DAMFiles[i].GroupTableValues.Length; j++) //Megnézi az adott DAM fájlhoz elmentett csoport listát
                {
                    if (DAMFiles[i].GroupTableValues[j] != "") //Ha nem üresen hagyott a csoport rublikája a csoportok megadásánál, akkor menti el a csoportot
                    {
                        int index = 0;
                        while (index < groupValuesForAllParameters.Groups.Count && DAMFiles[i].GroupTableValues[j] != groupValuesForAllParameters.Groups[index].GetName())
                        { //Ha nem ért a paraméterekhez tartozó csoportok listájának a végére, akkor megnézi, hogy benne van-e már ez a csoport. Ha nincs, akkor nézi a következő elemet és a végén hozzáadja új csoportként, ha egyáltalán nincs. Ha benne van, akkor ahhoz a csoporthoz hozzáad egy újabb elemet.
                            index++;
                        }
                        if (index < groupValuesForAllParameters.Groups.Count) //Ha van már ilyen csoport
                        {
                            if (type == parameterType.Day)
                            {
                                groupValuesForAllParameters.Groups[index].ResultsForFlies.Add(new string[TimeValues.NumberOfDays]);
                            }
                            else if(type == parameterType.Hour)
                            {
                                groupValuesForAllParameters.Groups[index].ResultsForFlies.Add(new string[TimeValues.NumberOfHours]);
                            }
                        }
                        else //Ha nincs még ilyen csoport
                        {
                            if (type == parameterType.Day)
                            {
                                groupValuesForAllParameters.Groups.Add(new Group(DAMFiles[i].GroupTableValues[j], TimeValues.NumberOfDays));
                            }
                            else if(type == parameterType.Hour)
                            {
                                groupValuesForAllParameters.Groups.Add(new Group(DAMFiles[i].GroupTableValues[j], TimeValues.NumberOfHours));
                            }
                        }
                    }
                }
            }
            groupValuesForAllParameters.Groups.Sort(delegate (Group x, Group y)
            {
                string xName = x.GetName();
                return xName.CompareTo(y.GetName());
            });
            return groupValuesForAllParameters;
        }

        private static ResultParameter TotalSleepDayCalculate(List<LoadedDAMFile> DAMFiles, ResultParameter templateResultParameter)
        { //A templateResultParameter-en lesz minden számítás elvégezve és ez lesz a Results-hoz hozzáadva a végén, mert ez már tartalmazza a megfelelő csoportokat. Minden paraméter számításnál ugyan az a csoport elrendezés, így ezt az egy változót lehet mindenhol alkalmazni. Nem referencia változó, tehát minden paraméter számítás külön tudja alkalmazni.

            return CalculateSleepParametersDAY(DAMFiles, templateResultParameter, true, true, false, false, false, false);
                        
        }

        private static ResultParameter TotalDarkSleepCalculate(List<LoadedDAMFile> DAMFiles, ResultParameter templateResultParameter)
        { //A templateResultParameter-en lesz minden számítás elvégezve és ez lesz a Results-hoz hozzáadva a végén, mert ez már tartalmazza a megfelelő csoportokat. Minden paraméter számításnál ugyan az a csoport elrendezés, így ezt az egy változót lehet mindenhol alkalmazni. Nem referencia változó, tehát minden paraméter számítás külön tudja alkalmazni.

            return CalculateSleepParametersDAY(DAMFiles, templateResultParameter, true, false, false, false, false, false);
                        
        }

        private static ResultParameter TotalLightSleepCalculate(List<LoadedDAMFile> DAMFiles, ResultParameter templateResultParameter)
        { //A templateResultParameter-en lesz minden számítás elvégezve és ez lesz a Results-hoz hozzáadva a végén, mert ez már tartalmazza a megfelelő csoportokat. Minden paraméter számításnál ugyan az a csoport elrendezés, így ezt az egy változót lehet mindenhol alkalmazni. Nem referencia változó, tehát minden paraméter számítás külön tudja alkalmazni.

            return CalculateSleepParametersDAY(DAMFiles, templateResultParameter, false, true, false, false, false, false);
                        
        }

        private static ResultParameter TotalActivityDayCalculate(List<LoadedDAMFile> DAMFiles, ResultParameter templateResultParameter)
        { //A templateResultParameter-en lesz minden számítás elvégezve és ez lesz a Results-hoz hozzáadva a végén, mert ez már tartalmazza a megfelelő csoportokat. Minden paraméter számításnál ugyan az a csoport elrendezés, így ezt az egy változót lehet mindenhol alkalmazni. Nem referencia változó, tehát minden paraméter számítás külön tudja alkalmazni.

            return CalculateActivityParametersDAY(DAMFiles, templateResultParameter, true, true, false, false);

        }

        private static ResultParameter TotalDarkActivityDayCalculate(List<LoadedDAMFile> DAMFiles, ResultParameter templateResultParameter)
        { //A templateResultParameter-en lesz minden számítás elvégezve és ez lesz a Results-hoz hozzáadva a végén, mert ez már tartalmazza a megfelelő csoportokat. Minden paraméter számításnál ugyan az a csoport elrendezés, így ezt az egy változót lehet mindenhol alkalmazni. Nem referencia változó, tehát minden paraméter számítás külön tudja alkalmazni.

            return CalculateActivityParametersDAY(DAMFiles, templateResultParameter, true, false, false, false);

        }

        private static ResultParameter TotalLightActivityDayCalculate(List<LoadedDAMFile> DAMFiles, ResultParameter templateResultParameter)
        { //A templateResultParameter-en lesz minden számítás elvégezve és ez lesz a Results-hoz hozzáadva a végén, mert ez már tartalmazza a megfelelő csoportokat. Minden paraméter számításnál ugyan az a csoport elrendezés, így ezt az egy változót lehet mindenhol alkalmazni. Nem referencia változó, tehát minden paraméter számítás külön tudja alkalmazni.

            return CalculateActivityParametersDAY(DAMFiles, templateResultParameter, false, true, false, false);

        }

        private static ResultParameter NumberOfSleepBoutsDayCalculate(List<LoadedDAMFile> DAMFiles, ResultParameter templateResultParameter)
        { //A templateResultParameter-en lesz minden számítás elvégezve és ez lesz a Results-hoz hozzáadva a végén, mert ez már tartalmazza a megfelelő csoportokat. Minden paraméter számításnál ugyan az a csoport elrendezés, így ezt az egy változót lehet mindenhol alkalmazni. Nem referencia változó, tehát minden paraméter számítás külön tudja alkalmazni.

            return CalculateSleepParametersDAY(DAMFiles, templateResultParameter, true, true, true, false, false, false);

        }

        private static ResultParameter NumberOfSleepBoutsDarkCalculate(List<LoadedDAMFile> DAMFiles, ResultParameter templateResultParameter)
        { //A templateResultParameter-en lesz minden számítás elvégezve és ez lesz a Results-hoz hozzáadva a végén, mert ez már tartalmazza a megfelelő csoportokat. Minden paraméter számításnál ugyan az a csoport elrendezés, így ezt az egy változót lehet mindenhol alkalmazni. Nem referencia változó, tehát minden paraméter számítás külön tudja alkalmazni.

            return CalculateSleepParametersDAY(DAMFiles, templateResultParameter, true, false, true, false, false, false);

        }

        private static ResultParameter NumberOfSleepBoutsLightCalculate(List<LoadedDAMFile> DAMFiles, ResultParameter templateResultParameter)
        { //A templateResultParameter-en lesz minden számítás elvégezve és ez lesz a Results-hoz hozzáadva a végén, mert ez már tartalmazza a megfelelő csoportokat. Minden paraméter számításnál ugyan az a csoport elrendezés, így ezt az egy változót lehet mindenhol alkalmazni. Nem referencia változó, tehát minden paraméter számítás külön tudja alkalmazni.

            return CalculateSleepParametersDAY(DAMFiles, templateResultParameter, false, true, true, false, false, false);

        }

        private static ResultParameter AverageSleepBoutLengthDayCalculate(List<LoadedDAMFile> DAMFiles, ResultParameter templateResultParameter)
        { //A templateResultParameter-en lesz minden számítás elvégezve és ez lesz a Results-hoz hozzáadva a végén, mert ez már tartalmazza a megfelelő csoportokat. Minden paraméter számításnál ugyan az a csoport elrendezés, így ezt az egy változót lehet mindenhol alkalmazni. Nem referencia változó, tehát minden paraméter számítás külön tudja alkalmazni.

            return CalculateSleepParametersDAY(DAMFiles, templateResultParameter, true, true, false, true, false, false);

        }

        private static ResultParameter AverageSleepBoutLengthDarkCalculate(List<LoadedDAMFile> DAMFiles, ResultParameter templateResultParameter)
        { //A templateResultParameter-en lesz minden számítás elvégezve és ez lesz a Results-hoz hozzáadva a végén, mert ez már tartalmazza a megfelelő csoportokat. Minden paraméter számításnál ugyan az a csoport elrendezés, így ezt az egy változót lehet mindenhol alkalmazni. Nem referencia változó, tehát minden paraméter számítás külön tudja alkalmazni.

            return CalculateSleepParametersDAY(DAMFiles, templateResultParameter, true, false, false, true, false, false);

        }

        private static ResultParameter AverageSleepBoutLengthLightCalculate(List<LoadedDAMFile> DAMFiles, ResultParameter templateResultParameter)
        { //A templateResultParameter-en lesz minden számítás elvégezve és ez lesz a Results-hoz hozzáadva a végén, mert ez már tartalmazza a megfelelő csoportokat. Minden paraméter számításnál ugyan az a csoport elrendezés, így ezt az egy változót lehet mindenhol alkalmazni. Nem referencia változó, tehát minden paraméter számítás külön tudja alkalmazni.

            return CalculateSleepParametersDAY(DAMFiles, templateResultParameter, false, true, false, true, false, false);

        }

        private static ResultParameter AverageActivityBoutLengthDayCalculate(List<LoadedDAMFile> DAMFiles, ResultParameter templateResultParameter)
        { //A templateResultParameter-en lesz minden számítás elvégezve és ez lesz a Results-hoz hozzáadva a végén, mert ez már tartalmazza a megfelelő csoportokat. Minden paraméter számításnál ugyan az a csoport elrendezés, így ezt az egy változót lehet mindenhol alkalmazni. Nem referencia változó, tehát minden paraméter számítás külön tudja alkalmazni.

            return CalculateActivityParametersDAY(DAMFiles, templateResultParameter, true, true, true, false);

        }

        private static ResultParameter AverageActivityBoutLengthDarkCalculate(List<LoadedDAMFile> DAMFiles, ResultParameter templateResultParameter)
        { //A templateResultParameter-en lesz minden számítás elvégezve és ez lesz a Results-hoz hozzáadva a végén, mert ez már tartalmazza a megfelelő csoportokat. Minden paraméter számításnál ugyan az a csoport elrendezés, így ezt az egy változót lehet mindenhol alkalmazni. Nem referencia változó, tehát minden paraméter számítás külön tudja alkalmazni.

            return CalculateActivityParametersDAY(DAMFiles, templateResultParameter, true, false, true, false);

        }

        private static ResultParameter AverageActivityBoutLengthLightCalculate(List<LoadedDAMFile> DAMFiles, ResultParameter templateResultParameter)
        { //A templateResultParameter-en lesz minden számítás elvégezve és ez lesz a Results-hoz hozzáadva a végén, mert ez már tartalmazza a megfelelő csoportokat. Minden paraméter számításnál ugyan az a csoport elrendezés, így ezt az egy változót lehet mindenhol alkalmazni. Nem referencia változó, tehát minden paraméter számítás külön tudja alkalmazni.

            return CalculateActivityParametersDAY(DAMFiles, templateResultParameter, false, true, true, false);

        }

        private static ResultParameter LongestSleepBoutLengthDayCalculate(List<LoadedDAMFile> DAMFiles, ResultParameter templateResultParameter)
        { //A templateResultParameter-en lesz minden számítás elvégezve és ez lesz a Results-hoz hozzáadva a végén, mert ez már tartalmazza a megfelelő csoportokat. Minden paraméter számításnál ugyan az a csoport elrendezés, így ezt az egy változót lehet mindenhol alkalmazni. Nem referencia változó, tehát minden paraméter számítás külön tudja alkalmazni.

            return CalculateSleepParametersDAY(DAMFiles, templateResultParameter,true, true, false, false, true, false);

        }

        private static ResultParameter LongestSleepBoutLengthDarkCalculate(List<LoadedDAMFile> DAMFiles, ResultParameter templateResultParameter)
        { //A templateResultParameter-en lesz minden számítás elvégezve és ez lesz a Results-hoz hozzáadva a végén, mert ez már tartalmazza a megfelelő csoportokat. Minden paraméter számításnál ugyan az a csoport elrendezés, így ezt az egy változót lehet mindenhol alkalmazni. Nem referencia változó, tehát minden paraméter számítás külön tudja alkalmazni.

            return CalculateSleepParametersDAY(DAMFiles, templateResultParameter, true, false, false, false, true, false);

        }

        private static ResultParameter LongestSleepBoutLengthLightCalculate(List<LoadedDAMFile> DAMFiles, ResultParameter templateResultParameter)
        { //A templateResultParameter-en lesz minden számítás elvégezve és ez lesz a Results-hoz hozzáadva a végén, mert ez már tartalmazza a megfelelő csoportokat. Minden paraméter számításnál ugyan az a csoport elrendezés, így ezt az egy változót lehet mindenhol alkalmazni. Nem referencia változó, tehát minden paraméter számítás külön tudja alkalmazni.

            return CalculateSleepParametersDAY(DAMFiles, templateResultParameter, false, true, false, false, true, false);

        }

        private static ResultParameter TotalActivityLevelDayCalculate(List<LoadedDAMFile> DAMFiles, ResultParameter templateResultParameter)
        { //A templateResultParameter-en lesz minden számítás elvégezve és ez lesz a Results-hoz hozzáadva a végén, mert ez már tartalmazza a megfelelő csoportokat. Minden paraméter számításnál ugyan az a csoport elrendezés, így ezt az egy változót lehet mindenhol alkalmazni. Nem referencia változó, tehát minden paraméter számítás külön tudja alkalmazni.

            return CalculateActivityParametersDAY(DAMFiles, templateResultParameter, true, true, false, true);

        }

        private static ResultParameter TotalActivityLevelDarkCalculate(List<LoadedDAMFile> DAMFiles, ResultParameter templateResultParameter)
        { //A templateResultParameter-en lesz minden számítás elvégezve és ez lesz a Results-hoz hozzáadva a végén, mert ez már tartalmazza a megfelelő csoportokat. Minden paraméter számításnál ugyan az a csoport elrendezés, így ezt az egy változót lehet mindenhol alkalmazni. Nem referencia változó, tehát minden paraméter számítás külön tudja alkalmazni.

            return CalculateActivityParametersDAY(DAMFiles, templateResultParameter, true, false, false, true);

        }

        private static ResultParameter TotalActivityLevelLightCalculate(List<LoadedDAMFile> DAMFiles, ResultParameter templateResultParameter)
        { //A templateResultParameter-en lesz minden számítás elvégezve és ez lesz a Results-hoz hozzáadva a végén, mert ez már tartalmazza a megfelelő csoportokat. Minden paraméter számításnál ugyan az a csoport elrendezés, így ezt az egy változót lehet mindenhol alkalmazni. Nem referencia változó, tehát minden paraméter számítás külön tudja alkalmazni.

            return CalculateActivityParametersDAY(DAMFiles, templateResultParameter, false, true, false, true);

        }

        private static ResultParameter TotalInactivityDayCalculate(List<LoadedDAMFile> DAMFiles, ResultParameter templateResultParameter)
        { //A templateResultParameter-en lesz minden számítás elvégezve és ez lesz a Results-hoz hozzáadva a végén, mert ez már tartalmazza a megfelelő csoportokat. Minden paraméter számításnál ugyan az a csoport elrendezés, így ezt az egy változót lehet mindenhol alkalmazni. Nem referencia változó, tehát minden paraméter számítás külön tudja alkalmazni.

            return CalculateSleepParametersDAY(DAMFiles, templateResultParameter, true, true, false, false, false, true);

        }

        private static ResultParameter TotalInactivityDarkCalculate(List<LoadedDAMFile> DAMFiles, ResultParameter templateResultParameter)
        { //A templateResultParameter-en lesz minden számítás elvégezve és ez lesz a Results-hoz hozzáadva a végén, mert ez már tartalmazza a megfelelő csoportokat. Minden paraméter számításnál ugyan az a csoport elrendezés, így ezt az egy változót lehet mindenhol alkalmazni. Nem referencia változó, tehát minden paraméter számítás külön tudja alkalmazni.

            return CalculateSleepParametersDAY(DAMFiles, templateResultParameter, true, false, false, false, false, true);

        }

        private static ResultParameter TotalInactivityLightCalculate(List<LoadedDAMFile> DAMFiles, ResultParameter templateResultParameter)
        { //A templateResultParameter-en lesz minden számítás elvégezve és ez lesz a Results-hoz hozzáadva a végén, mert ez már tartalmazza a megfelelő csoportokat. Minden paraméter számításnál ugyan az a csoport elrendezés, így ezt az egy változót lehet mindenhol alkalmazni. Nem referencia változó, tehát minden paraméter számítás külön tudja alkalmazni.

            return CalculateSleepParametersDAY(DAMFiles, templateResultParameter, false, true, false, false, false, true);

        }

        private static ResultParameter TotalSleepHourlyCalculate(List<LoadedDAMFile> DAMFiles, ResultParameter templateResultParameter)
        { //A templateResultParameter-en lesz minden számítás elvégezve és ez lesz a Results-hoz hozzáadva a végén, mert ez már tartalmazza a megfelelő csoportokat. Minden paraméter számításnál ugyan az a csoport elrendezés, így ezt az egy változót lehet mindenhol alkalmazni. Nem referencia változó, tehát minden paraméter számítás külön tudja alkalmazni.

            return CalculateSleepParametersHOUR(DAMFiles, templateResultParameter, false, false, false);

        }

        private static ResultParameter TotalActivityHourlyCalculate(List<LoadedDAMFile> DAMFiles, ResultParameter templateResultParameter)
        { //A templateResultParameter-en lesz minden számítás elvégezve és ez lesz a Results-hoz hozzáadva a végén, mert ez már tartalmazza a megfelelő csoportokat. Minden paraméter számításnál ugyan az a csoport elrendezés, így ezt az egy változót lehet mindenhol alkalmazni. Nem referencia változó, tehát minden paraméter számítás külön tudja alkalmazni.

            return CalculateActivityParametersHOUR(DAMFiles, templateResultParameter, false, false, false);

        }

        private static ResultParameter NumberOfSleepBoutsHourlyCalculate(List<LoadedDAMFile> DAMFiles, ResultParameter templateResultParameter)
        { //A templateResultParameter-en lesz minden számítás elvégezve és ez lesz a Results-hoz hozzáadva a végén, mert ez már tartalmazza a megfelelő csoportokat. Minden paraméter számításnál ugyan az a csoport elrendezés, így ezt az egy változót lehet mindenhol alkalmazni. Nem referencia változó, tehát minden paraméter számítás külön tudja alkalmazni.

            return CalculateSleepParametersHOUR(DAMFiles, templateResultParameter, true, false, false);

        }

        private static ResultParameter AverageSleepBoutLengthHourlyCalculate(List<LoadedDAMFile> DAMFiles, ResultParameter templateResultParameter)
        { //A templateResultParameter-en lesz minden számítás elvégezve és ez lesz a Results-hoz hozzáadva a végén, mert ez már tartalmazza a megfelelő csoportokat. Minden paraméter számításnál ugyan az a csoport elrendezés, így ezt az egy változót lehet mindenhol alkalmazni. Nem referencia változó, tehát minden paraméter számítás külön tudja alkalmazni.

            return CalculateSleepParametersHOUR(DAMFiles, templateResultParameter, false, true, false);

        }

        private static ResultParameter AverageActivityBoutLengthHourlyCalculate(List<LoadedDAMFile> DAMFiles, ResultParameter templateResultParameter)
        { //A templateResultParameter-en lesz minden számítás elvégezve és ez lesz a Results-hoz hozzáadva a végén, mert ez már tartalmazza a megfelelő csoportokat. Minden paraméter számításnál ugyan az a csoport elrendezés, így ezt az egy változót lehet mindenhol alkalmazni. Nem referencia változó, tehát minden paraméter számítás külön tudja alkalmazni.

            return CalculateActivityParametersHOUR(DAMFiles, templateResultParameter, true, false, false);

        }

        private static ResultParameter TotalInactivityHourlyCalculate(List<LoadedDAMFile> DAMFiles, ResultParameter templateResultParameter)
        { //A templateResultParameter-en lesz minden számítás elvégezve és ez lesz a Results-hoz hozzáadva a végén, mert ez már tartalmazza a megfelelő csoportokat. Minden paraméter számításnál ugyan az a csoport elrendezés, így ezt az egy változót lehet mindenhol alkalmazni. Nem referencia változó, tehát minden paraméter számítás külön tudja alkalmazni.

            return CalculateSleepParametersHOUR(DAMFiles, templateResultParameter, false, false, true);

        }

        private static ResultParameter TotalActivityLevelHourlyCalculate(List<LoadedDAMFile> DAMFiles, ResultParameter templateResultParameter)
        { //A templateResultParameter-en lesz minden számítás elvégezve és ez lesz a Results-hoz hozzáadva a végén, mert ez már tartalmazza a megfelelő csoportokat. Minden paraméter számításnál ugyan az a csoport elrendezés, így ezt az egy változót lehet mindenhol alkalmazni. Nem referencia változó, tehát minden paraméter számítás külön tudja alkalmazni.

            return CalculateActivityParametersHOUR(DAMFiles, templateResultParameter, false, true, false);

        }

        private static ResultParameter AverageActivityLevelHourlyCalculate(List<LoadedDAMFile> DAMFiles, ResultParameter templateResultParameter)
        { //A templateResultParameter-en lesz minden számítás elvégezve és ez lesz a Results-hoz hozzáadva a végén, mert ez már tartalmazza a megfelelő csoportokat. Minden paraméter számításnál ugyan az a csoport elrendezés, így ezt az egy változót lehet mindenhol alkalmazni. Nem referencia változó, tehát minden paraméter számítás külön tudja alkalmazni.

            return CalculateActivityParametersHOUR(DAMFiles, templateResultParameter, false, false, true);

        }



        private static ResultParameter CalculateSleepParametersDAY(List<LoadedDAMFile> DAMFiles, ResultParameter templateResultParameter, bool Dark, bool Light, bool BoutNumber, bool AverageBoutLength, bool LongestSleepBout, bool TotalInactivity)
        {

            for (int i = 0; i < DAMFiles.Count; i++)
            {
                int index = 10; //A DAM fájlban a muslicák oszlopának meghatározása. Ez az érték 10-től nő 41-ig, mert 42 oszlopa van a DAM fájlnak. A 42 értéke konstansként szerepel a TimeValues-ban.

                while (index < TimeValues.ColumnsOfDAM)
                {
                    int groupIndexInResults = templateResultParameter.Groups.FindIndex(x => x.GetName() == DAMFiles[i].GroupTableValues[index - 10]);
                    //DAMFiles[i].GroupTableValues[index - 10];  Ez konkrétan a string értéket adja vissza a csoporthoz, tehát a csoport nevét a táblázatból, ami a beviteli mező volt a csoportokhoz

                    if (groupIndexInResults != -1) //Ez azért kell, mert ha a csoport táblázatban a DAM-ok megadásánál üresen hagyta a felhasználó a mezőt, akkor ez az érték -1 lesz. Ha ez az érték -1, akkor azt a csoportot ne vegye figyelembe a rendszer a táblázatból.
                    {

                        int sumFly = 0; //Az alvónak számító muslicák darabszáma, ez lesz a végeredmény az egyes napokra.
                        int sumBoutNumber = 0; //Az alvás szakaszok lesznek hozzáadva, azok darabszámát tartalmazza.
                        int maxSleepBout = 0; //Az alvás hosszak közül a leghosszabbat írja ki a Longest Sleep Bout Length-hez.
                        int sumInactivity = 0; //Az inaktív sorokat számolja végig, függetlenül attól, hogy alvásnak számít-e vagy sem.

                        bool isSleepFromLastDay = false; //Két nap váltása között ha összesen van egy alvásnyi inaktivitás, akkor ez a változó true lesz. Ennek köszönhetően a következő napban ha nincs egy alvásnyi inaktivitás, akkor is alvásnak tekinti.

                        int isSleepingDarkLight = 0; //Ugyan azt számolja, mint az isSleeping, csak megáll mikor sötét/világos váltás jön, hogy ha alvásnak számít az inaktivitás mértéke, akkor a megfelelő értéket adja hozzá az egészhez
                                                     //Ez azt jelenti, hogy ha 4 inaktív érték megy sötétben és a sötétet nézzük, majd a 5. világosban, utána egy aktív jön világosban, akkor csak a 4 sötétet adja az egészhez, a +1 világosat ne.
                        int isSleeping = 0; //Ebben számolja, hogy hány db muslica inaktív egy huzamban. Ha ez az érték eléri az alvónak számító összeget, akkor onnantól a következő aktív értékig számítva ezt hozzáadja a sum-hoz.
                                            //Mindamellett ha ez az érték eléri a halottnak nyíilvánítást, akkor a válasznak megfelelően kezeli a muslicát
                        int isDead = 0; //Ebben számolja, hogy mikor lesz halott a muslica.
                        int currentDayNumber = 0; //Ebben van számolva, hogy hanyadik napnál tartunk jelenleg.

                        for (int j = TimeValues.WholeHourRow; j <= TimeValues.LastRowOfDays - 1; j++)
                        {
                            int currentFly = int.Parse(DAMFiles[i].LoadedDAMValues[j][index]);
                            if (currentFly != -1) //Akkor -1, ha volt egy hibás elem a fájl beolvasásánál. Azt az elemet egyszerűen átugorja a rendszer és nem veszi figyelembe
                            {

                                if (currentFly <= ExperimentSettingsValues.Treshold) //Inaktív-e
                                {
                                    if ((Dark && DAMFiles[i].LoadedDAMValues[j][9] == "0") || (Light && DAMFiles[i].LoadedDAMValues[j][9] == "1"))
                                    {
                                        sumInactivity++;
                                        isSleepingDarkLight++;
                                    }
                                    isSleeping++;
                                }
                                else
                                {
                                    if (isSleeping >= ExperimentSettingsValues.Sleep || isSleepFromLastDay) //Elég ideje inaktív-e az alváshoz, vagy az előző nap utolsó értékei alapján alvásnak számított az eddigi inaktív időszak is.
                                    {
                                        sumFly += isSleepingDarkLight;
                                        if(isSleepingDarkLight != 0) //Ez azt jelenti, hogy az inaktív szakasz alvásnak minősült és volt benne sötét/világos, ami számunkra érdekes, ezért azt mindenképp be kell számolni, mint sleep bout.
                                        {
                                            sumBoutNumber++;
                                        }
                                        if (isSleepingDarkLight > maxSleepBout) //Itt választja ki a leghosszabb alvás szakaszt.
                                        {
                                            maxSleepBout = isSleepingDarkLight;
                                        }
                                    }
                                    else if(isSleeping < ExperimentSettingsValues.Sleep) //Ha nem elég ideje inaktív az alváshoz, akkor aktívnak számított azidő alatt, ami mint az activity paramétereknél is, úgy a halott figyelésnél is hozzáadódik a sima aktív értékekhez.
                                    {
                                        isDead += isSleeping;
                                    }

                                    isSleeping = 0;
                                    isSleepingDarkLight = 0;
                                    isSleepFromLastDay = false;
                                    isDead++;
                                }

                                if (j != TimeValues.WholeHourRow && (j - TimeValues.WholeHourRow + 1) % TimeValues.NumberOfRowsInADay == 0)
                                {
                                    if (isDead < ExperimentSettingsValues.Dead) //Halottnak nyilvánítás
                                    {
                                        templateResultParameter.Groups[groupIndexInResults].ResultsForFlies[templateResultParameter.Groups[groupIndexInResults].NumberOfThisGroup][currentDayNumber] = "DEAD";
                                        j = TimeValues.LastRowOfDays - 1; //Azért kell ide -1 és a sorokon végigmenetel vizsgálatához is -1 mert itt lent a WholeHourRow-nál +1 van. Annak érdekében, hogy a következő egész órákat ne az előző egész órához számolja be.
                                    }
                                    else
                                    {
                                        int nextDayRow = 0; //Ezzel az értékkel megy a következő nap sorain addig, amíg nem lesz elég inaktivitás az alváshoz, vagy amíg nem talál egy aktív értéket.

                                        while (int.Parse(DAMFiles[i].LoadedDAMValues[j + nextDayRow][index]) <= ExperimentSettingsValues.Treshold && isSleeping + nextDayRow < ExperimentSettingsValues.Sleep)
                                        {
                                            nextDayRow++;
                                        }

                                        if (int.Parse(DAMFiles[i].LoadedDAMValues[j + nextDayRow][index]) <= ExperimentSettingsValues.Treshold)
                                        {
                                            sumFly += isSleepingDarkLight;
                                            if (isSleepingDarkLight != 0) //Ez azt jelenti, hogy az inaktív szakasz alvásnak minősült és volt benne sötét/világos, ami számunkra érdekes, ezért azt mindenképp be kell számolni, mint sleep bout.
                                            {
                                                sumBoutNumber++;
                                            }
                                            if (isSleepingDarkLight > maxSleepBout) //Itt választja ki a leghosszabb alvás szakaszt.
                                            {
                                                maxSleepBout = isSleepingDarkLight;
                                            }
                                            isSleepFromLastDay = true;
                                        }

                                        sumFly *= ExperimentSettingsValues.BinLength;
                                        string finalValue = ""; //Ezt írja be majd értéknek az eredményekhez, azért van rá szükség, hogy szebb legyen a kód.
                                        try
                                        {
                                            if (BoutNumber)
                                            {
                                                finalValue = sumBoutNumber.ToString();
                                            }
                                            else if (AverageBoutLength)
                                            {
                                                finalValue = (sumFly / sumBoutNumber).ToString();
                                            }
                                            else if (LongestSleepBout)
                                            {
                                                finalValue = maxSleepBout.ToString();
                                            }
                                            else if (TotalInactivity)
                                            {
                                                finalValue = sumInactivity.ToString();
                                            }
                                            else
                                            {
                                                finalValue = sumFly.ToString();
                                            }
                                        }
                                        catch (DivideByZeroException e)
                                        {
                                            finalValue = "0";
                                        }
                                        templateResultParameter.Groups[groupIndexInResults].ResultsForFlies[templateResultParameter.Groups[groupIndexInResults].NumberOfThisGroup][currentDayNumber] = finalValue;
                                    }
                                    currentDayNumber++;
                                    sumFly = 0;
                                    sumBoutNumber = 0;
                                    maxSleepBout = 0;
                                    sumInactivity = 0;
                                    isSleeping = 0;
                                    isSleepingDarkLight = 0;
                                    isDead = 0;
                                }

                            }

                        }

                        templateResultParameter.Groups[groupIndexInResults].NumberOfThisGroup++;
                    }
                    index++;

                }

            }

            return templateResultParameter;
        }

        private static ResultParameter CalculateActivityParametersDAY(List<LoadedDAMFile> DAMFiles, ResultParameter templateResultParameter, bool Dark, bool Light, bool AverageBoutLength, bool TotalActivityLevel)
        {

            for (int i = 0; i < DAMFiles.Count; i++)
            {
                int index = 10; //A DAM fájlban a muslicák oszlopának meghatározása. Ez az érték 10-től nő 41-ig, mert 42 oszlopa van a DAM fájlnak. A 42 értéke konstansként szerepel a TimeValues-ban.

                while (index < TimeValues.ColumnsOfDAM)
                {
                    int groupIndexInResults = templateResultParameter.Groups.FindIndex(x => x.GetName() == DAMFiles[i].GroupTableValues[index - 10]);
                    //DAMFiles[i].GroupTableValues[index - 10];  Ez konkrétan a string értéket adja vissza a csoporthoz, tehát a csoport nevét a táblázatból, ami a beviteli mező volt a csoportokhoz

                    if (groupIndexInResults != -1) //Ez azért kell, mert ha a csoport táblázatban a DAM-ok megadásánál üresen hagyta a felhasználó a mezőt, akkor ez az érték -1 lesz. Ha ez az érték -1, akkor azt a csoportot ne vegye figyelembe a rendszer a táblázatból.
                    {

                        int sumFly = 0; //Az aktívnak számító muslicák darabszáma, ez lesz a végeredmény az egyes napokra.
                        int sumBoutNumber = 0; //Az aktivitás szakaszok lesznek hozzáadva, azok darabszámát tartalmazza.
                        int sumActivityLevel = 0; //Ebbe adja össze a muslica értékeket a Total Activity Level-hez.

                        int isSleeping = 0; //Ebben számolja, hogy hány db muslica inaktív egy huzamban. Ha ez az érték eléri az alvónak számító összeget, akkor onnantól a következő aktív értékig számítva alvónak számít a muslica.
                                            //Mindamellett ha ez az érték eléri a halottnak nyíilvánítást, akkor a válasznak megfelelően kezeli a muslicát
                        int isSleepingDarkLight = 0; //Ugyan azt számolja, mint az isSleeping, csak megáll mikor sötét/világos váltás jön, hogy ha még aktívnak számít az inaktivitás mértéke, akkor a megfelelő értéket adja hozzá az egészhez
                                                     //Ez azt jelenti, hogy ha 3 inaktív érték megy sötétben és a sötétet nézzük, majd a 4. világosban, utána egy aktív jön világosban, akkor csak a 3 sötétet adja az egészhez, a +1 világosat ne.
                        int sumIsSleepingDarkLight = 0; //A Total Activity Level paraméterhez a még nem alvásos inaktivitás értékeit is össze kell gyűjteni valahova.
                                                        //Ugyan úgy működik, mint az isSleepingDarkLight csak ebbe a muslicák konkrét értékei mennek.

                        bool isSleepFromLastDay = false; //Két nap váltása között ha összesen van egy alvásnyi inaktivitás, akkor ez a változó true lesz. Ennek köszönhetően a következő napban ha nincs egy alvásnyi inaktivitás, akkor is alvásnak tekinti.

                        int isDead = 0; //Ebben számolja, hogy mikor lesz halott a muslica. A napok során ez nincs nullázva.
                        int currentDayNumber = 0; //Ebben van számolva, hogy hanyadik napnál tartunk jelenleg.

                        for (int j = TimeValues.WholeHourRow; j <= TimeValues.LastRowOfDays - 1; j++)
                        {
                            int currentFly = int.Parse(DAMFiles[i].LoadedDAMValues[j][index]);
                            if (currentFly != -1) //Akkor -1, ha volt egy hibás elem a fájl beolvasásánál. Azt az elemet egyszerűen átugorja a rendszer és nem veszi figyelembe
                            {

                                if (currentFly > ExperimentSettingsValues.Treshold) //Aktív-e
                                {
                                    if ((Dark && DAMFiles[i].LoadedDAMValues[j][9] == "0") || (Light && DAMFiles[i].LoadedDAMValues[j][9] == "1"))
                                    {
                                        sumFly++;
                                        sumActivityLevel += currentFly; //Csak simán hozzáadja a muslica értékét
                                    }

                                    if (isSleeping < ExperimentSettingsValues.Sleep && !isSleepFromLastDay) //Ha nem elég ideje inaktív az alváshoz, akkor az még aktívnak számít
                                    {
                                        sumFly += isSleepingDarkLight;
                                        sumActivityLevel += sumIsSleepingDarkLight; //Az inaktív de még nem alvó szakasz értékeit egyben adja hozzá
                                        isDead += isSleeping;
                                    }
                                    else
                                    {
                                        sumBoutNumber++; //Nincs paraméter ehhez, de kell az értéke az átlag számításhoz
                                    }

                                    isSleepingDarkLight = 0;
                                    isSleeping = 0;
                                    sumIsSleepingDarkLight = 0;
                                    isDead++;
                                    isSleepFromLastDay = false;
                                }
                                else
                                {
                                    if ((Dark && DAMFiles[i].LoadedDAMValues[j][9] == "0") || (Light && DAMFiles[i].LoadedDAMValues[j][9] == "1"))
                                    {
                                        isSleepingDarkLight++;
                                        sumIsSleepingDarkLight += currentFly;
                                    }
                                    isSleeping++;
                                }

                                if (j != TimeValues.WholeHourRow && (j - TimeValues.WholeHourRow + 1) % TimeValues.NumberOfRowsInADay == 0)
                                {
                                    if (isDead < ExperimentSettingsValues.Dead) //Ha halott a muslica, írja ki, hogy halott
                                    {
                                        templateResultParameter.Groups[groupIndexInResults].ResultsForFlies[templateResultParameter.Groups[groupIndexInResults].NumberOfThisGroup][currentDayNumber] = "DEAD";
                                        j = TimeValues.LastRowOfDays - 1; //Azért kell ide -1 és a sorokon végigmenetel vizsgálatához is -1 mert itt lent a WholeHourRow-nál +1 van. Annak érdekében, hogy a következő egész órákat ne az előző egész órához számolja be.
                                    }
                                    else
                                    {
                                        int nextDayRow = 0; //Ezzel az értékkel megy a következő nap sorain addig, amíg nem lesz elég inaktivitás az alváshoz, vagy amíg nem talál egy aktív értéket.

                                        while (int.Parse(DAMFiles[i].LoadedDAMValues[j + nextDayRow][index]) <= ExperimentSettingsValues.Treshold && isSleeping + nextDayRow < ExperimentSettingsValues.Sleep)
                                        {
                                            nextDayRow++;
                                        }

                                        if (int.Parse(DAMFiles[i].LoadedDAMValues[j + nextDayRow][index]) > ExperimentSettingsValues.Treshold)
                                        {
                                            sumFly += isSleepingDarkLight;
                                            sumBoutNumber++;
                                            sumActivityLevel += sumIsSleepingDarkLight; //Az inaktív de még nem alvó szakasz értékeit egyben adja hozzá
                                        }
                                        else
                                        {
                                            isSleepFromLastDay = true;
                                        }

                                        sumFly *= ExperimentSettingsValues.BinLength;
                                        string finalValue = ""; //Ezt írja be majd értéknek az eredményekhez, azért van rá szükség, hogy szebb legyen a kód.
                                        try
                                        {
                                            if (AverageBoutLength)
                                            {
                                                finalValue = (sumFly / sumBoutNumber).ToString();
                                            }
                                            else if (TotalActivityLevel)
                                            {
                                                finalValue = sumActivityLevel.ToString();
                                            }
                                            else
                                            {
                                                finalValue = sumFly.ToString();
                                            }
                                        }
                                        catch (DivideByZeroException e)
                                        {
                                            finalValue = "0";
                                        }
                                        templateResultParameter.Groups[groupIndexInResults].ResultsForFlies[templateResultParameter.Groups[groupIndexInResults].NumberOfThisGroup][currentDayNumber] = finalValue;
                                    }
                                    currentDayNumber++;
                                    sumFly = 0;
                                    sumBoutNumber = 0;
                                    sumActivityLevel = 0;
                                    isSleeping = 0;
                                    isSleepingDarkLight = 0;
                                    sumIsSleepingDarkLight = 0;
                                    isDead = 0;
                                }

                            }

                        }

                        templateResultParameter.Groups[groupIndexInResults].NumberOfThisGroup++;
                    }
                    index++;

                }

            }

            return templateResultParameter;
        }

        private static ResultParameter CalculateSleepParametersHOUR(List<LoadedDAMFile> DAMFiles, ResultParameter templateResultParameter, bool BoutNumber, bool AverageBoutLength, bool TotalInactivity)
        {

            for (int i = 0; i < DAMFiles.Count; i++)
            {
                int index = 10; //A DAM fájlban a muslicák oszlopának meghatározása. Ez az érték 10-től nő 41-ig, mert 42 oszlopa van a DAM fájlnak. A 42 értéke konstansként szerepel a TimeValues-ban.

                while (index < TimeValues.ColumnsOfDAM)
                {
                    int groupIndexInResults = templateResultParameter.Groups.FindIndex(x => x.GetName() == DAMFiles[i].GroupTableValues[index - 10]);
                    //DAMFiles[i].GroupTableValues[index - 10];  Ez konkrétan a string értéket adja vissza a csoporthoz, tehát a csoport nevét a táblázatból, ami a beviteli mező volt a csoportokhoz

                    if (groupIndexInResults != -1) //Ez azért kell, mert ha a csoport táblázatban a DAM-ok megadásánál üresen hagyta a felhasználó a mezőt, akkor ez az érték -1 lesz. Ha ez az érték -1, akkor azt a csoportot ne vegye figyelembe a rendszer a táblázatból.
                    {

                        int sumFly = 0; //Az alvónak számító muslicák darabszáma, ez lesz a végeredmény az egyes napokra.
                        int sumBoutNumber = 0; //Az alvás szakaszok lesznek hozzáadva, azok darabszámát tartalmazza.
                        int sumInactivity = 0; //Az inaktív sorokat számolja végig, függetlenül attól, hogy alvásnak számít-e vagy sem.

                        bool isSleepFromLastHour = false; //Két óra váltása között ha összesen van egy alvásnyi inaktivitás, akkor ez a változó true lesz. Ennek köszönhetően a következő órában ha nincs egy alvásnyi inaktivitás, akkor is alvásnak tekinti.

                        int isSleeping = 0; //Ebben számolja, hogy hány db muslica inaktív egy huzamban. Ha ez az érték eléri az alvónak számító összeget, akkor onnantól a következő aktív értékig számítva ezt hozzáadja a sum-hoz.
                                            //Mindamellett ha ez az érték eléri a halottnak nyilvánítást, akkor a válasznak megfelelően kezeli a muslicát
                        int isDead = 0; //Ebben számolja, hogy mikor lesz halott a muslica. A napok során ez nincs nullázva.
                        int currentHourNumber = 0; //Ebben van számolva, hogy hanyadik óránál tartunk jelenleg.

                        for (int j = TimeValues.WholeHourRow; j <= TimeValues.LastRowOfHours - 1; j++)
                        {
                            int currentFly = int.Parse(DAMFiles[i].LoadedDAMValues[j][index]);
                            if (currentFly != -1) //Akkor -1, ha volt egy hibás elem a fájl beolvasásánál. Azt az elemet egyszerűen átugorja a rendszer és nem veszi figyelembe
                            {

                                if (currentFly <= ExperimentSettingsValues.Treshold) //Inaktív-e
                                {
                                    sumInactivity++;
                                    isSleeping++;
                                }
                                else
                                {
                                    if (isSleeping >= ExperimentSettingsValues.Sleep || isSleepFromLastHour) //Elég ideje inaktív-e az alváshoz, vagy az előző óra utolsó értékei alapján alvásnak számított az eddigi inaktív időszak is.
                                    {
                                        sumFly += isSleeping;
                                        sumBoutNumber++;
                                    }
                                    else if(isSleeping < ExperimentSettingsValues.Sleep)
                                    {
                                        isDead += isSleeping;
                                    }
                                    isSleeping = 0;
                                    isDead++;
                                    isSleepFromLastHour = false;
                                }

                                if (j != TimeValues.WholeHourRow && (j - TimeValues.WholeHourRow + 1) % TimeValues.NumberOfRowsInAnHour == 0)
                                {
                                    bool dead = false; //Ha halott a muslica, akkor a többi kiértékelés ne történjen meg később
                                    if((j - TimeValues.WholeHourRow + 1) % TimeValues.NumberOfRowsInADay == 0) //Az órás felbontásnál is a halál az napokra vonatkozik. Ez azt jelenti, hogy a napok végét meg kell nézni, hogy ott halott-e a muslica.
                                    {
                                        if (isDead < ExperimentSettingsValues.Dead) //Ha halott a muslica, írja ki, hogy halott
                                        {
                                            dead = true;
                                            int lastHourOfDeadDay = currentHourNumber; //Az utolsó óra, azon a napon, amikor halott lett a muslica, ez kell a while ciklus feltételéhez
                                            while(currentHourNumber != lastHourOfDeadDay - (TimeValues.HoursOfDay - 1)) //Ha a nap végén halott a muslica, akkor arra a napra minden óránál visszamegy és kitörli az értékeket, majd a nap első órájába beírja, hogy halott. Ezáltal arra a napra a többi órában nem ír ki semmit.
                                            {
                                                templateResultParameter.Groups[groupIndexInResults].ResultsForFlies[templateResultParameter.Groups[groupIndexInResults].NumberOfThisGroup][currentHourNumber] = "";
                                                currentHourNumber--;
                                            }
                                            templateResultParameter.Groups[groupIndexInResults].ResultsForFlies[templateResultParameter.Groups[groupIndexInResults].NumberOfThisGroup][currentHourNumber] = "DEAD";
                                            j = TimeValues.LastRowOfHours - 1; //Azért kell ide -1 és a sorokon végigmenetel vizsgálatához is -1 mert itt lent a WholeHourRow-nál +1 van. Annak érdekében, hogy a következő egész órákat ne az előző egész órához számolja be.
                                        }
                                        else
                                        {
                                            isDead = 0;
                                        }
                                    }
                                    
                                    if(!dead)
                                    {
                                        int nextHourRow = 0; //Ezzel az értékkel megy a következő nap sorain addig, amíg nem lesz elég inaktivitás az alváshoz, vagy amíg nem talál egy aktív értéket.

                                        while (int.Parse(DAMFiles[i].LoadedDAMValues[j + nextHourRow][index]) <= ExperimentSettingsValues.Treshold && isSleeping + nextHourRow < ExperimentSettingsValues.Sleep)
                                        {
                                            nextHourRow++;
                                        }

                                        if (int.Parse(DAMFiles[i].LoadedDAMValues[j + nextHourRow][index]) <= ExperimentSettingsValues.Treshold)
                                        {
                                            sumFly += isSleeping;
                                            sumBoutNumber++;
                                            isSleepFromLastHour = true;
                                        }

                                        sumFly *= ExperimentSettingsValues.BinLength;
                                        string finalValue = ""; //Ezt írja be majd értéknek az eredményekhez, azért van rá szükség, hogy szebb legyen a kód.
                                        try
                                        {
                                            if (BoutNumber)
                                            {
                                                finalValue = sumBoutNumber.ToString();
                                            }
                                            else if (AverageBoutLength)
                                            {
                                                finalValue = (sumFly / sumBoutNumber).ToString();
                                            }
                                            else if (TotalInactivity)
                                            {
                                                finalValue = sumInactivity.ToString();
                                            }
                                            else
                                            {
                                                finalValue = sumFly.ToString();
                                            }
                                        }
                                        catch (DivideByZeroException e)
                                        {
                                            finalValue = "0";
                                        }
                                        templateResultParameter.Groups[groupIndexInResults].ResultsForFlies[templateResultParameter.Groups[groupIndexInResults].NumberOfThisGroup][currentHourNumber] = finalValue;
                                    }
                                    currentHourNumber++;
                                    sumFly = 0;
                                    sumBoutNumber = 0;
                                    sumInactivity = 0;
                                    isSleeping = 0;
                                }

                            }

                        }

                        templateResultParameter.Groups[groupIndexInResults].NumberOfThisGroup++;
                    }
                    index++;

                }

            }

            return templateResultParameter;
        }

        private static ResultParameter CalculateActivityParametersHOUR(List<LoadedDAMFile> DAMFiles, ResultParameter templateResultParameter, bool AverageBoutLength, bool TotalActivityLevel, bool AverageActivityLevel)
        {

            for (int i = 0; i < DAMFiles.Count; i++)
            {
                int index = 10; //A DAM fájlban a muslicák oszlopának meghatározása. Ez az érték 10-től nő 41-ig, mert 42 oszlopa van a DAM fájlnak. A 42 értéke konstansként szerepel a TimeValues-ban.

                while (index < TimeValues.ColumnsOfDAM)
                {
                    int groupIndexInResults = templateResultParameter.Groups.FindIndex(x => x.GetName() == DAMFiles[i].GroupTableValues[index - 10]);
                    //DAMFiles[i].GroupTableValues[index - 10];  Ez konkrétan a string értéket adja vissza a csoporthoz, tehát a csoport nevét a táblázatból, ami a beviteli mező volt a csoportokhoz

                    if (groupIndexInResults != -1) //Ez azért kell, mert ha a csoport táblázatban a DAM-ok megadásánál üresen hagyta a felhasználó a mezőt, akkor ez az érték -1 lesz. Ha ez az érték -1, akkor azt a csoportot ne vegye figyelembe a rendszer a táblázatból.
                    {

                        int sumFly = 0; //Az aktívnak számító muslicák darabszáma, ez lesz a végeredmény az egyes napokra.
                        int sumBoutNumber = 0; //Az aktivitás szakaszok lesznek hozzáadva, azok darabszámát tartalmazza.
                        int sumActivityLevel = 0; //Ebbe adja össze a muslica értékeket a Total Activity Level-hez.

                        int isSleeping = 0; //Ebben számolja, hogy hány db muslica inaktív egy huzamban. Ha ez az érték eléri az alvónak számító összeget, akkor onnantól a következő aktív értékig számítva alvónak számít a muslica.
                                            //Mindamellett ha ez az érték eléri a halottnak nyíilvánítást, akkor a válasznak megfelelően kezeli a muslicát
                        int sumIsSleeping = 0; //A Total Activity Level paraméterhez a még nem alvásos inaktivitás értékeit is össze kell gyűjteni valahova.

                        bool isSleepFromLastHour = false; //Két nap váltása között ha összesen van egy alvásnyi inaktivitás, akkor ez a változó true lesz. Ennek köszönhetően a következő napban ha nincs egy alvásnyi inaktivitás, akkor is alvásnak tekinti.

                        int isDead = 0; //Ebben számolja, hogy mikor lesz halott a muslica. A napok során ez nincs nullázva.
                        int currentHourNumber = 0; //Ebben van számolva, hogy hanyadik napnál tartunk jelenleg.

                        for (int j = TimeValues.WholeHourRow; j <= TimeValues.LastRowOfHours - 1; j++)
                        {
                            int currentFly = int.Parse(DAMFiles[i].LoadedDAMValues[j][index]);
                            if (currentFly != -1) //Akkor -1, ha volt egy hibás elem a fájl beolvasásánál. Azt az elemet egyszerűen átugorja a rendszer és nem veszi figyelembe
                            {

                                if (currentFly > ExperimentSettingsValues.Treshold) //Aktív-e
                                {
                                    sumFly++;
                                    sumActivityLevel += currentFly; //Csak simán hozzáadja a muslica értékét

                                    if (isSleeping < ExperimentSettingsValues.Sleep && !isSleepFromLastHour) //Ha nem elég ideje inaktív az alváshoz, akkor az még aktívnak számít
                                    {
                                        sumFly += isSleeping;
                                        sumActivityLevel += sumIsSleeping; //Az inaktív de még nem alvó szakasz értékeit egyben adja hozzá
                                        isDead += isSleeping;
                                    }
                                    else
                                    {
                                        sumBoutNumber++; //Nincs paraméter ehhez, de kell az értéke az átlag számításhoz
                                    }

                                    isSleeping = 0;
                                    sumIsSleeping = 0;
                                    isDead++;
                                    isSleepFromLastHour = false;
                                }
                                else
                                {
                                    sumIsSleeping += currentFly;
                                    isSleeping++;
                                }

                                if (j != TimeValues.WholeHourRow && (j - TimeValues.WholeHourRow + 1) % TimeValues.NumberOfRowsInAnHour == 0)
                                {
                                    bool dead = false; //Ha halott a muslica, akkor a többi kiértékelés ne történjen meg később
                                    if ((j - TimeValues.WholeHourRow + 1) % TimeValues.NumberOfRowsInADay == 0) //Az órás felbontásnál is a halál az napokra vonatkozik. Ez azt jelenti, hogy a napok végét meg kell nézni, hogy ott halott-e a muslica.
                                    {
                                        if (isDead < ExperimentSettingsValues.Dead) //Ha halott a muslica, írja ki, hogy halott
                                        {
                                            dead = true;
                                            int lastHourOfDeadDay = currentHourNumber; //Az utolsó óra, azon a napon, amikor halott lett a muslica, ez kell a while ciklus feltételéhez
                                            while (currentHourNumber != lastHourOfDeadDay - (TimeValues.HoursOfDay - 1)) //Ha a nap végén halott a muslica, akkor arra a napra minden óránál visszamegy és kitörli az értékeket, majd a nap első órájába beírja, hogy halott. Ezáltal arra a napra a többi órában nem ír ki semmit.
                                            {
                                                templateResultParameter.Groups[groupIndexInResults].ResultsForFlies[templateResultParameter.Groups[groupIndexInResults].NumberOfThisGroup][currentHourNumber] = "";
                                                currentHourNumber--;
                                            }
                                            templateResultParameter.Groups[groupIndexInResults].ResultsForFlies[templateResultParameter.Groups[groupIndexInResults].NumberOfThisGroup][currentHourNumber] = "DEAD";
                                            j = TimeValues.LastRowOfHours - 1; //Azért kell ide -1 és a sorokon végigmenetel vizsgálatához is -1 mert itt lent a WholeHourRow-nál +1 van. Annak érdekében, hogy a következő egész órákat ne az előző egész órához számolja be.
                                        }
                                        else
                                        {
                                            isDead = 0;
                                        }
                                    }

                                    if (!dead)
                                    {
                                        int nextHourRow = 0; //Ezzel az értékkel megy a következő nap sorain addig, amíg nem lesz elég inaktivitás az alváshoz, vagy amíg nem talál egy aktív értéket.

                                        while (int.Parse(DAMFiles[i].LoadedDAMValues[j + nextHourRow][index]) <= ExperimentSettingsValues.Treshold && isSleeping + nextHourRow < ExperimentSettingsValues.Sleep)
                                        {
                                            nextHourRow++;
                                        }

                                        if (int.Parse(DAMFiles[i].LoadedDAMValues[j + nextHourRow][index]) > ExperimentSettingsValues.Treshold)
                                        {
                                            sumFly += isSleeping;
                                            sumBoutNumber++;
                                            sumActivityLevel += sumIsSleeping; //Az inaktív de még nem alvó szakasz értékeit egyben adja hozzá
                                        }
                                        else
                                        {
                                            isSleepFromLastHour = true;
                                        }

                                        sumFly *= ExperimentSettingsValues.BinLength;
                                        string finalValue = "";
                                        try
                                        {
                                            if (AverageBoutLength)
                                            {
                                                finalValue = (sumFly / sumBoutNumber).ToString();
                                            }
                                            else if (TotalActivityLevel)
                                            {
                                                finalValue = sumActivityLevel.ToString();
                                            }
                                            else if (AverageActivityLevel)
                                            {
                                                finalValue = (sumActivityLevel / sumBoutNumber).ToString();
                                            }
                                            else
                                            {
                                                finalValue = sumFly.ToString();
                                            }
                                        }
                                        catch (DivideByZeroException e) //Ha az átlag számításhoz 0-val akarna osztani a rendszer, akkor csak írjon ki 0-t
                                        {
                                            finalValue = "0";
                                        }
                                        templateResultParameter.Groups[groupIndexInResults].ResultsForFlies[templateResultParameter.Groups[groupIndexInResults].NumberOfThisGroup][currentHourNumber] = finalValue;
                                    }
                                    currentHourNumber++;
                                    sumFly = 0;
                                    sumBoutNumber = 0;
                                    sumActivityLevel = 0;
                                    isSleeping = 0;
                                    sumIsSleeping = 0;
                                }

                            }

                        }

                        templateResultParameter.Groups[groupIndexInResults].NumberOfThisGroup++;
                    }
                    index++;

                }

            }

            return templateResultParameter;
        }


    }
}
