using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace pruebaED01.Model
{
    [Table("persona_direccion", Schema = "persona")]
    public class PersonaDireccion
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int id_persona { get; set; }
        public int id_tipo_direccion { get; set; }
        [MaxLength(50)]
        public string descripcion { get; set; }


        [JsonIgnore, ForeignKey("id_persona")]
        public virtual Persona? Persona { get; set; }
        [ForeignKey("id_tipo_direccion")]
        public virtual PersonaTipoDireccion? PersonaTipoDireccion { get; set; }

    }
}
