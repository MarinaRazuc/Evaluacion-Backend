using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Evaluacion_backend.Models
{
    public class Cliente
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(15)]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(30)]
        public string Apellido { get; set; }

        [Required]
        [MaxLength(30)]
        public string Direccion { get; set; }

        
    }
}
