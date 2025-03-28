using Microsoft.AspNetCore.Mvc;
using Marche.modelli;
using System.Linq;
using System.Threading.Tasks;
using StruttureMarche.ViewModels;

namespace StruttureMarche.Controllers
{
    public class RicercaController : Controller
    {
        public async Task<IActionResult> Index(string denominazione, string comune, string provincia, string categoria, int pageNumber = 1, int pageSize = 10)
        {
            var elencoStrutture = await FunzioniInterrogazioniServiziMarche.RicercaServizi(denominazione, comune, provincia, categoria);
            var tuttiStrutture = await FunzioniInterrogazioniServiziMarche.DaiServizi();
            var comuni = tuttiStrutture.Select(s => s.Comune).Distinct().ToList();
            var categorie = tuttiStrutture.Select(s => s.CategoriaStruttura).Distinct().ToList();

            var totalCount = elencoStrutture.Length;
            var paginatedResults = elencoStrutture.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToArray();

            var model = new ElencoStruttureMarcheViewModel
            {
                Denominazione = denominazione,
                Comune = comune,
                Provincia = provincia,
                Categoria = categoria,
                Comuni = comuni,
                Categorie = categorie,
                ElencoStrutture = paginatedResults,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalCount = totalCount
            };

            return View(model);
        }

        public IActionResult Reset()
        {
            return RedirectToAction("Index", new { denominazione = "", comune = "", provincia = "", categoria = "" });
        }
    }
}