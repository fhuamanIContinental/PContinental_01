using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace pruebaED01.Model
{
    [Table("user", Schema = "access")]
    public partial class User
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("id_person")]
        public int IdPerson { get; set; }
        [Column("username")]
        [StringLength(50)]
        public string? Username { get; set; }
        [Column("password")]
        public string? Password { get; set; }
        [Column("change_password")]
        public bool? ChangePassword { get; set; }
        [Column("email")]
        [StringLength(80)]
        public string? Email { get; set; }
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
        [Column("identificador_celular")]
        [StringLength(50)]
        [Unicode(false)]
        public string? IdentificadorCelular { get; set; }

        [ForeignKey("IdPerson")]
        [InverseProperty("Users")]
        public virtual Persona IdPersonNavigation { get; set; } = null!;
        [ForeignKey("IdRole")]
        [InverseProperty("Users")]
        public virtual Role IdRoleNavigation { get; set; } = null!;
    }
}
