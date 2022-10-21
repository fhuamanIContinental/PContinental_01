using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace pruebaED01.Database
{
    [Table("tipo_direccion", Schema = "persona")]
    public partial class TipoDireccion
    {
        public TipoDireccion()
        {
            PersonaDireccions = new HashSet<PersonaDireccion>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("descripcion")]
        [StringLength(40)]
        [Unicode(false)]
        public string? Descripcion { get; set; }

        [InverseProperty("IdTipoDireccionNavigation")]
        public virtual ICollection<PersonaDireccion> PersonaDireccions { get; set; }
    }
}
