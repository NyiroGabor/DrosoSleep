using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrosoSleep
{
    public class ExperimentSettingsValues
    {

        public static int BinLength; //A bin-ek milyen perc intervallumot fednek le.
        public static int Treshold; //A legmagasabb érték, ami inaktívnak számít még
        public static int Sleep; //Egymást követő inaktív bin-ek száma, ahonnantól alvásnak számít
        public static int Dead; //Minimum aktivitás, ami alapján halottnak számít a muslica
        public static bool ExcludeDead; //True – halott muslica nem számít egyáltalán, False – csak azokon a napokon nem számít, mikor halottnak tekinthető
        public static bool SaveSettings; //True – következő alkalommal is a mostani beállítások maradnak, False – következő alkalommal minden mező üres lesz
        
    }
}
