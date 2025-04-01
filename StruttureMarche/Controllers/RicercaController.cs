using Microsoft.AspNetCore.Mvc;
using Marche.modelli;
using Marche.modelli.Modelli;
using System.Threading.Tasks;
using System.Linq;

namespace StruttureMarche.Controllers
{
    public class RicercaController : Controller
    {
        public async Task<IActionResult> Index(string? denominazione = "", string? comune = "", string? provincia = "", int page = 1)
        {
            int pageSize = 10; // Imposta il numero di risultati per pagina

            // Recupera tutti i risultati senza limitazione
            var risultati = await FunzioniInterrogazioniServiziMarche.RicercaStrutture(denominazione ?? "", comune ?? "", provincia ?? "");

            // Calcola il numero totale di risultati e il numero di pagine
            int totalItems = risultati.Length;
            ViewData["TotalItems"] = totalItems;

            // Limita i risultati in base alla pagina corrente
            var paginatedResults = risultati.Skip((page - 1) * pageSize).Take(pageSize).ToArray();

            return View(paginatedResults);
        }
    }
}