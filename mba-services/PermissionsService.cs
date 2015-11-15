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

        public PermissionsDC GetPermissions()
        {
            listPermissions = new HashSet<Permission>();

            PermissionsDC permissions = new PermissionsDC();
            permissions.Login = ServiceSecurityContext.Current.PrimaryIdentity.Name;

            using (ModelContext mcontext = new ModelContext())
            {
                User currentUser = GerUserFromBD(mcontext, permissions.Login);

                currentUser = currentUser ?? AddUserToBD(mcontext, permissions.Login);

                var q = from p in mcontext.Permissions
                        join pg in mcontext.PermissionGroup on p.PermissionGroupId equals pg.Id
                        where p.Roles.Any(r => r.Users.Select(u => u.Id).Contains(currentUser.Id)) 
                                || p.Users.Any(u => u.Id == currentUser.Id)
                        select new PermissionDC { Id = p.Id, GroupName = pg.ScreenName, Name = p.Name, ScreenName = p.ScreenName, CommandParam = p.CommandParam};

                permissions.PermissionsHashSet = q.ToList();
                // собрали все разрешения по ролям
                //currentUser.Roles.ToList().ForEach(r => listPermissions.UnionWith(r.Permissions.ToList()));
                // и подтянули остальные разрешения, задаваемые отдельно для пользователя
                //listPermissions.UnionWith(currentUser.Permissions.ToList());
                // мапим на datacontracttype для передачи клиенту
                //permissions.PermissionsHashSet = AutoMapper.Mapper.Map<IEnumerable<Permission>, IEnumerable<PermissionDC>>(listPermissions);
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
