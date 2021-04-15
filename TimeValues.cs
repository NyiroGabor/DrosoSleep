using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrosoSleep
{
    public class TimeValues
    {
        public TimeValues()
        {

        }

        public const int HoursOfDay = 24;
        public const int MinutesOfHour = 60;
        public const int ColumnsOfDAM = 42;
        public const int NumberOfGroups = 32;
        private static string[] months = { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
        public static int NumberOfDays; //Napok darabszáma, ennyi oszlop lesz az excelben egy csoporthoz
        public static string[] WholeHour; //Az első teljes óra, ahonnan számolva vannak a napok, átalakítva a ':' karakterek alapján szétbontva
        public static int WholeHourRow; //Az első teljes óra sorának a száma.
        public static int NumberOfRowsInADay; //Egy nap hány sorból áll. Ez az érték többször is elő fog kerülni, így elég egyszer kiszámolni
        public static int LastRowOfDays; //Az utolsó sor, ami még az utolsó napba beletartozik. Az ezutáni elemek már nem kerülnek beszámításra.
        public static string FirstDayDate; //A legelső nap dátuma, ami fel lesz tűntetve majd a táblázatban.

        public static int NumberOfRowsInAnHour; //Kiszámolja, hogy egy óra hány sort tartalmaz. Az egész órák vizsgálatánál így nem kell majd az órák értékét figyelni, hanem elég ezzel számolni azt tekintve, hogy honnantól kezdődik és meddig tart egy óra.
        public static int LastRowOfHours; //Az utolsó sor, ami még az utolsó órába beletartozik. Az ezutáni elemek már nem kerülnek beszámításra.
        public static int NumberOfHours; //Órák darabszáma, ennyi oszlop lesz az excelben egy csoporthoz
        private static string[] DarkLightValuesForHours = new string[HoursOfDay]; //Az Excelben lesz egy külön sor, ami D/L módon jelöli, hogy az adott óra sötét volt-e vagy sem. Ebben a listában lesz tárolva az egyes órákhoz tartozóan ez az érték.
        //A sötét és világos arány mindig ugyan úgy változik az egyes napoknál, ezért elég csak a legelső napot lementeni, ami azt jelenti, hogy 24 elemű tömb elég hozzá hisz minden nap 24 órából áll.
        //Ez azt eredményezi, hogy az Excelbe írásnál elég lesz ezt a tömböt ismételgetni újra és újra a kiiratáshoz egészen addig, míg el nem fogynak az órák.
        public static List<int> ExactHourValueForHours = new List<int>();

        public static string GetIndexOfDarkLightValuesForHours (int i)
        {
            if(i<DarkLightValuesForHours.Length)
            {
                return DarkLightValuesForHours[i];
            }
            else
            {
                return DarkLightValuesForHours[i - ((i / DarkLightValuesForHours.Length) * DarkLightValuesForHours.Length)];
            }
        }

        public static int IndexOfMonth(string currentMonth) //A hónapok listájából visszaadja a paraméterben meghatározott hónap indexét
        {
            for (int i = 0;i<months.Length;i++)
            {
                if(months[i] == currentMonth)
                {
                    return i;
                }
            }
            return -1;
        }

        public static void NumberOfDaysAndNumberOfRowsInADay(LoadedDAMFile DAMFile)
        {
            NumberOfRowsInAnHour = MinutesOfHour / ExperimentSettingsValues.BinLength; //Mennyi sorból áll egy óra
            NumberOfRowsInADay = NumberOfRowsInAnHour * HoursOfDay; //Mennyi sorból áll egy nap

            int currentNumberOfDays = -1; //Az első teljes óra még nem jelent egy napot, hiszen onnan kezdjük csak a számolást
            int currentNumberOfHours = 0; //Az eddigi napok alapján lehet számolni az utolsó napot meghatározó egész óráig az órák számát. Utána egyesével minden egész órát meg kell figyelni.
            int actualRowNumber = WholeHourRow; //Először a teljes óra sorának az értékét kapja és mindig egy napnyi sorral nő az értéke és megnézi, hogy van-e még eleme ott a DAM fájlnak. Ha van, akkor az megint egy teljes óra és egy újabb nap, ha nincs, akkor nincs több nap
            while (true) //Ez a ciklus a napok megszámolásához kell, a napok számának megadásához
            {
                try
                {
                    string temp = DAMFile.LoadedDAMValues[actualRowNumber][0];
                    currentNumberOfDays++;
                    actualRowNumber += NumberOfRowsInADay;
                }
                catch
                {
                    currentNumberOfHours = currentNumberOfDays * HoursOfDay; //Eddig ennyi órát lehetett összeszámolni a rendelkezésre álló teljes napok alapján
                    
                    while (true) //Ez a ciklus az órák megszámolásához kell, az utolsó egész óra mentéséhez
                    {
                        try
                        {
                            actualRowNumber += NumberOfRowsInAnHour;
                            string temp = DAMFile.LoadedDAMValues[actualRowNumber][0];
                            currentNumberOfHours++;
                        }
                        catch
                        {
                            break;
                        }
                    }
                    break;
                }
            }

            for (int i = 0; i < currentNumberOfHours; i++) //Feltölti a kiírásra szánt órák listáját
            {
                ExactHourValueForHours.Add(CalculateHours(i));
            }

            int indexOfHourInDay = 0; //Ez az index ahhoz, hogy a String tömbben hol járunk épp, tehát hogy a 24-ből hanyadik óránál tartunk a napból.
            for(int i=WholeHourRow; i < WholeHourRow + NumberOfRowsInADay;i++) //Egyesével végigmegy a DAM fájl értékein egy napra tekintve az első oszlopban és megnézi, hogy a sötét és világos sorok hogyan vannak felosztva az órákban.
            {
                if(DAMFile.LoadedDAMValues[i][9] == "0") //Az adott sor sötét
                {
                    if(DarkLightValuesForHours[indexOfHourInDay] != "Light" && DarkLightValuesForHours[indexOfHourInDay] != "L+D") //Ha ez az óra eddig vagy semmi volt, vagy sötét, akkor sötét lesz
                    {
                        DarkLightValuesForHours[indexOfHourInDay] = "Dark";
                    }
                    else //Ha ez az óra eddig világos volt, akkor közös lesz
                    {
                        DarkLightValuesForHours[indexOfHourInDay] = "L+D";
                    }
                }
                else if (DAMFile.LoadedDAMValues[i][9] == "1") //Az adott sor világos
                {
                    if (DarkLightValuesForHours[indexOfHourInDay] != "Dark" && DarkLightValuesForHours[indexOfHourInDay] != "D+L") //Ha ez az óra eddig vagy semmi volt, vagy világos, akkor világos lesz
                    {
                        DarkLightValuesForHours[indexOfHourInDay] = "Light";
                    }
                    else //Ha ez az óra eddig sötét volt, akkor közös lesz
                    {
                        DarkLightValuesForHours[indexOfHourInDay] = "D+L";
                    }
                }

                if(i!=WholeHourRow && (i - WholeHourRow) % NumberOfRowsInAnHour == 0) //Legelső elem egész óra lesz, de ott még nem kell tovább lépnie a D/L tömb következő elemére, hiszen ez lesz az első elem benne
                {
                    indexOfHourInDay++;
                }
            }

            NumberOfDays = currentNumberOfDays;
            NumberOfHours = currentNumberOfHours;
        }

        private static int CalculateHours(int i)
        {
            if((int.Parse(WholeHour[0]) + i) >= HoursOfDay) //WholeHour[0] az órát jelöli az első teljes órában, szóval az órák kiiratásánál bőven elég ezzel számolni
            {
                return (int.Parse(WholeHour[0]) + i) - (((int.Parse(WholeHour[0]) + i) / HoursOfDay) * HoursOfDay); //Ha 24, vagy annál több, akkor ahányszor az aktuális óra értékben megvan a 24, annyiszor 24-et kell kivonni az aktuális óra értékéből
            }
            else
            {
                return int.Parse(WholeHour[0]) + i;
            }
        }
        
    }
}
