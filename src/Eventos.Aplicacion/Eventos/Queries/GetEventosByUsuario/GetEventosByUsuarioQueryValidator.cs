using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Eventos.Aplicacion.Eventos.Queries.GetEventosByUsuario
{
    public class GetEventosByUsuarioQueryValidator : AbstractValidator<GetEventosByUsuarioQuery>
    {
        public GetEventosByUsuarioQueryValidator()
        {
            RuleFor(x => x.UsuarioId).NotEmpty();
        }
    }
}
