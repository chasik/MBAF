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
                new Permission { Id = 1, ParentId = null, Name = "menu-processing", ScreenName = "Процессинг", Tooltip = "Раздел меню для работы оператора", ImageSource = "" },
                new Permission { Id = 2, ParentId = null, Name = "menu-head", ScreenName = "Старший", Tooltip = "Раздел меню для работы старшего", ImageSource = "" },
                new Permission { Id = 3, ParentId = null, Name = "menu-import", ScreenName = "Импорт", Tooltip = "Раздел меню для импорта реестров, корректировок, платежей", ImageSource = "" },
                new Permission { Id = 4, ParentId = null, Name = "menu-analytics", ScreenName = "Аналитика", Tooltip = "Раздел меню аналитики", ImageSource = "" },
                new Permission { Id = 5, ParentId = null, Name = "menu-report", ScreenName = "Отчеты", Tooltip = "Раздел меню просмотра отчетности", ImageSource = "" },
                new Permission { Id = 6, ParentId = null, Name = "menu-search", ScreenName = "Поиск", Tooltip = "Раздел меню для работы отдела поиска", ImageSource = "" },
                new Permission { Id = 7, ParentId = null, Name = "menu-leadership", ScreenName = "Руководство", Tooltip = "Раздел меню руководства", ImageSource = "" },
                new Permission { Id = 8, ParentId = null, Name = "menu-admin", ScreenName = "Администрирование", Tooltip = "Раздел меню администрирование системы", ImageSource = "" }
                );

            context.Actions.AddOrUpdate(
                a => a.Id, 
                new mba_model.Action { Id = 1, Name = "create", Description = "Создание пользователя" },
                new mba_model.Action { Id = 2, Name = "try_enter", Description = "Попытка входа пользователя в систему" },
                new mba_model.Action { Id = 3, Name = "enter", Description = "Вход пользователя в систему" },
                new mba_model.Action { Id = 4, Name = "exit", Description = "Выход пользователя из системы" },
                new mba_model.Action { Id = 5, Name = "freezing", Description = "'Заморозка' пользователя" },
                new mba_model.Action { Id = 6, Name = "defrost", Description = "'Разморозка' пользователя" }
                );

            context.Users.AddOrUpdate(
                u => u.Id,
                new User { Id = 1, Login = "MBARU\\Ivan_Chasov", FirstName = "Иван", MiddleName = "Анатольевич", LastName = "Часов", Email = "chasow@yandex.ru" }
                );

            Role adminRole = context.Roles.Find(1);

            adminRole.Users.Add(context.Users.Find(1));

            context.Permissions.ToList().ForEach( p => { 
                adminRole.Permissions.Add(p);
            });
            context.SaveChanges();

        }
    }
}
