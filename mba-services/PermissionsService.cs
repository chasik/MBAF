using System.Linq;
using System.ServiceModel;
using System.Collections.Generic;

using mba_model;
using mba_services.DataContracts;
using mba_services.ServiceContracts;

namespace mba_services
{
    public class PermissionsService : IPermissionsService
    {
        private HashSet<Permission> listPermissions;

        public PermissionsService()
        {
            AutoMapper.Mapper.CreateMap<mba_model.Permission, mba_services.DataContracts.PermissionDC>();
        }

        public PermissionListDC GetPermissions()
        {
            listPermissions = new HashSet<Permission>();

            PermissionListDC permissions = new PermissionListDC();
            permissions.Login = ServiceSecurityContext.Current.PrimaryIdentity.Name;

            using (ModelContext mcontext = new ModelContext())
            {
                User currentUser = GerUserFromBD(mcontext, permissions.Login);

                currentUser = currentUser ?? AddUserToBD(mcontext, permissions.Login);

                // собрали все разрешения по ролям
                currentUser.Roles.ForEach(r => listPermissions.UnionWith(r.Permissions.ToList()));
                // и подтянули остальные разрешения, задаваемые отдельно для пользователя
                listPermissions.UnionWith(currentUser.Permissions.ToList());
                // мапим на datacontracttype для передачи клиенту
                permissions.Permissions = AutoMapper.Mapper.Map<IEnumerable<Permission>, IEnumerable<PermissionDC>>(listPermissions);
            }
            return permissions;
        }

        private User GerUserFromBD(ModelContext context, string login)
        {
            return (from u in context.Users
                    where u.Login == login
                    select u
                   ).FirstOrDefault();
        }

        private User AddUserToBD(ModelContext context, string login)
        {
            context.Users.Add(new User { Login = login });
            context.SaveChanges();
            return GerUserFromBD(context, login);
        }
    }
}
