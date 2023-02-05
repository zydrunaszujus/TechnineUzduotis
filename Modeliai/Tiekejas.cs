using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnineUzduotis.Modeliai
{
    public class Tiekejas:Asmuo
    {
        public bool YraPvmMoketojas { get; set; }

        public Tiekejas(string vardas, string pavarde, Salis salis, bool yraPvmMoketojas)
        {
            Vardas = vardas;
            Pavarde = pavarde;
            Salis = salis;
            Statusas = StatusasEnum.Juridinis;
            YraPvmMoketojas = yraPvmMoketojas;
        }

    }
}
