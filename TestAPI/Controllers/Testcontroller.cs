using Marche.modelli;
using Marche.modelli.Modelli;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TestAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class Testcontroller : ControllerBase
    {
        [HttpGet]
        public ModelliServiziMarche[] DaiTuttiIServizi()
        {
            return FunzioniInterrogazioniServiziMarche.DaiServizi().Result;
        }

        [HttpGet]
        public ModelliServiziMarche[] RicercaTuttiIServizi(string Ricerca)
        {
            return FunzioniInterrogazioniServiziMarche.RicercaServizi(Ricerca).Result;
        }

        [HttpGet]
        public ModelliServiziMarche[] RicercaServiziPerCategoria()
        {
            return FunzioniInterrogazioniServiziMarche.RicercaServiziPerCategoria().Result;
        }
    }
}
