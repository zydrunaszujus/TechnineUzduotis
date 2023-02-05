using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnineUzduotis.Dto;

namespace TechnineUzduotis.Modeliai
{
    public class Salis
    {
        public string Pavadinimas { get; set; }
        public string Regionas { get; set; }
        //public double Mokestis{get;set;}

        public Salis(SalisDto dto)
        {
            Pavadinimas = dto.country;
            Regionas = dto.region;
            //Mokestis=dto.countryPvm;
        }
    }
}
