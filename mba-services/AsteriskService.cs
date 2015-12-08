using AsterNET.ARI;
using mba_services.ServiceContracts;

namespace mba_services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AsteriskService" in both code and config file together.
    public class AsteriskService : IAsteriskService
    {
        public static AriClient ActionClient;

        public void DoWork()
        {
            ActionClient = new AriClient(new StasisEndpoint("10.100.3.44", 8088, "asterisk", "heslox"), "wcf-service");

            ActionClient.OnStasisStartEvent += ActionClient_OnStasisStartEvent;
            ActionClient.OnStasisEndEvent += ActionClient_OnStasisEndEvent; 

            ActionClient.Connect();
        }

        private void ActionClient_OnStasisEndEvent(IAriClient sender, AsterNET.ARI.Models.StasisEndEvent e)
        {
            throw new System.NotImplementedException();
        }

        private void ActionClient_OnStasisStartEvent(IAriClient sender, AsterNET.ARI.Models.StasisStartEvent e)
        {
            throw new System.NotImplementedException();
        }
    }
}
