using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mba_model
{
    public class User
    {
        public int Id { get; set; }

        [Display(Name = "Логин")]
        public string Login { get; set; }

        [Display(Name = "Имя")]
        public string FirstName { get; set; }

        [Display(Name = "Отчество")]
        public string MiddleName { get; set; }

        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        [Display(Name = "ФИО")]
        public string FullName { get; set; }

        [Display(Name = "E-Mail")]
        public string Email { get; set; }

        [Display(Name = "Фотография")]
        public byte[] Photo { get; set; }

        [Column(TypeName = "datetime2"), Display(Name = "Заблокирован")]
        public DateTime? Freezed { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
        public virtual ICollection<Permission> Permissions { get; set; }
        public virtual ICollection<UserAction> User_Action { get; set; }
    }
}
