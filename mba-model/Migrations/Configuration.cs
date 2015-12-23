namespace mba_model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ModelContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ModelContext context)
        {

            #region Roles
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
            #endregion

            #region Permissions
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

                new Permission { Id = 9, ParentId = 0, Name = "tools-phone", ScreenName = "MBA Phone", Tooltip = "Доступена панель софтфона", Image = "tools-phone.png" },
                new Permission { Id = 10, ParentId = 0, Name = "tools-phone-history", ScreenName = "История", Tooltip = "История звонков", Image = "tools-call-history.png" },
                new Permission { Id = 11, ParentId = 0, Name = "tools-calc", ScreenName = "Калькулятор", Tooltip = "Доступен калькулятор", Image = "tools-calc.png" },
                new Permission { Id = 12, ParentId = 0, Name = "tools-chat", ScreenName = "Чат", Tooltip = "Доступна панель чатов", Image = "tools-chat.png" },

                new Permission { Id = 13, ParentId = 1, Name = "menu-processing-work", ScreenName = "Выборки", Tooltip = "Рабочее пространство оператора", Image = "menu-item-processing-operator.png", CommandParam = "OperatorWorkflowView" },
                new Permission { Id = 14, ParentId = 1, Name = "menu-processing-task", ScreenName = "Задания", Tooltip = "Дополнительные табели для операторов", Image = "menu-item-processing-task.png", CommandParam = "" },
                new Permission { Id = 15, ParentId = 1, Name = "menu-processing-table", ScreenName = "Табели", Tooltip = "Дополнительные табели для операторов", Image = "menu-item-processing-table.png", CommandParam = "" },
                new Permission { Id = 16, ParentId = 2, Name = "menu-lead-operators", ScreenName = "Выборки", Tooltip = "Формирование заданий (выборок) для операторов", Image = "menu-item-lead-operators.png", CommandParam = "ManagerTasksView" },
                new Permission { Id = 17, ParentId = 2, Name = "menu-lead-dialer", ScreenName = "Dialer", Tooltip = "Задания для автоматического выполнения", Image = "menu-item-lead-dialer.png", CommandParam = "ManagerAutoTasksView" },
                new Permission { Id = 18, ParentId = 2, Name = "menu-lead-registry", ScreenName = "Реестры", Tooltip = "Работа с реестрами по проекту", Image = "menu-item-lead-registry.png", CommandParam = "" },
                new Permission { Id = 19, ParentId = 2, Name = "menu-lead-monitoring", ScreenName = "Мониторинг", Tooltip = "Мониторинг активности операторов", Image = "menu-item-lead-monitoring.png", CommandParam = "" },
                new Permission { Id = 20, ParentId = 2, Name = "menu-lead-tables", ScreenName = "Табели", Tooltip = "Заполнение табелей", Image = "menu-item-lead-table.png", CommandParam = "" },
                new Permission { Id = 21, ParentId = 3, Name = "menu-import-registry", ScreenName = "Реестры", Tooltip = "Импорт реестров", Image = "menu-item-import-registry.png", CommandParam = "RegistryAddView" },
                new Permission { Id = 22, ParentId = 4, Name = "menu-analytics-dashboard", ScreenName = "Мониторинг", Tooltip = "Текущая состояние колл-центра", Image = "menu-item-analytics-dashboard.png", CommandParam = "" },
                new Permission { Id = 23, ParentId = 5, Name = "menu-report-reports", ScreenName = "Отчеты", Tooltip = "Настройка отчетов", Image = "menu-item-report-reports.png", CommandParam = "" },
                new Permission { Id = 24, ParentId = 6, Name = "menu-search-address", ScreenName = "Адресса", Tooltip = "Поиск и проверка адресов", Image = "menu-item-search-address.png", CommandParam = "" },
                new Permission { Id = 25, ParentId = 6, Name = "menu-search-phone", ScreenName = "Телефоны", Tooltip = "Поиск и проверка телефонов", Image = "menu-item-search-phone.png", CommandParam = "" },
                new Permission { Id = 26, ParentId = 6, Name = "menu-search-opp", ScreenName = "ОПП", Tooltip = "Отдел предварительного поиска", Image = "menu-item-search-opp.png", CommandParam = "" },
                new Permission { Id = 27, ParentId = 7, Name = "menu-leadership-dashboard", ScreenName = "Мониторинг", Tooltip = "Мониторинг рабочего процесса", Image = "menu-item-leadership-dashboard.png", CommandParam = "" },
                new Permission { Id = 28, ParentId = 8, Name = "menu-admin-users", ScreenName = "Пользователи", Tooltip = "Установка разрешений для пользователей", Image = "menu-item-admin-users.png", CommandParam = "AdminUsersView" },
                new Permission { Id = 29, ParentId = 8, Name = "menu-admin-roles", ScreenName = "Роли / привилегии", Tooltip = "Редактирование ролей и привилегий", Image = "menu-item-admin-roles.png", CommandParam = "AdminRolesView" },
                new Permission { Id = 30, ParentId = 8, Name = "menu-admin-aster", ScreenName = "Asterisk", Tooltip = "Настройка и мониторинг Asterisk", Image = "menu-item-admin-aster.png", CommandParam = "AdminAsteriskView" }
                );
            #endregion

            #region UserActions
            context.Actions.AddOrUpdate(
                a => a.Id,
                new mba_model.Action { Id = 1, Name = "create", Description = "Создание пользователя" },
                new mba_model.Action { Id = 2, Name = "try_enter", Description = "Попытка входа пользователя в систему" },
                new mba_model.Action { Id = 3, Name = "enter", Description = "Вход пользователя в систему" },
                new mba_model.Action { Id = 4, Name = "exit", Description = "Выход пользователя из системы" },
                new mba_model.Action { Id = 5, Name = "freezing", Description = "'Заморозка' пользователя" },
                new mba_model.Action { Id = 6, Name = "defrost", Description = "'Разморозка' пользователя" }
                );
            #endregion

            #region Users
            context.Users.AddOrUpdate(
                u => u.Id,
                new User { Id = 1, Login = "MBARU\\Ivan_Chasov", FirstName = "Иван", MiddleName = "Анатольевич", LastName = "Часов", Email = "chasow@yandex.ru" },
                new User { Id = 2, Login = "DESKTOP-22AR0VL\\ich", FirstName = "Иван", MiddleName = "Анатольевич", LastName = "Часов", Email = "chasow@yandex.ru" }
                );
            #endregion

            #region Clients
            context.Clients.AddOrUpdate(
                c => c.Id,
                new Client { Id = 1, ParentId = null, InnerId = 202, Name = "Уральский Банк Реконструкции и Развития", FullName = "ОАО \"Уральский банк реконструкции и развития\"", Image = "202-uralskij-bank.png", Created = DateTime.Now, CreatedBy = 1 },
                new Client { Id = 2, ParentId = null, InnerId = 205, Name = "МТС-Банк", FullName = "ОАО \"МТС-Банк\"", Image = "205-mts-bank.png", Created = DateTime.Now, CreatedBy = 1 },
                new Client { Id = 3, ParentId = null, InnerId = 206, Name = "Росгосстрах Банк", FullName = "ПАО \"Росгосстрах Банк\"", Image = "ClientDefault.png", Created = DateTime.Now, CreatedBy = 1 },
                new Client { Id = 4, ParentId = null, InnerId = 212, Name = "Совкомбанк", FullName = "ООО Инвестиционный коммерческий банк \"Совкомбанк\"", Image = "ClientDefault.png", Created = DateTime.Now, CreatedBy = 1 },
                new Client { Id = 5, ParentId = null, InnerId = 214, Name = "Восточный Экспресс Банк", FullName = "ПАО \"Восточный Экспресс Банк\"", Image = "214-vost-express-bank.png", Created = DateTime.Now, CreatedBy = 1 },
                new Client { Id = 6, ParentId = null, InnerId = 217, Name = "Домашние деньги", FullName = "ООО \"Домашние деньги\"", Image = "217-dom-dengi.png", Created = DateTime.Now, CreatedBy = 1 },
                new Client { Id = 7, ParentId = null, InnerId = 219, Name = "Ренессанс Кредит", FullName = "ООО КБ \"Ренессанс Кредит\"", Image = "219-renesans-credit.png", Created = DateTime.Now, CreatedBy = 1 },
                new Client { Id = 8, ParentId = null, InnerId = 220, Name = "Связной Банк", FullName = "ЗАО \"Связной Банк\"", Image = "ClientDefault.png", Created = DateTime.Now, CreatedBy = 1 },
                new Client { Id = 9, ParentId = null, InnerId = 221, Name = "ВТБ24", FullName = "ПАО \"ВТБ24\"", Image = "221-vtb-24.png", Created = DateTime.Now, CreatedBy = 1 },
                new Client { Id = 10, ParentId = null, InnerId = 223, Name = "Хоум Кредит энд Финанс Банк", FullName = "ООО \"Хоум Кредит энд Финанс Банк\"", Image = "ClientDefault.png", Created = DateTime.Now, CreatedBy = 1 },
                new Client { Id = 11, ParentId = null, InnerId = 225, Name = "Уральский банк реконструкции и развития", FullName = "ОАО \"Уральский банк реконструкции и развития\"", Image = "ClientDefault.png", Created = DateTime.Now, CreatedBy = 1 },
                new Client { Id = 12, ParentId = null, InnerId = 227, Name = "ОТП Банк", FullName = "АО \"ОТП Банк\"", Image = "227-otp-bank.png", Created = DateTime.Now, CreatedBy = 1 },
                new Client { Id = 13, ParentId = null, InnerId = 231, Name = "Промсвязьбанк", FullName = "ПАО \"Промсвязьбанк\"", Image = "ClientDefault.png", Created = DateTime.Now, CreatedBy = 1 },
                new Client { Id = 14, ParentId = null, InnerId = 234, Name = "УБРиР", FullName = "ПАО КБ \"УБРиР\"", Image = "ClientDefault.png", Created = DateTime.Now, CreatedBy = 1 },
                new Client { Id = 15, ParentId = null, InnerId = 236, Name = "Восточный Экспресс Банк", FullName = "ПАО КБ \"Восточный Экспресс Банк\"", Image = "236-vost-express-bank.png", Created = DateTime.Now, CreatedBy = 1 },
                new Client { Id = 16, ParentId = null, InnerId = 238, Name = "Ханты-Мансийский банк Открытие", FullName = "ПАО \"Ханты-Мансийский банк Открытие\"", Image = "ClientDefault.png", Created = DateTime.Now, CreatedBy = 1 },
                new Client { Id = 17, ParentId = null, InnerId = 240, Name = "Траст", FullName = "ПАО НБ \"Траст\"", Image = "240-bank-trast.png", Created = DateTime.Now, CreatedBy = 1 },
                new Client { Id = 18, ParentId = null, InnerId = 242, Name = "Лето Банк", FullName = "ПАО \"Лето Банк\"", Image = "242-leto-bank.png", Created = DateTime.Now, CreatedBy = 1 },
                new Client { Id = 19, ParentId = null, InnerId = 243, Name = "Акционерный коммерческий банк содействия коммерции и бизнесу", FullName = "ОАО \"Акционерный коммерческий банк содействия коммерции и бизнесу\"", Image = "ClientDefault.png", Created = DateTime.Now, CreatedBy = 1 },
                new Client { Id = 20, ParentId = null, InnerId = 245, Name = "СКБ-банк", FullName = "ОАО \"СКБ-банк\"", Image = "ClientDefault.png", Created = DateTime.Now, CreatedBy = 1 },
                new Client { Id = 21, ParentId = null, InnerId = 246, Name = "БИНБАНК кредитные карты", FullName = "АО \"БИНБАНК кредитные карты\"", Image = "ClientDefault.png", Created = DateTime.Now, CreatedBy = 1 },
                new Client { Id = 22, ParentId = null, InnerId = 248, Name = "МТС-Банк", FullName = "ОАО \"МТС-Банк\"", Image = "248-mts-bank.png", Created = DateTime.Now, CreatedBy = 1 },
                new Client { Id = 23, ParentId = null, InnerId = 249, Name = "Банк Москвы", FullName = "Банк Москвы", Image = "249-bank-of-moscow.png", Created = DateTime.Now, CreatedBy = 1 },
                new Client { Id = 24, ParentId = null, InnerId = 250, Name = "Ренессанс Кредит", FullName = "ООО КБ \"Ренессанс Кредит\"", Image = "250-renesans-credit.png", Created = DateTime.Now, CreatedBy = 1 },
                new Client { Id = 25, ParentId = null, InnerId = 251, Name = "Сбербанк", FullName = "ПАО «Сбербанк России»", Image = "251-sber-bank.png", Created = DateTime.Now, CreatedBy = 1 },
                new Client { Id = 26, ParentId = null, InnerId = 252, Name = "Азиатско-Тихоокеанский Банк", FullName = "ПАО \"Азиатско-Тихоокеанский Банк\"", Image = "ClientDefault.png", Created = DateTime.Now, CreatedBy = 1 },
                new Client { Id = 27, ParentId = null, InnerId = 253, Name = "РОСБАНК", FullName = "ПАО \"РОСБАНК\"", Image = "253-logo-rosbank.png", Created = DateTime.Now, CreatedBy = 1 },
                new Client { Id = 28, ParentId = null, InnerId = 254, Name = "БИНБАНК", FullName = "ПАО \"БИНБАНК\"", Image = "ClientDefault.png", Created = DateTime.Now, CreatedBy = 1 },
                new Client { Id = 29, ParentId = null, InnerId = 255, Name = "МОСКОВСКИЙ КРЕДИТНЫЙ БАНК", FullName = "ОАО \"МОСКОВСКИЙ КРЕДИТНЫЙ БАНК\"", Image = "ClientDefault.png", Created = DateTime.Now, CreatedBy = 1 },
                new Client { Id = 30, ParentId = null, InnerId = 256, Name = "Амант", FullName = "ООО \"Амант\"", Image = "ClientDefault.png", Created = DateTime.Now, CreatedBy = 1 },
                new Client { Id = 31, ParentId = null, InnerId = 257, Name = "РОСТ БАНК", FullName = "АО \"РОСТ БАНК\"", Image = "ClientDefault.png", Created = DateTime.Now, CreatedBy = 1 },
                new Client { Id = 32, ParentId = null, InnerId = 258, Name = "Кедр", FullName = "КБ \"Кедр\"", Image = "ClientDefault.png", Created = DateTime.Now, CreatedBy = 1 },
                new Client { Id = 33, ParentId = null, InnerId = 413, Name = "Выручай-Деньги", FullName = "ООО МФО \"Выручай-Деньги\"", Image = "ClientDefault.png", Created = DateTime.Now, CreatedBy = 1 }

                );
            #endregion

            #region Project
            context.Projects.AddOrUpdate(
                proj => proj.Id,
                new Project { Id = 1, ClientId = 6, Name = "Сбербанк" }
                );
            #endregion

            #region GoodColumns
            context.GoodColumns.AddOrUpdate(
                gc => gc.Id,
                new GoodColumn { Id = 1, Name = "ФИО должника", Created = DateTime.Now, CreatedBy = 1 },
                new GoodColumn { Id = 2, Name = "Фамилия должника", Created = DateTime.Now, CreatedBy = 1 },
                new GoodColumn { Id = 3, Name = "Имя должника", Created = DateTime.Now, CreatedBy = 1 },
                new GoodColumn { Id = 4, Name = "Отчество должника", Created = DateTime.Now, CreatedBy = 1 },
                new GoodColumn { Id = 5, Name = "Дата рождения должника", Created = DateTime.Now, CreatedBy = 1 },
                new GoodColumn { Id = 6, Name = "Место рождения должника", Created = DateTime.Now, CreatedBy = 1 },

                new GoodColumn { Id = 7, Name = "Пол должника", Created = DateTime.Now, CreatedBy = 1 },

                new GoodColumn { Id = 8, Name = "Серия и номер паспорта должника", Created = DateTime.Now, CreatedBy = 1 },
                new GoodColumn { Id = 9, Name = "Кем и когда выдан паспорт должника", Created = DateTime.Now, CreatedBy = 1 },
                new GoodColumn { Id = 10, Name = "Серия паспорта должника", Created = DateTime.Now, CreatedBy = 1 },
                new GoodColumn { Id = 11, Name = "Номер паспорта должника", Created = DateTime.Now, CreatedBy = 1 },
                new GoodColumn { Id = 12, Name = "Кем выдан паспорт должника", Created = DateTime.Now, CreatedBy = 1 },
                new GoodColumn { Id = 13, Name = "Дата выдачи паспорта должника", Created = DateTime.Now, CreatedBy = 1 },

                new GoodColumn { Id = 14, Name = "Адрес регистрации(прописки) должника", Created = DateTime.Now, CreatedBy = 1 },
                new GoodColumn { Id = 15, Name = "Фактическое место проживания должника", Created = DateTime.Now, CreatedBy = 1 },

                new GoodColumn { Id = 16, Name = "Мобильный телефон должника", Created = DateTime.Now, CreatedBy = 1 },
                new GoodColumn { Id = 17, Name = "Телефон адреса регистрации должника", Created = DateTime.Now, CreatedBy = 1 },
                new GoodColumn { Id = 18, Name = "Телефон фактического места проживания", Created = DateTime.Now, CreatedBy = 1 },
                new GoodColumn { Id = 19, Name = "Рабочий телефон должника", Created = DateTime.Now, CreatedBy = 1 },

                new GoodColumn { Id = 20, Name = "Номер кредитного договора", Created = DateTime.Now, CreatedBy = 1 },
                new GoodColumn { Id = 21, Name = "Тип продукта (кредита)", Created = DateTime.Now, CreatedBy = 1 },
                new GoodColumn { Id = 22, Name = "Программа кредитования должника", Created = DateTime.Now, CreatedBy = 1 },
                new GoodColumn { Id = 23, Name = "Номер счета для погашения задолженности", Created = DateTime.Now, CreatedBy = 1 },
                new GoodColumn { Id = 24, Name = "Дата предоставления кредита", Created = DateTime.Now, CreatedBy = 1 }
                );
            #endregion

            #region ImportTypes
            context.ImportTypes.AddOrUpdate(
                it => it.Id,
                new ImportType { Id = 1, Name = "Импорт реестров" },
                new ImportType { Id = 2, Name = "Платежи по реестрам" },
                new ImportType { Id = 3, Name = "Корректировки по реестрам" },
                new ImportType { Id = 4, Name = "Дополнительные контакты" },
                new ImportType { Id = 5, Name = "Специальные предложения банка" }
                );
            #endregion

            context.SaveChanges();

            var adminRole = context.Roles.Find(1);

            adminRole.Users.Add(context.Users.Find(1));
            adminRole.Users.Add(context.Users.Find(2));

            context.Permissions.ToList().ForEach(p => {
                adminRole.Permissions.Add(p);
            });
            context.SaveChanges();
        }
    }
}
