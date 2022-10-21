using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace pruebaED01.Database
{
    [Table("role", Schema = "access")]
    public partial class Role
    {
        public Role()
        {
            MenuRoles = new HashSet<MenuRole>();
            Users = new HashSet<User>();
        }

        [Key]
        [Column("id")]
        public short Id { get; set; }
        [Column("description")]
        [StringLength(255)]
        public string? Description { get; set; }
        [Column("function")]
        public string? Function { get; set; }
        [Column("id_status")]
        public short IdStatus { get; set; }

        [InverseProperty("IdRoleNavigation")]
        public virtual ICollection<MenuRole> MenuRoles { get; set; }
        [InverseProperty("IdRoleNavigation")]
        public virtual ICollection<User> Users { get; set; }
    }
}
