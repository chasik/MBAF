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
                new Permission { Id = 1, PermissionGroupId = 1, Name = "menu-processing-work", ScreenName = "Выборки",
                                 Tooltip = "Рабочее пространство оператора", ImageSource = "", CommandParam = "" },
                new Permission { Id = 2, PermissionGroupId = 1, Name = "menu-processing-table", ScreenName = "Табели",
                                 Tooltip = "Дополнительные табели для операторов", ImageSource = "", CommandParam = "" },
                new Permission { Id = 3, PermissionGroupId = 8, Name = "menu-admin-users", ScreenName = "Пользователи",
                                 Tooltip = "Установка разрешений для пользователей", ImageSource = "", CommandParam = "AdminUsersView" },
                new Permission { Id = 4, PermissionGroupId = 8, Name = "menu-admin-aster", ScreenName = "Asterisk",
                                 Tooltip = "Настройка и мониторинг Asterisk", ImageSource = "", CommandParam = "AdminAsteriskView" },
                new Permission { Id = 5, PermissionGroupId = 3, Name = "menu-import-registry", ScreenName = "Реестры",
                                 Tooltip = "Импорт реестров", ImageSource = "", CommandParam = "RegistryAddView" }
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
                new User { Id = 1, Login = "MBARU\\Ivan_Chasov", FirstName = "Иван", MiddleName = "Анатольевич", LastName = "Часов", Email = "chasow@yandex.ru" },
                new User { Id = 2, Login = "NEWPROG\\ich", FirstName = "Иван", MiddleName = "Анатольевич", LastName = "Часов", Email = "chasow@yandex.ru" }
                );

            context.Clients.AddOrUpdate(
                c => c.Id,
                new Client { Id = 1, InnerId = 202, Name = "Уральский Банк Реконструкции и Развития", FullName = "ПАО \"Уральский банк реконструкции и развития\"", Created = DateTime.Now, CreatedBy = 1 },
                new Client { Id = 2, InnerId = 205, Name = "МТС-Банк", FullName = "ОАО \"МТС-Банк\"", Created = DateTime.Now, CreatedBy = 1, Deleted = DateTime.Now, DeletedBy = 1 },
                new Client { Id = 3, InnerId = 248, Name = "МТС-Банк", FullName = "ОАО \"МТС-Банк\"", Created = DateTime.Now, CreatedBy = 1 },
                new Client { Id = 4, InnerId = 219, Name = "Ренессанс Кредит", FullName = "ООО КБ \"Ренессанс Кредит\"", Created = DateTime.Now, CreatedBy = 1, Deleted = DateTime.Now, DeletedBy = 1 },
                new Client { Id = 5, InnerId = 250, Name = "Ренессанс Кредит", FullName = "ООО КБ \"Ренессанс Кредит\"", Created = DateTime.Now, CreatedBy = 1 }
                );

            context.GoodColumns.AddOrUpdate(
                gc => gc.Id,
                new GoodColumn { Id = 1, Name = "Фамилия должника", Created = DateTime.Now, CreatedBy = 1 },
                new GoodColumn { Id = 2, Name = "Имя должника", Created = DateTime.Now, CreatedBy = 1 },
                new GoodColumn { Id = 3, Name = "Отчество должника", Created = DateTime.Now, CreatedBy = 1 },

                new GoodColumn { Id = 4, Name = "Серия паспорта должника", Created = DateTime.Now, CreatedBy = 1 },
                new GoodColumn { Id = 5, Name = "Номер паспорта должника", Created = DateTime.Now, CreatedBy = 1 },
                new GoodColumn { Id = 6, Name = "Кем выдан паспорт должника", Created = DateTime.Now, CreatedBy = 1 },
                new GoodColumn { Id = 7, Name = "Дата выдачи паспорта должника", Created = DateTime.Now, CreatedBy = 1 },

                new GoodColumn { Id = 8, Name = "Адрес регистрации(прописка) должника", Created = DateTime.Now, CreatedBy = 1 },
                new GoodColumn { Id = 9, Name = "Фактическое место проживания должника", Created = DateTime.Now, CreatedBy = 1 },
                new GoodColumn { Id = 10, Name = "ФИО должника", Created = DateTime.Now, CreatedBy = 1 },
                new GoodColumn { Id = 11, Name = "Дата рождения должника", Created = DateTime.Now, CreatedBy = 1 },
                new GoodColumn { Id = 12, Name = "Серия и номер паспорта", Created = DateTime.Now, CreatedBy = 1 },
                new GoodColumn { Id = 13, Name = "Кем и когда выдан паспорт", Created = DateTime.Now, CreatedBy = 1 }
                );

            context.ImportTypes.AddOrUpdate(
                it => it.Id,
                new ImportType { Id = 1, Name = "Импорт реестров\\дел" },
                new ImportType { Id = 2, Name = "Платежи по реестрам" },
                new ImportType { Id = 3, Name = "Корректировки по реестрам" },
                new ImportType { Id = 4, Name = "Дополнительные контакты" }
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
