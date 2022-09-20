using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventos.Aplicacion.Comun.Interfaces
{
    public interface ICurrentUserService
    {
        string? UsuarioId { get; }
    }
}
