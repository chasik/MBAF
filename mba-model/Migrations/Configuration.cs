namespace mba_model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<mba_model.ModelContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
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
                new Permission { Id = 1, PermissionGroupId = 1, Name = "menu-processing-work", ScreenName = "�������",
                                 Tooltip = "������� ������������ ���������", ImageSource = "", CommandParam = "" },
                new Permission { Id = 2, PermissionGroupId = 1, Name = "menu-processing-table", ScreenName = "������",
                                 Tooltip = "�������������� ������ ��� ����������", ImageSource = "", CommandParam = "" },
                new Permission { Id = 3, PermissionGroupId = 8, Name = "menu-admin-users", ScreenName = "������������",
                                 Tooltip = "��������� ���������� ��� �������������", ImageSource = "", CommandParam = "AdminUsersView" },
                new Permission { Id = 4, PermissionGroupId = 8, Name = "menu-admin-aster", ScreenName = "Asterisk",
                                 Tooltip = "��������� � ���������� Asterisk", ImageSource = "", CommandParam = "AdminAsteriskView" },
                new Permission { Id = 5, PermissionGroupId = 3, Name = "menu-import-registry", ScreenName = "�������",
                                 Tooltip = "������ ��������", ImageSource = "", CommandParam = "RegistryAddView" }
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
                new User { Id = 1, Login = "MBARU\\Ivan_Chasov", FirstName = "����", MiddleName = "�����������", LastName = "�����", Email = "chasow@yandex.ru" },
                new User { Id = 2, Login = "NEWPROG\\ich", FirstName = "����", MiddleName = "�����������", LastName = "�����", Email = "chasow@yandex.ru" }
                );

            context.Clients.AddOrUpdate(
                c => c.Id,
                new Client { Id = 1, InnerId = 202, Name = "��������� ���� ������������� � ��������", FullName = "��� \"��������� ���� ������������� � ��������\"", Created = DateTime.Now, CreatedBy = 1 },
                new Client { Id = 2, InnerId = 205, Name = "���-����", FullName = "��� \"���-����\"", Created = DateTime.Now, CreatedBy = 1, Deleted = DateTime.Now, DeletedBy = 1 },
                new Client { Id = 3, InnerId = 248, Name = "���-����", FullName = "��� \"���-����\"", Created = DateTime.Now, CreatedBy = 1 },
                new Client { Id = 4, InnerId = 219, Name = "��������� ������", FullName = "��� �� \"��������� ������\"", Created = DateTime.Now, CreatedBy = 1, Deleted = DateTime.Now, DeletedBy = 1 },
                new Client { Id = 5, InnerId = 250, Name = "��������� ������", FullName = "��� �� \"��������� ������\"", Created = DateTime.Now, CreatedBy = 1 }
                );

            context.GoodColumns.AddOrUpdate(
                gc => gc.Id,
                new GoodColumn { Id = 1, Name = "������� ��������", Created = DateTime.Now, CreatedBy = 1 },
                new GoodColumn { Id = 2, Name = "��� ��������", Created = DateTime.Now, CreatedBy = 1 },
                new GoodColumn { Id = 3, Name = "�������� ��������", Created = DateTime.Now, CreatedBy = 1 },

                new GoodColumn { Id = 4, Name = "����� �������� ��������", Created = DateTime.Now, CreatedBy = 1 },
                new GoodColumn { Id = 5, Name = "����� �������� ��������", Created = DateTime.Now, CreatedBy = 1 },
                new GoodColumn { Id = 6, Name = "��� ����� ������� ��������", Created = DateTime.Now, CreatedBy = 1 },
                new GoodColumn { Id = 7, Name = "���� ������ �������� ��������", Created = DateTime.Now, CreatedBy = 1 },

                new GoodColumn { Id = 8, Name = "����� �����������(��������) ��������", Created = DateTime.Now, CreatedBy = 1 },
                new GoodColumn { Id = 9, Name = "����������� ����� ���������� ��������", Created = DateTime.Now, CreatedBy = 1 },
                new GoodColumn { Id = 10, Name = "��� ��������", Created = DateTime.Now, CreatedBy = 1 },
                new GoodColumn { Id = 11, Name = "���� �������� ��������", Created = DateTime.Now, CreatedBy = 1 },
                new GoodColumn { Id = 12, Name = "����� � ����� ��������", Created = DateTime.Now, CreatedBy = 1 },
                new GoodColumn { Id = 13, Name = "��� � ����� ����� �������", Created = DateTime.Now, CreatedBy = 1 }
                );

            context.ImportTypes.AddOrUpdate(
                it => it.Id,
                new ImportType { Id = 1, Name = "������ ��������\\���" },
                new ImportType { Id = 2, Name = "������� �� ��������" },
                new ImportType { Id = 3, Name = "������������� �� ��������" },
                new ImportType { Id = 4, Name = "�������������� ��������" }
                );

            context.SaveChanges();

            Role adminRole = context.Roles.Find(1);

            adminRole.Users.Add(context.Users.Find(1));
            adminRole.Users.Add(context.Users.Find(2));

            context.Permissions.ToList().ForEach(p => {
                adminRole.Permissions.Add(p);
            });
            context.SaveChanges();
        }
    }
}
