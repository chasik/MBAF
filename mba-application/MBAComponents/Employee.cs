using System;
using mba_application.MBAPermissionsService;


namespace mba_application.MBAComponents
{
    public class Employee
    {
        public PermissionsDC Permissions;
        public Employee()
        {

        }

        public bool TryEnter()
        {
            var employeeService = new MBAPermissionsService.PermissionsServiceClient();
            Permissions = employeeService.GetPermissions();

            return Permissions.PermissionsHashSet.Length > 0;
        }
    }
}
