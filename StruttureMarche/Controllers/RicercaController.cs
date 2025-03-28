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
            var elencoStrutture = await FunzioniInterrogazioniServiziMarche.DaiTuttiIServizi();
            var comuni = elencoStrutture.Select(s => s.Comune).Distinct().ToList();
            var categorie = elencoStrutture.Select(s => s.CategoriaStruttura).Distinct().ToList();

            if (!string.IsNullOrEmpty(denominazione))
            {
                elencoStrutture = elencoStrutture.Where(s => s.Denominazione.Contains(denominazione, StringComparison.OrdinalIgnoreCase)).ToArray();
            }

            if (!string.IsNullOrEmpty(comune))
            {
                elencoStrutture = elencoStrutture.Where(s => s.Comune.Contains(comune, StringComparison.OrdinalIgnoreCase)).ToArray();
            }

            if (!string.IsNullOrEmpty(provincia))
            {
                elencoStrutture = elencoStrutture.Where(s => s.Provincia.Contains(provincia, StringComparison.OrdinalIgnoreCase)).ToArray();
            }

            if (!string.IsNullOrEmpty(categoria))
            {
                elencoStrutture = elencoStrutture.Where(s => s.CategoriaStruttura.Contains(categoria, StringComparison.OrdinalIgnoreCase)).ToArray();
            }

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