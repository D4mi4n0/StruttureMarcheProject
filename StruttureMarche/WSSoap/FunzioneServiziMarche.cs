using Marche.modelli;
using Marche.modelli.Modelli;
using System.ServiceModel;

namespace FunzioneServiziMarche.WSSOAP
{
    [ServiceContract]
    public interface IFunzioneMarche
    {
        [OperationContract]
        public ModelliServiziMarche[] DaiTuttiIServizi();

        [OperationContract]
        public ModelliServiziMarche[] RicercaTuttiServizi(String Ricerca);
    }

    public class FunzionePerServizi : IFunzioneMarche
    {
        public ModelliServiziMarche[] DaiTuttiIServizi()
        {
            return FunzioniInterrogazioniServiziMarche.DaiServizi().Result;
        }

        public ModelliServiziMarche[] RicercaTuttiServizi(string Ricerca)
        {
            return FunzioniInterrogazioniServiziMarche.RicercaServizi(Ricerca).Result;
        }
    }
}
