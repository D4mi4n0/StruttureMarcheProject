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
        public ModelliServiziMarche[] RicercaTuttiServizi(string denominazione);
    }

    public class FunzionePerServizi : IFunzioneMarche
    {
        public ModelliServiziMarche[] DaiTuttiServizi()
        {
            return FunzioniInterrogazioniServiziMarche.DaiServizi().Result;
        }

        public ModelliServiziMarche[] RicercaTuttiServizi(string denominazione)
        {
            return FunzioniInterrogazioniServiziMarche.RicercaServizi(denominazione).Result;
        }

    
    }
}