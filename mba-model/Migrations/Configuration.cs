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

            context.PermissionGroup.AddOrUpdate(
                pg => pg.Id,
                new PermissionGroup { Id = 1, Name = "menu-processing", ScreenName = "Процессинг", Tooltip = "Раздел меню для работы оператора", ImageSource = "" },
                new PermissionGroup { Id = 2, Name = "menu-head", ScreenName = "Старший", Tooltip = "Раздел меню для работы старшего", ImageSource = "" },
                new PermissionGroup { Id = 3, Name = "menu-import", ScreenName = "Импорт", Tooltip = "Раздел меню для импорта реестров, корректировок, платежей", ImageSource = "" },
                new PermissionGroup { Id = 4, Name = "menu-analytics", ScreenName = "Аналитика", Tooltip = "Раздел меню аналитики", ImageSource = "" },
                new PermissionGroup { Id = 5, Name = "menu-report", ScreenName = "Отчеты", Tooltip = "Раздел меню просмотра отчетности", ImageSource = "" },
                new PermissionGroup { Id = 6, Name = "menu-search", ScreenName = "Поиск", Tooltip = "Раздел меню для работы отдела поиска", ImageSource = "" },
                new PermissionGroup { Id = 7, Name = "menu-leadership", ScreenName = "Руководство", Tooltip = "Раздел меню руководства", ImageSource = "" },
                new PermissionGroup { Id = 8, Name = "menu-admin", ScreenName = "Администрирование", Tooltip = "Раздел меню администрирование системы", ImageSource = "" }
                );

            context.Permissions.AddOrUpdate(
                p => p.Id,
                new Permission { Id = 1, PermissionGroupId = 1, Name = "menu-processing-work", ScreenName = "Выборки", Tooltip = "Рабочее пространство оператора", ImageSource = "", CommandParam="" },
                new Permission { Id = 2, PermissionGroupId = 1, Name = "menu-processing-table", ScreenName = "Табели", Tooltip = "Дополнительные табели для операторов", ImageSource = "", CommandParam = "" },
                new Permission { Id = 3, PermissionGroupId = 8, Name = "menu-admin-users", ScreenName = "Пользователи", Tooltip = "Установка разрешений для пользователей", ImageSource = "", CommandParam = "" },
                new Permission { Id = 4, PermissionGroupId = 8, Name = "menu-admin-aster", ScreenName = "Asterisk", Tooltip = "Настройка и мониторинг Asterisk", ImageSource = "", CommandParam = "" }
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

            context.Permissions.ToList().ForEach(p => {
                adminRole.Permissions.Add(p);
            });
            context.SaveChanges();
        }
    }
}
