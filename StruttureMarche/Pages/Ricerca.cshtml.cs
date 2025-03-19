using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StruttureMarche.ViewModels;

namespace StruttureMarche.Pages
{
    public class RicercaModel : PageModel
    {
        [BindProperty]
        public RicercaViewModel Ricerca { get; set; }

        public void OnGet()
        {
            Ricerca = new RicercaViewModel
            {
                Strutture = new List<Marche.modelli.ModelliServiziMarche>()
            };
        }
    }
}
