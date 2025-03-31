using Marche.modelli.Modelli;
using Newtonsoft.Json;

namespace Marche.modelli
{
    public static class FunzioniInterrogazioniServiziMarche
    {
        // Metodo per ottenere tutti i servizi
        public static async Task<ModelliServiziMarche[]> DaiServizi()
        {
            string BaseUri = "http://www.datiopen.it/export/json/Regione-Marche---Mappa-delle-strutture-ricettive.json";
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(BaseUri);
            string contents = await response.Content.ReadAsStringAsync();

            ModelliServiziMarche[] elencoLocali = JsonConvert.DeserializeObject<ModelliServiziMarche[]>(contents);

            return elencoLocali;
        }

        // Metodo per cercare i servizi per denominazione
        public static async Task<ModelliServiziMarche[]> RicercaStrutture(string denominazione = "", string comune = "", string provincia = "")
        {
            ModelliServiziMarche[] tuttiLocali = await DaiServizi();

            var risultati = tuttiLocali.Where(s => s.Denominazione.ToLower().Contains(denominazione.ToLower()));

            if (!string.IsNullOrEmpty(comune))
            {
                var risultatiComune = risultati.Where(s => s.Comune.ToLower().Contains(comune.ToLower())).ToArray();
                if (risultatiComune.Length > 0)
                {
                    return risultatiComune;
                }
            }

            if (!string.IsNullOrEmpty(provincia))
            {
                var risultatiProvincia = risultati.Where(s => s.Provincia.ToLower().Contains(provincia.ToLower())).ToArray();
                if (risultatiProvincia.Length > 0)
                {
                    return risultatiProvincia;
                }
            }

            return risultati.ToArray();
        }
    }
}
