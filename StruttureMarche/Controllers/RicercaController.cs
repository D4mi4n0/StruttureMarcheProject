using Marche.modelli;
using Microsoft.AspNetCore.Mvc;
using StruttureMarche.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StruttureMarche.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RicercaController : ControllerBase
    {
        [HttpGet("GetStrutture")]
        public async Task<ActionResult<RicercaViewModel>> GetStrutture([FromQuery] string denominazione, [FromQuery] string comune, [FromQuery] string provincia)
        {
            var tutteStrutture = await FunzioniInterrogazioniServiziMarche.DaiTuttiIServizi();
            var strutture = tutteStrutture.ToList();

            if (!string.IsNullOrEmpty(denominazione))
            {
                strutture = strutture.Where(s => s.Denominazione.ToLower().Contains(denominazione.ToLower())).ToList();
            }

            if (!string.IsNullOrEmpty(comune))
            {
                strutture = strutture.Where(s => s.Comune.ToLower().Contains(comune.ToLower())).ToList();
            }

            if (!string.IsNullOrEmpty(provincia))
            {
                strutture = strutture.Where(s => s.Provincia.ToLower().Contains(provincia.ToLower())).ToList();
            }

            var viewModel = new RicercaViewModel
            {
                Denominazione = denominazione,
                Comune = comune,
                Provincia = provincia,
                Strutture = strutture
            };

            return Ok(viewModel);
        }
    }
}