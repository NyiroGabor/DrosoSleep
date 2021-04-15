using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrosoSleep
{
    public class ResultParameter
    {
        public string Name; //A paraméter neve, a worksheet-ek ezt a nevet kapják majd az excelben
        public string Unit; //A paraméter mértékegysége, amit az excelben majd ki kell írni
        public List<Group> Groups; //Egy-egy csoport tartalmazza a saját megoldásait, a paraméter pedig tartalmazza a csoportok listáját

        public ResultParameter()
        {
            Groups = new List<Group>();
        }
        
    }
}
