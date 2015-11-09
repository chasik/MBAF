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

            context.Permissions.AddOrUpdate(
                p => p.Id,
                new Permission { Id = 1, ParentId = null, Name = "menu-processing", ScreenName = "����������", Tooltip = "������ ���� ��� ������ ���������" },
                new Permission { Id = 2, ParentId = null, Name = "menu-head", ScreenName = "�������", Tooltip = "������ ���� ��� ������ ��������" },
                new Permission { Id = 3, ParentId = null, Name = "menu-import", ScreenName = "������", Tooltip = "������ ���� ��� ������� ��������, �������������, ��������" },
                new Permission { Id = 4, ParentId = null, Name = "menu-analytics", ScreenName = "���������", Tooltip = "������ ���� ���������" },
                new Permission { Id = 5, ParentId = null, Name = "menu-report", ScreenName = "������", Tooltip = "������ ���� ��������� ����������" },
                new Permission { Id = 6, ParentId = null, Name = "menu-search", ScreenName = "�����", Tooltip = "������ ���� ��� ������ ������ ������" },
                new Permission { Id = 7, ParentId = null, Name = "menu-leadership", ScreenName = "�����������", Tooltip = "������ ���� �����������" },
                new Permission { Id = 8, ParentId = null, Name = "menu-admin", ScreenName = "�����������������", Tooltip = "������ ���� ����������������� �������" }
                );
        }
    }
}
