using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace pruebaED01.Database
{
    [Table("persona_direccion", Schema = "persona")]
    [Index("IdPersona", Name = "IX_persona_direccion_id_persona")]
    [Index("IdTipoDireccion", Name = "IX_persona_direccion_id_tipo_direccion")]
    public partial class PersonaDireccion
    {
        [Key]
        public int Id { get; set; }
        [Column("id_persona")]
        public int IdPersona { get; set; }
        [Column("id_tipo_direccion")]
        public int IdTipoDireccion { get; set; }
        [Column("descripcion")]
        [StringLength(50)]
        public string Descripcion { get; set; } = null!;

        [ForeignKey("IdPersona")]
        [InverseProperty("PersonaDireccions")]
        public virtual Persona IdPersonaNavigation { get; set; } = null!;
        [ForeignKey("IdTipoDireccion")]
        [InverseProperty("PersonaDireccions")]
        public virtual TipoDireccion IdTipoDireccionNavigation { get; set; } = null!;
    }
}
