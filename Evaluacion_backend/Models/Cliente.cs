using System;
using System.Collections.Generic;
using System.Text;

namespace Evaluacion_backend.Models
{
    class Cliente
    {
        public Guid Id { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Direccion { get; set; }
    }
}
