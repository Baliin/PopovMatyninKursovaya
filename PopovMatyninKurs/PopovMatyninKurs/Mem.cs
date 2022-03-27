using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopovMatyninKurs
{
    internal class Mem
    {
        private string name, kate, way;

        public Mem(string name, string kate, string way)
        {
            this.name = name;
            this.kate = kate;
            this.way = way;
        }

        public string GetName()
        {
            return name;
        }

        public string GetKate()
        {
            return kate;
        }

        public string GetWay()
        {
            return way;
        }
    }
}
