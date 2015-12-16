using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace mba_model
{
    [DataContract()]
    public class User
    {
        [DataMember()]
        public int Id { get; set; }
        [DataMember(), Display(Name = "Логин")]
        public string Login { get; set; }
        [DataMember(), Display(Name = "Имя")]
        public string FirstName { get; set; }
        [DataMember(), Display(Name = "Отчество")]
        public string MiddleName { get; set; }
        [DataMember(), Display(Name = "Фамилия")]
        public string LastName { get; set; }
        [DataMember(), Display(Name = "ФИО")]
        public string FullName { get; set; }
        [DataMember(), Display(Name = "E-Mail")]
        public string Email { get; set; }
        [DataMember(), Display(Name = "Фотография")]
        public byte[] Photo { get; set; }

        [DataMember(), Column(TypeName = "datetime2"), Display(Name = "Заблокирован")]
        public DateTime? Freezed { get; set; }

        [DataMember()]
        public virtual ICollection<Role> Roles { get; set; }
        [DataMember()]
        public virtual ICollection<Permission> Permissions { get; set; }
        [DataMember()]
        public virtual ICollection<UserAction> User_Action { get; set; }
    }
}
