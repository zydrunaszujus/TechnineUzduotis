using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnineUzduotis.Dto;
using TechnineUzduotis.Modeliai;

namespace TechnineUzduotis.Servisai
{
    public class PvmSkaiciavimoServisas
    {

        public static double SkaiciuotiPVM(double uzsakymoSuma, Klientas klientas, Tiekejas tiekejas)
        {
            double pvmMokestis=0;
            string pvmSalis;

            if (tiekejas.YraPvmMoketojas == true)
            {
                if (klientas.Salis.Regionas == "Europe")
                {

                   if (tiekejas.Salis.Pavadinimas != klientas.Salis.Pavadinimas)
                   {
                        pvmSalis = klientas.Salis.Pavadinimas;
                   }
                   else
                   {
                        pvmSalis=tiekejas.Salis.Pavadinimas;
                   }

                    var procentas = GautiTaikomaPvmProcenta(pvmSalis);

                    pvmMokestis = uzsakymoSuma / 100 * procentas;

                }
               
            }
            
            return pvmMokestis;
        }
        private static int GautiTaikomaPvmProcenta(string saliesPavadinimas)
        {
            int x = 0;
            Console.WriteLine($"Iveskite pvm dydi taikoma {saliesPavadinimas}");
            while (int.TryParse(Console.ReadLine(), out x) == false)
            {
                Console.WriteLine("NEtinkamai ivesta reiksme, bandykite dar karta ");
            }
            return x;

        }
    }

}