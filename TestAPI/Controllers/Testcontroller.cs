using Marche.modelli;
using Marche.modelli.Modelli;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TestAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class testcontroller : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> DaiTuttiServizi()
        {
            try
            {
                var servizi = await FunzioniInterrogazioniServiziMarche.DaiServizi();
                return Ok(servizi); // Restituisce i dati come JSON
            }
            catch (Exception ex)
            {
                // Gestione degli errori: restituisce un errore 500 se qualcosa va storto
                return StatusCode(500, $"Errore interno: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> RicercaStrutture(string? denominazione = "", string? comune = "", string? provincia = "")
        {
            var risultati = await FunzioniInterrogazioniServiziMarche.RicercaStrutture(denominazione ?? "", comune ?? "", provincia ?? "");
            return Ok(risultati);
        }

    }
}
