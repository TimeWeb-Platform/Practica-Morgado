using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eventos.Dominio.Comun;
using Eventos.Dominio.Enums;

namespace Eventos.Dominio.Entidades
{
    public class Evento : EntidadBase
    {
        public string UsuarioId { get; set; } = null!;
        public string? Latitud { get; set; }
        public string? Longitud { get; set; }
        public TipoOrigen TipoOrigen { get; set; }
    }
}
