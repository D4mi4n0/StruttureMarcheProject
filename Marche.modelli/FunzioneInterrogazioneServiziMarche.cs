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

        public static async Task<ModelliServiziMarche[]> DaiTuttiIServizi()
        {
            string BaseUri = "http://www.datiopen.it/export/json/Regione-Marche---Mappa-delle-strutture-ricettive.json";
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(BaseUri);
            string contents = await response.Content.ReadAsStringAsync();


            ModelliServiziMarche[] elencoLocali = JsonConvert.DeserializeObject<ModelliServiziMarche[]>(contents);

            return elencoLocali;

        }

        public static async Task<ModelliServiziMarche[]> RicercaServizi(String RicercaPerDenominazione)
        {
            ModelliServiziMarche[] tuttiLocali = await DaiTuttiIServizi();

            return tuttiLocali.Where(s => s.Denominazione.ToLower().Contains(RicercaPerDenominazione.ToLower())).ToArray();
        }

        public static async Task<ModelliServiziMarche[]> RicercaServiziPerCategoria()
        {
            ModelliServiziMarche[] tuttiLocali = await DaiTuttiIServizi();

            return tuttiLocali.OrderBy(s => s.CategoriaStruttura).ToArray();
        }
    }
}
