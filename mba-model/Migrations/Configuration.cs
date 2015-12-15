namespace mba_model.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<mba_model.ModelContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(mba_model.ModelContext context)
        {

            #region Roles
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
            #endregion

            #region Permissions
            context.Permissions.AddOrUpdate(
                p => p.Id,
                new Permission { Id = 1, ParentId = null, Name = "menu-processing", ScreenName = "����������", Tooltip = "������ ���� ��� ������ ���������", Image = "menu-group-operator.png" },
                new Permission { Id = 2, ParentId = null, Name = "menu-lead", ScreenName = "������", Tooltip = "������ ���� ��� ������ ��������� �������", Image = "menu-group-lead.png" },
                new Permission { Id = 3, ParentId = null, Name = "menu-import", ScreenName = "������", Tooltip = "������ ���� ��� ������� ��������, �������������, ��������", Image = "menu-group-import.png" },
                new Permission { Id = 4, ParentId = null, Name = "menu-analytics", ScreenName = "���������", Tooltip = "������ ���� ���������", Image = "menu-group-analytics.png" },
                new Permission { Id = 5, ParentId = null, Name = "menu-report", ScreenName = "������", Tooltip = "������ ���� ��������� ����������", Image = "menu-group-report.png" },
                new Permission { Id = 6, ParentId = null, Name = "menu-search", ScreenName = "�����", Tooltip = "������ ���� ��� ������ ������ ������", Image = "menu-group-search.png" },
                new Permission { Id = 7, ParentId = null, Name = "menu-leadership", ScreenName = "�����������", Tooltip = "������ ���� �����������", Image = "menu-group-leadership.png" },
                new Permission { Id = 8, ParentId = null, Name = "menu-admin", ScreenName = "�����������������", Tooltip = "������ ���� ����������������� �������", Image = "menu-group-admin.png" },

                new Permission { Id = 9, ParentId = 0, Name = "tools-phone", ScreenName = "MBA Phone", Tooltip = "��������� ������ ��������", Image = "tools-phone.png" },
                new Permission { Id = 10, ParentId = 0, Name = "tools-phone-history", ScreenName = "�������", Tooltip = "������� �������", Image = "tools-call-history.png" },
                new Permission { Id = 11, ParentId = 0, Name = "tools-calc", ScreenName = "�����������", Tooltip = "�������� �����������", Image = "tools-calc.png" },
                new Permission { Id = 12, ParentId = 0, Name = "tools-chat", ScreenName = "���", Tooltip = "�������� ������ �����", Image = "tools-chat.png" },

                new Permission { Id = 13, ParentId = 1, Name = "menu-processing-work", ScreenName = "�������", Tooltip = "������� ������������ ���������", Image = "menu-item-processing-operator.png", CommandParam = "OperatorWorkflowView" },
                new Permission { Id = 14, ParentId = 1, Name = "menu-processing-task", ScreenName = "�������", Tooltip = "�������������� ������ ��� ����������", Image = "menu-item-processing-task.png", CommandParam = "" },
                new Permission { Id = 15, ParentId = 1, Name = "menu-processing-table", ScreenName = "������", Tooltip = "�������������� ������ ��� ����������", Image = "menu-item-processing-table.png", CommandParam = "" },
                new Permission { Id = 16, ParentId = 2, Name = "menu-lead-operators", ScreenName = "�������", Tooltip = "������������ ������� (�������) ��� ����������", Image = "menu-item-lead-operators.png", CommandParam = "ManagerTasksView" },
                new Permission { Id = 17, ParentId = 2, Name = "menu-lead-dialer", ScreenName = "Dialer", Tooltip = "������� ��� ��������������� ����������", Image = "menu-item-lead-dialer.png", CommandParam = "ManagerAutoTasksView" },
                new Permission { Id = 18, ParentId = 2, Name = "menu-lead-registry", ScreenName = "�������", Tooltip = "������ � ��������� �� �������", Image = "menu-item-lead-registry.png", CommandParam = "" },
                new Permission { Id = 19, ParentId = 2, Name = "menu-lead-monitoring", ScreenName = "����������", Tooltip = "���������� ���������� ����������", Image = "menu-item-lead-monitoring.png", CommandParam = "" },
                new Permission { Id = 20, ParentId = 2, Name = "menu-lead-tables", ScreenName = "������", Tooltip = "���������� �������", Image = "menu-item-lead-table.png", CommandParam = "" },
                new Permission { Id = 21, ParentId = 3, Name = "menu-import-registry", ScreenName = "�������", Tooltip = "������ ��������", Image = "menu-item-import-registry.png", CommandParam = "RegistryAddView" },
                new Permission { Id = 22, ParentId = 4, Name = "menu-analytics-dashboard", ScreenName = "����������", Tooltip = "������� ��������� ����-������", Image = "menu-item-analytics-dashboard.png", CommandParam = "" },
                new Permission { Id = 23, ParentId = 5, Name = "menu-report-reports", ScreenName = "������", Tooltip = "��������� �������", Image = "menu-item-report-reports.png", CommandParam = "" },
                new Permission { Id = 24, ParentId = 6, Name = "menu-search-address", ScreenName = "�������", Tooltip = "����� � �������� �������", Image = "menu-item-search-address.png", CommandParam = "" },
                new Permission { Id = 25, ParentId = 6, Name = "menu-search-phone", ScreenName = "��������", Tooltip = "����� � �������� ���������", Image = "menu-item-search-phone.png", CommandParam = "" },
                new Permission { Id = 26, ParentId = 6, Name = "menu-search-opp", ScreenName = "���", Tooltip = "����� ���������������� ������", Image = "menu-item-search-opp.png", CommandParam = "" },
                new Permission { Id = 27, ParentId = 7, Name = "menu-leadership-dashboard", ScreenName = "����������", Tooltip = "���������� �������� ��������", Image = "menu-item-leadership-dashboard.png", CommandParam = "" },
                new Permission { Id = 28, ParentId = 8, Name = "menu-admin-users", ScreenName = "������������", Tooltip = "��������� ���������� ��� �������������", Image = "menu-item-admin-users.png", CommandParam = "AdminUsersView" },
                new Permission { Id = 29, ParentId = 8, Name = "menu-admin-roles", ScreenName = "���� / ����������", Tooltip = "�������������� ����� � ����������", Image = "menu-item-admin-roles.png", CommandParam = "AdminRolesView" },
                new Permission { Id = 30, ParentId = 8, Name = "menu-admin-aster", ScreenName = "Asterisk", Tooltip = "��������� � ���������� Asterisk", Image = "menu-item-admin-aster.png", CommandParam = "AdminAsteriskView" }
                );
            #endregion

            #region UserActions
            context.Actions.AddOrUpdate(
                a => a.Id,
                new mba_model.Action { Id = 1, Name = "create", Description = "�������� ������������" },
                new mba_model.Action { Id = 2, Name = "try_enter", Description = "������� ����� ������������ � �������" },
                new mba_model.Action { Id = 3, Name = "enter", Description = "���� ������������ � �������" },
                new mba_model.Action { Id = 4, Name = "exit", Description = "����� ������������ �� �������" },
                new mba_model.Action { Id = 5, Name = "freezing", Description = "'���������' ������������" },
                new mba_model.Action { Id = 6, Name = "defrost", Description = "'����������' ������������" }
                );
            #endregion

            #region Users
            context.Users.AddOrUpdate(
                u => u.Id,
                new User { Id = 1, Login = "MBARU\\Ivan_Chasov", FirstName = "����", MiddleName = "�����������", LastName = "�����", Email = "chasow@yandex.ru" },
                new User { Id = 2, Login = "DESKTOP-22AR0VL\\ich", FirstName = "����", MiddleName = "�����������", LastName = "�����", Email = "chasow@yandex.ru" }
                );
            #endregion

            #region Clients
            context.Clients.AddOrUpdate(
                c => c.Id,
                new Client { Id = 1, ParentId = null, InnerId = 202, Name = "��������� ���� ������������� � ��������", FullName = "��� \"��������� ���� ������������� � ��������\"", Image = "ClientDefault.png", Created = DateTime.Now, CreatedBy = 1 },
                new Client { Id = 2, ParentId = null, InnerId = 205, Name = "���-����", FullName = "��� \"���-����\"", Image = "ClientMTSbank.png", Created = DateTime.Now, CreatedBy = 1 },
                new Client { Id = 3, ParentId = null, InnerId = 248, Name = "���-����", FullName = "��� \"���-����\"", Image = "ClientMTSbank.png", Created = DateTime.Now, CreatedBy = 1 },
                new Client { Id = 4, ParentId = null, InnerId = 206, Name = "����������� ����", FullName = "��� \"����������� ����\"", Image = "ClientDefault.png", Created = DateTime.Now, CreatedBy = 1 },
                new Client { Id = 5, ParentId = null, InnerId = 212, Name = "����������", FullName = "��� �������������� ������������ ���� \"����������\"", Image = "ClientDefault.png", Created = DateTime.Now, CreatedBy = 1 },
                new Client { Id = 6, ParentId = null, InnerId = 214, Name = "��������� �������� ����", FullName = "��� \"��������� �������� ����\"", Image = "ClientDefault.png", Created = DateTime.Now, CreatedBy = 1 },
                new Client { Id = 7, ParentId = null, InnerId = 217, Name = "�������� ������", FullName = "��� \"�������� ������\"", Image = "ClientDefault.png", Created = DateTime.Now, CreatedBy = 1 },
                new Client { Id = 8, ParentId = null, InnerId = 219, Name = "��������� ������", FullName = "��� �� \"��������� ������\"", Image = "ClientDefault.png", Created = DateTime.Now, CreatedBy = 1 },
                new Client { Id = 9, ParentId = null, InnerId = 220, Name = "������� ����", FullName = "��� \"������� ����\"", Image = "ClientDefault.png", Created = DateTime.Now, CreatedBy = 1 },
                new Client { Id = 10, ParentId = null, InnerId = 221, Name = "���24", FullName = "��� \"���24\"", Image = "ClientDefault.png", Created = DateTime.Now, CreatedBy = 1 },
                new Client { Id = 11, ParentId = null, InnerId = 223, Name = "���� ������ ��� ������ ����", FullName = "��� \"���� ������ ��� ������ ����\"", Image = "ClientDefault.png", Created = DateTime.Now, CreatedBy = 1 },
                new Client { Id = 12, ParentId = null, InnerId = 227, Name = "��� ����", FullName = "�� \"��� ����\"", Image = "ClientDefault.png", Created = DateTime.Now, CreatedBy = 1 },
                new Client { Id = 13, ParentId = null, InnerId = 231, Name = "�������������", FullName = "��� \"�������������\"", Image = "ClientDefault.png", Created = DateTime.Now, CreatedBy = 1 },
                new Client { Id = 14, ParentId = null, InnerId = 234, Name = "�����", FullName = "��� �� \"�����\"", Image = "ClientDefault.png", Created = DateTime.Now, CreatedBy = 1 },
                new Client { Id = 15, ParentId = null, InnerId = 238, Name = "�����-���������� ���� ��������", FullName = "��� \"�����-���������� ���� ��������\"", Image = "ClientDefault.png", Created = DateTime.Now, CreatedBy = 1 },
                new Client { Id = 16, ParentId = null, InnerId = 240, Name = "�����", FullName = "��� �� \"�����\"", Image = "ClientDefault.png", Created = DateTime.Now, CreatedBy = 1 },
                new Client { Id = 17, ParentId = null, InnerId = 242, Name = "���� ����", FullName = "��� \"���� ����\"", Image = "ClientDefault.png", Created = DateTime.Now, CreatedBy = 1 },
                new Client { Id = 18, ParentId = null, InnerId = 245, Name = "���-����", FullName = "��� \"���-����\"", Image = "ClientDefault.png", Created = DateTime.Now, CreatedBy = 1 },
                new Client { Id = 19, ParentId = null, InnerId = 246, Name = "������� ��������� �����", FullName = "�� \"������� ��������� �����\"", Image = "ClientDefault.png", Created = DateTime.Now, CreatedBy = 1 },
                new Client { Id = 20, ParentId = null, InnerId = 249, Name = "���� ������", FullName = "���� ������", Image = "ClientDefault.png", Created = DateTime.Now, CreatedBy = 1 },
                new Client { Id = 21, ParentId = null, InnerId = 251, Name = "��� ��������", FullName = "��������� ����������� �������� ��������� ������", Image = "ClientSber.png", Created = DateTime.Now, CreatedBy = 1 },
                new Client { Id = 22, ParentId = null, InnerId = 252, Name = "��������-������������� ����", FullName = "��� \"��������-������������� ����\"", Image = "ClientDefault.png", Created = DateTime.Now, CreatedBy = 1 },
                new Client { Id = 23, ParentId = null, InnerId = 253, Name = "�������", FullName = "��� \"�������\"", Image = "ClientDefault.png", Created = DateTime.Now, CreatedBy = 1 },
                new Client { Id = 24, ParentId = null, InnerId = 254, Name = "�������", FullName = "��� \"�������\"", Image = "ClientDefault.png", Created = DateTime.Now, CreatedBy = 1 },
                new Client { Id = 25, ParentId = null, InnerId = 255, Name = "���������� ��������� ����", FullName = "��� \"���������� ��������� ����\"", Image = "ClientDefault.png", Created = DateTime.Now, CreatedBy = 1 },
                new Client { Id = 26, ParentId = null, InnerId = 256, Name = "�����", FullName = "��� \"�����\"", Image = "ClientDefault.png", Created = DateTime.Now, CreatedBy = 1 },
                new Client { Id = 27, ParentId = null, InnerId = 257, Name = "���� ����", FullName = "�� \"���� ����\"", Image = "ClientDefault.png", Created = DateTime.Now, CreatedBy = 1 },
                new Client { Id = 28, ParentId = null, InnerId = 258, Name = "����", FullName = "�� \"����\"", Image = "ClientDefault.png", Created = DateTime.Now, CreatedBy = 1 },
                new Client { Id = 29, ParentId = null, InnerId = 413, Name = "�������-������", FullName = "��� ��� \"�������-������\"", Image = "ClientDefault.png", Created = DateTime.Now, CreatedBy = 1 }
                );
            #endregion

            #region Project
            context.Projects.AddOrUpdate(
                proj => proj.Id,
                new Project { Id = 1, ClientId = 6, Name = "��������" }
                );
            #endregion

            #region GoodColumns
            context.GoodColumns.AddOrUpdate(
                gc => gc.Id,
                new GoodColumn { Id = 1, Name = "��� ��������", Created = DateTime.Now, CreatedBy = 1 },
                new GoodColumn { Id = 2, Name = "������� ��������", Created = DateTime.Now, CreatedBy = 1 },
                new GoodColumn { Id = 3, Name = "��� ��������", Created = DateTime.Now, CreatedBy = 1 },
                new GoodColumn { Id = 4, Name = "�������� ��������", Created = DateTime.Now, CreatedBy = 1 },
                new GoodColumn { Id = 5, Name = "���� �������� ��������", Created = DateTime.Now, CreatedBy = 1 },
                new GoodColumn { Id = 6, Name = "����� �������� ��������", Created = DateTime.Now, CreatedBy = 1 },

                new GoodColumn { Id = 7, Name = "��� ��������", Created = DateTime.Now, CreatedBy = 1 },

                new GoodColumn { Id = 8, Name = "����� � ����� �������� ��������", Created = DateTime.Now, CreatedBy = 1 },
                new GoodColumn { Id = 9, Name = "��� � ����� ����� ������� ��������", Created = DateTime.Now, CreatedBy = 1 },
                new GoodColumn { Id = 10, Name = "����� �������� ��������", Created = DateTime.Now, CreatedBy = 1 },
                new GoodColumn { Id = 11, Name = "����� �������� ��������", Created = DateTime.Now, CreatedBy = 1 },
                new GoodColumn { Id = 12, Name = "��� ����� ������� ��������", Created = DateTime.Now, CreatedBy = 1 },
                new GoodColumn { Id = 13, Name = "���� ������ �������� ��������", Created = DateTime.Now, CreatedBy = 1 },

                new GoodColumn { Id = 14, Name = "����� �����������(��������) ��������", Created = DateTime.Now, CreatedBy = 1 },
                new GoodColumn { Id = 15, Name = "����������� ����� ���������� ��������", Created = DateTime.Now, CreatedBy = 1 },

                new GoodColumn { Id = 16, Name = "��������� ������� ��������", Created = DateTime.Now, CreatedBy = 1 },
                new GoodColumn { Id = 17, Name = "������� ������ ����������� ��������", Created = DateTime.Now, CreatedBy = 1 },
                new GoodColumn { Id = 18, Name = "������� ������������ ����� ����������", Created = DateTime.Now, CreatedBy = 1 },
                new GoodColumn { Id = 19, Name = "������� ������� ��������", Created = DateTime.Now, CreatedBy = 1 },

                new GoodColumn { Id = 20, Name = "����� ���������� ��������", Created = DateTime.Now, CreatedBy = 1 },
                new GoodColumn { Id = 21, Name = "��� �������� (�������)", Created = DateTime.Now, CreatedBy = 1 },
                new GoodColumn { Id = 22, Name = "��������� ������������ ��������", Created = DateTime.Now, CreatedBy = 1 },
                new GoodColumn { Id = 23, Name = "����� ����� ��� ��������� �������������", Created = DateTime.Now, CreatedBy = 1 },
                new GoodColumn { Id = 24, Name = "���� �������������� �������", Created = DateTime.Now, CreatedBy = 1 }
                );
            #endregion

            #region ImportTypes
            context.ImportTypes.AddOrUpdate(
                it => it.Id,
                new ImportType { Id = 1, Name = "������ ��������" },
                new ImportType { Id = 2, Name = "������� �� ��������" },
                new ImportType { Id = 3, Name = "������������� �� ��������" },
                new ImportType { Id = 4, Name = "�������������� ��������" },
                new ImportType { Id = 5, Name = "����������� ����������� �����" }
                );
            #endregion

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
