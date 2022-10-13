using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pruebaED01.Model
{
    //code first

    [Table("persona", Schema = "persona")]
    public class Persona
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        /// <summary>
        /// DNI PAS CE
        /// </summary>
        [MaxLength(3)]
        public string tipo_documento { get; set; }

        [MaxLength(16)]
        public string numero_documento { get; set; }

        /// <summary>
        /// N Natural J Juridico
        /// </summary>
        [MaxLength(1)]
        public string tipo_persona { get; set; }
        [MaxLength(50)]
        public string nombre { get; set; }
        [MaxLength(50)]
        public string apellido_paterno { get; set; }
        [MaxLength(50)]
        public string apellido_materno { get; set; }
        [MaxLength(150)]
        public string full_name { get; set; }
        /// <summary>
        /// M => masculino / F => femenino
        /// </summary>
        [MaxLength(1)]
        public string genero { get; set; }
        public DateTime fecha_nacimiento { get; set; }
        public DateTime fecha_registro { get; set; }

        public virtual List<PersonaDireccion>? direcciones { get; set; }

    }
}