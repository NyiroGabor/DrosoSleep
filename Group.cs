using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrosoSleep
{
    public class Group
    {
        private string name; //A csoport neve, ami a beviteli táblázatban volt megadva
        public List<string[]> ResultsForFlies; //Ez tartalmazza az eredményeket az egyes csoportokhoz. A lista elemeinek száma attól függ, hogy hányszor írtuk be a csoport nevét a táblázatba még a csoportok megadásánál. A string tömb elemeinek a száma attól függ, hogy mi alapján számolunk; napok, órák, binek stb.
        public int NumberOfThisGroup; //Azt mutatja, hogy hányszor lett beírva ez a csoport a táblázatba. Miközben feltöltődik a lista az eredményekkel, ez az érték közben lesz meghatározva, mert egyben az aktuális indexet is tartalmazza majd a feltöltés közben.

        public Group(string name, int stringArraySize) //Az int határozza meg, hogy az első elem mekkora méretű lesz (Attól függ, hogy napokra nézzük a számítást, vagy órára, attól függ, hogy itt mit kap)
        {
            this.name = name;
            ResultsForFlies = new List<string[]>();
            ResultsForFlies.Add(new string[stringArraySize]); //Ez csak azért kell, hogy a csoport létrehozásakor meglegyen a sorszámozott elem benne, csupán a létszám kedvéért.
            NumberOfThisGroup = 0;
        }

        public string GetName()
        {
            return name;
        }



    }
}
