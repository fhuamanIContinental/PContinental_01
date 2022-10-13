﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebaED01.Model
{
    [Table("tipo_direccion", Schema = "persona")]
    public class PersonaTipoDireccion
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        
        public string descripcion { get; set; }
    }
}
