using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using mba_model;

namespace mba_application.ViewModels.Admin
{
    [POCOViewModel]
    public class AdminAsteriskViewModel
    {
        private MBAAsteriskService.AsteriskServiceClient AsteriskService;
        public virtual AsteriskSipPeer[] SipPeers { get; set; }

        protected AdminAsteriskViewModel()
        {
            AsteriskService = new MBAAsteriskService.AsteriskServiceClient();
        }

        public AdminAsteriskViewModel Create()
        {
            return ViewModelSource.Create(() => new AdminAsteriskViewModel());
        }

        public void SipPeersUpdate()
        {
            SipPeers = AsteriskService.GetAllSipPeers();
        }
    }
}