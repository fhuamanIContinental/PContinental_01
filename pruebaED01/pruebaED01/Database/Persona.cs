using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace pruebaED01.Database
{
    [Table("persona", Schema = "persona")]
    [Index("NumeroDocumento", Name = "IX_persona_numero_documento", IsUnique = true)]
    public partial class Persona
    {
        public Persona()
        {
            PersonaDireccions = new HashSet<PersonaDireccion>();
            Users = new HashSet<User>();
        }

        [Key]
        public int Id { get; set; }
        [Column("tipo_documento")]
        [StringLength(3)]
        public string TipoDocumento { get; set; } = null!;
        [Column("numero_documento")]
        [StringLength(16)]
        public string NumeroDocumento { get; set; } = null!;
        [Column("tipo_persona")]
        [StringLength(1)]
        public string TipoPersona { get; set; } = null!;
        [Column("nombre")]
        [StringLength(50)]
        public string Nombre { get; set; } = null!;
        [Column("apellido_paterno")]
        [StringLength(50)]
        public string ApellidoPaterno { get; set; } = null!;
        [Column("apellido_materno")]
        [StringLength(50)]
        public string ApellidoMaterno { get; set; } = null!;
        [Column("full_name")]
        [StringLength(150)]
        public string FullName { get; set; } = null!;
        [Column("genero")]
        [StringLength(1)]
        public string Genero { get; set; } = null!;
        [Column("fecha_nacimiento")]
        public DateTime FechaNacimiento { get; set; }
        [Column("fecha_registro")]
        public DateTime FechaRegistro { get; set; }

        [InverseProperty("IdPersonaNavigation")]
        public virtual ICollection<PersonaDireccion> PersonaDireccions { get; set; }
        [InverseProperty("IdPersonNavigation")]
        public virtual ICollection<User> Users { get; set; }
    }
}
