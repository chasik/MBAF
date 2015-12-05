using mba_model;
using System.Collections.Generic;

namespace mba_application.MBAComponents
{
    public class Employee
    {
        public List<PermissionGroup> PermissionGroups;
        public List<Tool> Tools;

        public Employee()
        {
            MBAPhoneEnable = false;
            PermissionGroups = new List<PermissionGroup>();
            Tools = new List<Tool>();
        }

        public bool MBAPhoneEnable { get; private set; }

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
                else if (permission.ParentId == 0) //если это разрешение на инструмент
                {
                    Tools.Add(new Tool(permission));
                    if (permission.Name == "tools-phone")
                        MBAPhoneEnable = true;
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

    public class Tool
    {
        public string HeaderName { get; set; }
        public string ImageName { get; set; }
        public string ContentTemplateName { get; set; }

        public Tool(Permission permission)
        {
            HeaderName = permission.ScreenName;
            ImageName = permission.Image;
            ContentTemplateName = permission.Name;
        }
    }
}
