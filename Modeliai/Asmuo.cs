using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnineUzduotis.Modeliai
{
    public abstract class Asmuo
    {
        public string Vardas { get; set; }
        public string Pavarde { get; set; }
        public StatusasEnum Statusas { get; protected set; }
        public Salis Salis { get; set; }
        
    }
}
