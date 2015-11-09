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
                new Role { Id = 1, Name = "administrator", ScreenName = "Администратор системы" },
                new Role { Id = 2, Name = "leadership", ScreenName = "Руководство" },
                new Role { Id = 3, Name = "programmer", ScreenName = "Программист" },
                new Role { Id = 4, Name = "operator", ScreenName = "Оператор колл-центра" },
                new Role { Id = 5, Name = "head", ScreenName = "Старший проекта" },
                new Role { Id = 6, Name = "curator", ScreenName = "Куратор проекта" },
                new Role { Id = 7, Name = "import", ScreenName = "Импорт" },
                new Role { Id = 8, Name = "analytics", ScreenName = "Аналитика" },
                new Role { Id = 9, Name = "search", ScreenName = "Отдел поиска" },
                new Role { Id = 10, Name = "report", ScreenName = "Отчеты" }
                );

            context.Permissions.AddOrUpdate(
                p => p.Id,
                new Permission { Id = 1, ParentId = null, Name = "menu-processing", ScreenName = "Процессинг", Tooltip = "Раздел меню для работы оператора" },
                new Permission { Id = 2, ParentId = null, Name = "menu-head", ScreenName = "Старший", Tooltip = "Раздел меню для работы старшего" },
                new Permission { Id = 3, ParentId = null, Name = "menu-import", ScreenName = "Импорт", Tooltip = "Раздел меню для импорта реестров, корректировок, платежей" },
                new Permission { Id = 4, ParentId = null, Name = "menu-analytics", ScreenName = "Аналитика", Tooltip = "Раздел меню аналитики" },
                new Permission { Id = 5, ParentId = null, Name = "menu-report", ScreenName = "Отчеты", Tooltip = "Раздел меню просмотра отчетности" },
                new Permission { Id = 6, ParentId = null, Name = "menu-search", ScreenName = "Поиск", Tooltip = "Раздел меню для работы отдела поиска" },
                new Permission { Id = 7, ParentId = null, Name = "menu-leadership", ScreenName = "Руководство", Tooltip = "Раздел меню руководства" },
                new Permission { Id = 8, ParentId = null, Name = "menu-admin", ScreenName = "Администрирование", Tooltip = "Раздел меню администрирование системы" }
                );
        }
    }
}
