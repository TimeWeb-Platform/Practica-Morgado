using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eventos.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Eventos.Aplicacion.Comun.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Evento> Eventos { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
