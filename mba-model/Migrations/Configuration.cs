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


            context.Permissions.AddOrUpdate(
                p => p.Id,
                new Permission { Id = 1, ParentId = null, Name = "menu-processing", ScreenName = "Процессинг", Tooltip = "Раздел меню для работы оператора", Image = "menu-group-operator.png" },
                new Permission { Id = 2, ParentId = null, Name = "menu-lead", ScreenName = "Проект", Tooltip = "Раздел меню для работы менеджера проекта", Image = "menu-group-lead.png" },
                new Permission { Id = 3, ParentId = null, Name = "menu-import", ScreenName = "Импорт", Tooltip = "Раздел меню для импорта реестров, корректировок, платежей", Image = "menu-group-import.png" },
                new Permission { Id = 4, ParentId = null, Name = "menu-analytics", ScreenName = "Аналитика", Tooltip = "Раздел меню аналитики", Image = "menu-group-analytics.png" },
                new Permission { Id = 5, ParentId = null, Name = "menu-report", ScreenName = "Отчеты", Tooltip = "Раздел меню просмотра отчетности", Image = "menu-group-report.png" },
                new Permission { Id = 6, ParentId = null, Name = "menu-search", ScreenName = "Поиск", Tooltip = "Раздел меню для работы отдела поиска", Image = "menu-group-search.png" },
                new Permission { Id = 7, ParentId = null, Name = "menu-leadership", ScreenName = "Руководство", Tooltip = "Раздел меню руководства", Image = "menu-group-leadership.png" },
                new Permission { Id = 8, ParentId = null, Name = "menu-admin", ScreenName = "Администрирование", Tooltip = "Раздел меню администрирование системы", Image = "menu-group-admin.png" },

                new Permission { Id = 9, ParentId = 1, Name = "menu-processing-work", ScreenName = "Выборки",
                                 Tooltip = "Рабочее пространство оператора", Image = "menu-item-processing-operator.png", CommandParam = "OperatorWorkflowView" },
                new Permission { Id = 10, ParentId = 1, Name = "menu-processing-table", ScreenName = "Табели",
                                 Tooltip = "Дополнительные табели для операторов", Image = "menu-item-processing-table.png", CommandParam = "" },
                new Permission { Id = 11, ParentId = 1, Name = "menu-processing-task", ScreenName = "Задания",
                                 Tooltip = "Дополнительные табели для операторов", Image = "menu-item-processing-task.png", CommandParam = "" },

                new Permission { Id = 12, ParentId = 2, Name = "menu-lead-operators", ScreenName = "Выборки",
                                 Tooltip = "Формирование заданий (выборок) для операторов", Image = "menu-item-lead-operators.png", CommandParam = "" },
                new Permission { Id = 13, ParentId = 2, Name = "menu-lead-dialer", ScreenName = "Dialer",
                                 Tooltip = "Задания для автоматического выполнения", Image = "menu-item-lead-dialer.png", CommandParam = "" },
                new Permission { Id = 14, ParentId = 2, Name = "menu-lead-registry", ScreenName = "Реестры",
                                 Tooltip = "Работа с реестрами по проекту", Image = "menu-item-lead-registry.png", CommandParam = "" },
                new Permission { Id = 15, ParentId = 2, Name = "menu-lead-monitoring", ScreenName = "Мониторинг",
                                 Tooltip = "Мониторинг активности операторов", Image = "menu-item-lead-monitoring.png", CommandParam = "" },
                new Permission { Id = 16, ParentId = 2, Name = "menu-lead-tables", ScreenName = "Табели",
                                 Tooltip = "Заполнение табелей", Image = "menu-item-lead-table.png", CommandParam = "" },

                new Permission { Id = 17, ParentId = 3, Name = "menu-import-registry", ScreenName = "Реестры",
                                 Tooltip = "Импорт реестров", Image = "menu-item-import-registry.png", CommandParam = "RegistryAddView" },

                new Permission { Id = 18, ParentId = 4, Name = "menu-analytics-dashboard", ScreenName = "Мониторинг",
                                 Tooltip = "Текущая состояние колл-центра", Image = "menu-item-analytics-dashboard.png", CommandParam = "" },

                new Permission { Id = 19, ParentId = 5, Name = "menu-report-reports", ScreenName = "Отчеты",
                                 Tooltip = "Настройка отчетов", Image = "menu-item-report-reports.png", CommandParam = "" },

                new Permission { Id = 20, ParentId = 6, Name = "menu-search-address", ScreenName = "Адресса",
                                 Tooltip = "Поиск и проверка адресов", Image = "menu-item-search-address.png", CommandParam = "" },
                new Permission { Id = 21, ParentId = 6, Name = "menu-search-phone", ScreenName = "Телефоны",
                                 Tooltip = "Поиск и проверка телефонов", Image = "menu-item-search-phone.png", CommandParam = "" },
                new Permission { Id = 22, ParentId = 6, Name = "menu-search-opp", ScreenName = "ОПП",
                                 Tooltip = "Отдел предварительного поиска", Image = "menu-item-search-opp.png", CommandParam = "" },

                new Permission { Id = 23, ParentId = 7, Name = "menu-leadership-dashboard", ScreenName = "Мониторинг",
                                 Tooltip = "Мониторинг рабочего процесса", Image = "menu-item-leadership-dashboard.png", CommandParam = "" },

                new Permission { Id = 24, ParentId = 8, Name = "menu-admin-users", ScreenName = "Пользователи",
                                 Tooltip = "Установка разрешений для пользователей", Image = "menu-item-admin-users.png", CommandParam = "AdminUsersView" },
                new Permission { Id = 25, ParentId = 8, Name = "menu-admin-aster", ScreenName = "Asterisk",
                                 Tooltip = "Настройка и мониторинг Asterisk", Image = "menu-item-admin-aster.png", CommandParam = "AdminAsteriskView" }
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
                new Client { Id = 1, ParentId = null, InnerId = 202, Name = "Уральский Банк Реконструкции и Развития", FullName = "ПАО \"Уральский банк реконструкции и развития\"", Image="ClientDefault.png", Created = DateTime.Now, CreatedBy = 1 },
                new Client { Id = 2, ParentId = null, InnerId = 205, Name = "МТС-Банк", FullName = "ОАО \"МТС-Банк\"", Image = "ClientMTSbank.png", Created = DateTime.Now, CreatedBy = 1, Deleted = DateTime.Now, DeletedBy = 1 },
                new Client { Id = 3, ParentId = 2, InnerId = 248, Name = "МТС-Банк", FullName = "ОАО \"МТС-Банк\"", Image = "ClientMTSbank.png", Created = DateTime.Now, CreatedBy = 1 },
                new Client { Id = 4, ParentId = null, InnerId = 219, Name = "Ренессанс Кредит", FullName = "ООО КБ \"Ренессанс Кредит\"", Image = "ClientRenesansCredit.png", Created = DateTime.Now, CreatedBy = 1, Deleted = DateTime.Now, DeletedBy = 1 },
                new Client { Id = 5, ParentId = 4, InnerId = 250, Name = "Ренессанс Кредит", FullName = "ООО КБ \"Ренессанс Кредит\"", Image = "ClientRenesansCredit.png", Created = DateTime.Now, CreatedBy = 1 },
                new Client { Id = 6, ParentId = null, InnerId = 251, Name = "ПАО Сбербанк", FullName = "Публичное акционерное общество «Сбербанк России»", Image = "ClientSber.png", Created = DateTime.Now, CreatedBy = 1 }
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
                new ImportType { Id = 1, Name = "Импорт реестров" },
                new ImportType { Id = 2, Name = "Платежи по реестрам" },
                new ImportType { Id = 3, Name = "Корректировки по реестрам" },
                new ImportType { Id = 4, Name = "Дополнительные контакты" },
                new ImportType { Id = 5, Name = "Специальные предложения банка" }
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
