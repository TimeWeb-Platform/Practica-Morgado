using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Eventos.Aplicacion.Eventos.Commands.CrearEvento
{
    public class CrearEventoCommandValidator : AbstractValidator<CrearEventoCommand>
    {
        public CrearEventoCommandValidator()
        {
            RuleFor(x => x.UsuarioId).NotEmpty();
            RuleFor(x => x.TipoOrigen).IsInEnum();
        }
    }
}
