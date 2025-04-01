using Marche.modelli;
using Marche.modelli.Modelli;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace TestAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class testcontroller : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> DaiTuttiServizi()
        {
            const int maxResults = 1000;  // Limite massimo di risultati da restituire

            // Recupera tutti i servizi
            var servizi = await FunzioniInterrogazioniServiziMarche.DaiServizi();

            // Limita il numero di risultati per evitare di restituire troppi dati
            var limitedServizi = servizi.Take(maxResults).ToArray();

            // Restituisci i dati limitati
            return Ok(limitedServizi);
        }






        [HttpGet]
        public async Task<IActionResult> RicercaStrutture(string? denominazione = "", string? comune = "", string? provincia = "")
        {
            var risultati = await FunzioniInterrogazioniServiziMarche.RicercaStrutture(denominazione ?? "", comune ?? "", provincia ?? "");
            return Ok(risultati);
        }

    }
}
