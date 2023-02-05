using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnineUzduotis.Dto;

namespace TechnineUzduotis.Servisai
{
    public static class SaliuApiServisas
    {
        public static async Task<List<SalisDto>> GautiSaliuSarasaAsync()
        {
            var sarasas = new List<SalisDto>();

            using var client = new HttpClient();

            var response = await client.GetAsync("https://api.first.org/data/v1/countries");
            var json = await response.Content.ReadAsStringAsync();
            var result = JObject.Parse(json)["data"];
            var saliuTrumpiniai = result?.Children();

            foreach (var trumpinys in saliuTrumpiniai)
            {
                sarasas.Add(new SalisDto() { country = trumpinys.First["country"].ToString(), 
                    region = trumpinys.First["region"].ToString()/*countruPvm=trumpinys.First["countryPvm"].ToInt()*/ });
            }

            return sarasas;
        }

    }
}
