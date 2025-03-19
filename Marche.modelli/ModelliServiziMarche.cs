using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marche.modelli
{

    public class ModelliServiziMarche
    {
        public string Comune { get; set; }
        public string Provincia { get; set; }

        [JsonProperty("Categoria Struttura")]
        public string CategoriaStruttura { get; set; }
        public string Classificazione { get; set; }
        public string Denominazione { get; set; }
        public string CAP { get; set; }
        public string Indirizzo { get; set; }
        public string Gestore { get; set; }
        public string Citta { get; set; }
        public string Localita { get; set; }
        public string Telefono { get; set; }
        public string FAX { get; set; }
        public string Cellulare { get; set; }

        [JsonProperty("Indirizzo internet")]
        public string Indirizzointernet { get; set; }

        [JsonProperty("Indirizzo di posta elettronica")]
        public string Indirizzodipostaelettronica { get; set; }

        [JsonProperty("Codice ISTAT")]
        public string CodiceISTAT { get; set; }

        [JsonProperty("Numero struttura")]
        public string Numerostruttura { get; set; }
        public string Longitudine { get; set; }
        public string Latitudine { get; set; }
    }
}
