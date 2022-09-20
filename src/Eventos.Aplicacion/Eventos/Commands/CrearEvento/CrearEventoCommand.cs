using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eventos.Aplicacion.Comun.Interfaces;
using Eventos.Dominio.Entidades;
using Eventos.Dominio.Enums;
using MediatR;

namespace Eventos.Aplicacion.Eventos.Commands.CrearEvento
{
    public class CrearEventoCommand : IRequest<int>
    {

        public string UsuarioId { get; set; } = null!;
        public string? Latitud { get; set; }
        public string? Longitud { get; set; }
        public TipoOrigen TipoOrigen { get; set; }
    }

    public class CrearEventoCommandHandler : IRequestHandler<CrearEventoCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CrearEventoCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CrearEventoCommand request, CancellationToken cancellationToken)
        {
            var entidad = new Evento
            {
                UsuarioId = request.UsuarioId,
                Latitud = request.Latitud,
                Longitud = request.Longitud,
                TipoOrigen = request.TipoOrigen
            };

            _context.Eventos.Add(entidad);

            await _context.SaveChangesAsync(cancellationToken);

            return entidad.Id;
        }
    }
}
