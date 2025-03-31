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
            // Uso di .Result per ottenere il risultato sincrono
            return FunzioniInterrogazioniServiziMarche.DaiServizi().Result;
        }

        [HttpGet]
        public ModelliServiziMarche[] RicercaStrutture(string denominazione, string comune, string provincia)
        {
            // Uso di .Result per ottenere il risultato sincrono
            return FunzioniInterrogazioniServiziMarche.RicercaStrutture(denominazione, comune, provincia).Result;
        }
    }
}
