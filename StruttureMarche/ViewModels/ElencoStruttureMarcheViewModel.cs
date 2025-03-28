using Marche.modelli.Modelli;
using System.Collections.Generic;

namespace StruttureMarche.ViewModels
{
    public class ElencoStruttureMarcheViewModel
    {
        public string Denominazione { get; set; }
        public string Comune { get; set; }
        public string Provincia { get; set; }
        public List<string> Comuni { get; set; }
        public ModelliServiziMarche[] ElencoStrutture { get; set; }
        public string Categoria { get; set; }
        public List<string> Categorie { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
    }
}



