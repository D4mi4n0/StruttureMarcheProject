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
        public ModelliServiziMarche[] RicercaServizi(String Ricerca);

        [OperationContract]
        public ModelliServiziMarche[] RicercaServiziPerCategoria();
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

        public ModelliServiziMarche[] RicercaServiziPerCategoria()
        {
            return FunzioniInterrogazioniServiziMarche.RicercaServiziPerCategoria().Result;
        }
    }
}
