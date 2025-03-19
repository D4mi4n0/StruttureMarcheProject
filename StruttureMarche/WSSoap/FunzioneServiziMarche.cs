using Marche.modelli;
using System.ServiceModel;

namespace FunzioneServiziMarche.WSSOAP
{
    [ServiceContract]
    public interface IFunzioneMarche
    {
        [OperationContract]
        public ModelliServiziMarche[] DaiTuttiIServizi();

        [OperationContract]
        public ModelliServiziMarche[] RicercaServizi(String Ricerca);
    }

    public class FunzionePerServizi : IFunzioneMarche
    {
        public ModelliServiziMarche[] DaiTuttiIServizi()
        {
            return FunzioniInterrogazioniServiziMarche.DaiTuttiIServizi().Result;
        }

        public ModelliServiziMarche[] RicercaServizi(string Ricerca)
        {
            return FunzioniInterrogazioniServiziMarche.RicercaServizi(Ricerca).Result;
        }
    }
}
