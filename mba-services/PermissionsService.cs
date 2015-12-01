using System.Linq;
using System.ServiceModel;

using mba_model;
using mba_services.ServiceContracts;

namespace mba_services
{
    public class PermissionsService : IPermissionsService
    {
        public ModelContext dbContext;

        public PermissionsService()
        {
            dbContext = new ModelContext();
            dbContext.Configuration.ProxyCreationEnabled = false;
        }

        public Permission[] Permissions()
        {
            var currentLogin = ServiceSecurityContext.Current.PrimaryIdentity.Name;
            User currentUser = GerUserFromBD(currentLogin);
            currentUser = currentUser ?? AddUserToBD(currentLogin);

            return (from p in dbContext.Permissions
                    where p.Roles.Any(r => r.Users.Select(u => u.Id).Contains(currentUser.Id))
                           || p.Users.Any(u => u.Id == currentUser.Id)
                    orderby p.ParentId
                    select p
                   ).ToArray();
        }

        public User[] Users()
        {
            return (from u in dbContext.Users
                    select u).ToArray();
        }

        private User GerUserFromBD(string login)
        {
            return (from u in dbContext.Users
                    where u.Login == login
                    select u
                   ).FirstOrDefault();
        }

        private User AddUserToBD(string login)
        {
            dbContext.Users.Add(new User { Login = login });
            dbContext.SaveChanges();
            return GerUserFromBD(login);
        }
    }
}
