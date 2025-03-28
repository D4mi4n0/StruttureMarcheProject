using Marche.modelli.Modelli;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marche.modelli
{
    public static class FunzioniInterrogazioniServiziMarche
    {
        public static async Task<ModelliServiziMarche[]> DaiServizi()
        {
            string BaseUri = "http://www.datiopen.it/export/json/Regione-Marche---Mappa-delle-strutture-ricettive.json";
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(BaseUri);
            string contents = await response.Content.ReadAsStringAsync();

            ModelliServiziMarche[] elencoLocali = JsonConvert.DeserializeObject<ModelliServiziMarche[]>(contents);

            return elencoLocali;
        }

        public static async Task<ModelliServiziMarche[]> RicercaServizi(string denominazione, string comune, string provincia, string categoria)
        {
            ModelliServiziMarche[] tuttiLocali = await DaiServizi();

            if (!string.IsNullOrEmpty(denominazione))
            {
                tuttiLocali = tuttiLocali.Where(s => s.Denominazione.Contains(denominazione, StringComparison.OrdinalIgnoreCase)).ToArray();
            }

            if (!string.IsNullOrEmpty(comune))
            {
                tuttiLocali = tuttiLocali.Where(s => s.Comune.Contains(comune, StringComparison.OrdinalIgnoreCase)).ToArray();
            }

            if (!string.IsNullOrEmpty(provincia))
            {
                tuttiLocali = tuttiLocali.Where(s => s.Provincia.Contains(provincia, StringComparison.OrdinalIgnoreCase)).ToArray();
            }

            if (!string.IsNullOrEmpty(categoria))
            {
                tuttiLocali = tuttiLocali.Where(s => s.CategoriaStruttura.Contains(categoria, StringComparison.OrdinalIgnoreCase)).ToArray();
            }

            return tuttiLocali;
        }

        public static async Task<ModelliServiziMarche[]> RicercaServiziPerCategoria()
        {
            ModelliServiziMarche[] tuttiLocali = await DaiServizi();

            return tuttiLocali.OrderBy(s => s.CategoriaStruttura).ToArray();
        }
    }
}