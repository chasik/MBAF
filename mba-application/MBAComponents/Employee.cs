using mba_model;
using System.Collections.Generic;

namespace mba_application.MBAComponents
{
    public class Employee
    {
        public List<PermissionGroup> PermissionGroups;

        public Employee()
        {
            PermissionGroups = new List<PermissionGroup>();
        }

        public bool TryEnter()
        {
            var employeeService = new MBAUserService.UserServiceClient();
            var allPermissions = employeeService.Permissions();

            foreach (Permission permission in allPermissions)
            {
                if (permission.ParentId == null)
                {
                    PermissionGroups.Add(new PermissionGroup(permission));
                }
            }

            foreach (Permission permission in allPermissions)
            {
                // пропускаем с ParentId == null (группы меню) и с ParentId == 0 (инструменты)
                if (permission.ParentId == null || permission.ParentId == 0)
                    continue;

                foreach (PermissionGroup permGroup in PermissionGroups)
                {
                    if (permGroup.ParentPermission.Id == permission.ParentId)
                    {
                        permGroup.Items.Add(permission);
                        break;
                    }
                }
            }
            
            return allPermissions.Length > 0;
        }
    }

    public class PermissionGroup
    {
        public List<Permission> Items { get; set; }
        public bool ShowGroup { get { return Items.Count > 0; } }
        public Permission ParentPermission { get; set; }

        public PermissionGroup(Permission permission)
        {
            ParentPermission = permission;
            Items = new List<Permission>();
        }
    }
}
