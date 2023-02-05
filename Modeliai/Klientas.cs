using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnineUzduotis.Modeliai
{
   public class Klientas:Asmuo
    {
        public Klientas(string vardas, string pavarde,StatusasEnum statusas,Salis salis)
        {
            Vardas = vardas;
            Pavarde = pavarde;
            Statusas = statusas;
            Salis = salis;
        }
    }
}
