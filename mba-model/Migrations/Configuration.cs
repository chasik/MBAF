namespace mba_model.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<mba_model.ModelContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(mba_model.ModelContext context)
        {
            context.Roles.AddOrUpdate(
                r => r.Id,
                new Role { Id = 1, Name = "administrator", ScreenName = "������������� �������" },
                new Role { Id = 2, Name = "leadership", ScreenName = "�����������" },
                new Role { Id = 3, Name = "programmer", ScreenName = "�����������" },
                new Role { Id = 4, Name = "operator", ScreenName = "�������� ����-������" },
                new Role { Id = 5, Name = "head", ScreenName = "������� �������" },
                new Role { Id = 6, Name = "curator", ScreenName = "������� �������" },
                new Role { Id = 7, Name = "import", ScreenName = "������" },
                new Role { Id = 8, Name = "analytics", ScreenName = "���������" },
                new Role { Id = 9, Name = "search", ScreenName = "����� ������" },
                new Role { Id = 10, Name = "report", ScreenName = "������" }
                );

            context.PermissionGroup.AddOrUpdate(
                pg => pg.Id,
                new PermissionGroup { Id = 1, Name = "menu-processing", ScreenName = "����������", Tooltip = "������ ���� ��� ������ ���������", ImageSource = "" },
                new PermissionGroup { Id = 2, Name = "menu-head", ScreenName = "�������", Tooltip = "������ ���� ��� ������ ��������", ImageSource = "" },
                new PermissionGroup { Id = 3, Name = "menu-import", ScreenName = "������", Tooltip = "������ ���� ��� ������� ��������, �������������, ��������", ImageSource = "" },
                new PermissionGroup { Id = 4, Name = "menu-analytics", ScreenName = "���������", Tooltip = "������ ���� ���������", ImageSource = "" },
                new PermissionGroup { Id = 5, Name = "menu-report", ScreenName = "������", Tooltip = "������ ���� ��������� ����������", ImageSource = "" },
                new PermissionGroup { Id = 6, Name = "menu-search", ScreenName = "�����", Tooltip = "������ ���� ��� ������ ������ ������", ImageSource = "" },
                new PermissionGroup { Id = 7, Name = "menu-leadership", ScreenName = "�����������", Tooltip = "������ ���� �����������", ImageSource = "" },
                new PermissionGroup { Id = 8, Name = "menu-admin", ScreenName = "�����������������", Tooltip = "������ ���� ����������������� �������", ImageSource = "" }
                );

            context.Permissions.AddOrUpdate(
                p => p.Id,
                new Permission { Id = 1, PermissionGroupId = 1, Name = "menu-processing-work", ScreenName = "�������", Tooltip = "������� ������������ ���������", ImageSource = "", CommandParam="" },
                new Permission { Id = 2, PermissionGroupId = 1, Name = "menu-processing-table", ScreenName = "������", Tooltip = "�������������� ������ ��� ����������", ImageSource = "", CommandParam = "" },
                new Permission { Id = 3, PermissionGroupId = 8, Name = "menu-admin-users", ScreenName = "������������", Tooltip = "��������� ���������� ��� �������������", ImageSource = "", CommandParam = "" },
                new Permission { Id = 4, PermissionGroupId = 8, Name = "menu-admin-aster", ScreenName = "Asterisk", Tooltip = "��������� � ���������� Asterisk", ImageSource = "", CommandParam = "" }
                );

            context.Actions.AddOrUpdate(
                a => a.Id,
                new mba_model.Action { Id = 1, Name = "create", Description = "�������� ������������" },
                new mba_model.Action { Id = 2, Name = "try_enter", Description = "������� ����� ������������ � �������" },
                new mba_model.Action { Id = 3, Name = "enter", Description = "���� ������������ � �������" },
                new mba_model.Action { Id = 4, Name = "exit", Description = "����� ������������ �� �������" },
                new mba_model.Action { Id = 5, Name = "freezing", Description = "'���������' ������������" },
                new mba_model.Action { Id = 6, Name = "defrost", Description = "'����������' ������������" }
                );

            context.Users.AddOrUpdate(
                u => u.Id,
                new User { Id = 1, Login = "MBARU\\Ivan_Chasov", FirstName = "����", MiddleName = "�����������", LastName = "�����", Email = "chasow@yandex.ru" }
                );

            Role adminRole = context.Roles.Find(1);

            adminRole.Users.Add(context.Users.Find(1));

            context.Permissions.ToList().ForEach(p => {
                adminRole.Permissions.Add(p);
            });
            context.SaveChanges();
        }
    }
}
