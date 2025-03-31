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
        public ModelliServiziMarche[] RicercaTutteStrutture(string denominazione, string comune, string provincia);
    }

    public class FunzionePerServizi : IFunzioneMarche
    {
        public ModelliServiziMarche[] DaiTuttiServizi()
        {
            // Uso di .Result per ottenere il risultato sincrono
            return FunzioniInterrogazioniServiziMarche.DaiServizi().Result;
        }

        public ModelliServiziMarche[] RicercaTutteStrutture(string denominazione, string comune, string provincia)
        {
            // Uso di .Result per ottenere il risultato sincrono
            return FunzioniInterrogazioniServiziMarche.RicercaStrutture(denominazione, comune, provincia).Result;
        }
    }
}
