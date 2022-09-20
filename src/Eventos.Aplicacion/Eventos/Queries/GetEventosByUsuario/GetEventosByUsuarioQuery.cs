using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eventos.Aplicacion.Comun.Interfaces;
using Eventos.Dominio.Entidades;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Eventos.Aplicacion.Eventos.Queries.GetEventosByUsuario
{
    public class GetEventosByUsuarioQuery : IRequest<List<Evento>>
    {
        public string UsuarioId { get; set; } = null!;
    }

    public class GetEventosByUsuarioQueryHandler : IRequestHandler<GetEventosByUsuarioQuery, List<Evento>>
    {
        private readonly IApplicationDbContext _context;

        public GetEventosByUsuarioQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Evento>> Handle(GetEventosByUsuarioQuery request, CancellationToken cancellationToken)
        {
            var eventos = await _context.Eventos
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            return eventos;
        }
    }
}
