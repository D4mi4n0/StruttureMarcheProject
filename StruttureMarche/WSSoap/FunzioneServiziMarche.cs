using Marche.modelli;
using Marche.modelli.Modelli;
using System.ServiceModel;

namespace FunzioneServiziMarche.WSSOAP
{
    [ServiceContract]
    public interface IFunzioneMarche
    {
        [OperationContract]
        public ModelliServiziMarche[] DaiTuttiServizi();

        [OperationContract]
        public ModelliServiziMarche[] RicercaTuttiServizi(string denominazione, string comune, string provincia, string categoria);

        [OperationContract]
        public ModelliServiziMarche[] RicercaServiziPerCategoria();
    }

    public class FunzionePerServizi : IFunzioneMarche
    {
        public ModelliServiziMarche[] DaiTuttiServizi()
        {
            return FunzioniInterrogazioniServiziMarche.DaiServizi().Result;
        }

        public ModelliServiziMarche[] RicercaTuttiServizi(string denominazione, string comune, string provincia, string categoria)
        {
            return FunzioniInterrogazioniServiziMarche.RicercaServizi(denominazione, comune, provincia, categoria).Result;
        }

        public ModelliServiziMarche[] RicercaServiziPerCategoria()
        {
            return FunzioniInterrogazioniServiziMarche.RicercaServiziPerCategoria().Result;
        }
    }
}