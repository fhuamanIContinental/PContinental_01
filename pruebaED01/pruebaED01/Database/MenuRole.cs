using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace pruebaED01.Database
{
    [Table("menu_role", Schema = "access")]
    public partial class MenuRole
    {
        [Key]
        [Column("id")]
        public short Id { get; set; }
        [Column("id_menu")]
        public short IdMenu { get; set; }
        [Column("id_role")]
        public short IdRole { get; set; }
        [Column("id_status")]
        public short IdStatus { get; set; }
        [Column("user_create")]
        public int UserCreate { get; set; }
        [Column("user_update")]
        public int UserUpdate { get; set; }
        [Column("date_create")]
        [Precision(6)]
        public DateTime DateCreate { get; set; }
        [Column("date_update")]
        [Precision(6)]
        public DateTime DateUpdate { get; set; }

        [ForeignKey("IdMenu")]
        [InverseProperty("MenuRoles")]
        public virtual Menu IdMenuNavigation { get; set; } = null!;
        [ForeignKey("IdRole")]
        [InverseProperty("MenuRoles")]
        public virtual Role IdRoleNavigation { get; set; } = null!;
    }
}
