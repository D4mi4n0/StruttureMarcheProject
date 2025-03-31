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
        public ModelliServiziMarche[] DaiTuttiServizi()
        {
            Console.WriteLine("🔹 Chiamata ricevuta per DaiTuttiServizi");
            return FunzioniInterrogazioniServiziMarche.DaiServizi().Result;
        }



        [HttpGet]
        public async Task<IActionResult> RicercaStrutture(string? denominazione = "", string? comune = "", string? provincia = "")
        {
            var risultati = await FunzioniInterrogazioniServiziMarche.RicercaStrutture(denominazione ?? "", comune ?? "", provincia ?? "");
            return Ok(risultati);
        }

    }
}
