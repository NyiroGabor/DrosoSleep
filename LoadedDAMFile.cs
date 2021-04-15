using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrosoSleep
{
    public class LoadedDAMFile //Miután a DAM fájl betöltésre kerül ez az osztály példányai tartalmazzák majd a DAM fájl nevét, a DAM tartalmát és a hozzá tartozó táblázatot
        //A listában, ahol a DAM fájlok lesznek feltűntetve ebből az osztályból álló lista lesz
    {
        private string name;
        private string[][] loadedDAMValues; //A betöltött és szeparált adatokat tartalmazza a DAM fájlból. Első tömb a sor, második az oszlop
        private string[] groupTableValues; //A DAM-hoz tartozó csoportok értékei a programban lévő táblázat alapján

        public string Name { get; }
        public string[][] LoadedDAMValues { get; set; }
        public string[] GroupTableValues { get; set; }

        public LoadedDAMFile(string name, string[][] loadedDAMValues)
        {
            this.name = name;
            Name = name;
            this.loadedDAMValues = loadedDAMValues;
            LoadedDAMValues = loadedDAMValues;
            groupTableValues = new string[TimeValues.NumberOfGroups]; //Mindig 32 csoport van a táblázatban
            for(int i = 0;i<groupTableValues.Length;i++)
            {
                groupTableValues[i] = "";
            }
            GroupTableValues = groupTableValues;
        }

        public override string ToString()
        {
            string[] fullName = name.Split('\\');
            string[] fileName = fullName[fullName.Length - 1].Split('.');
            return fileName[0];
        }
    }
}
