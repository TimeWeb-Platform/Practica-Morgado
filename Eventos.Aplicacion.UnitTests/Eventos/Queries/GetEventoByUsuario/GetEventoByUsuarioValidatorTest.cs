using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eventos.Aplicacion.Eventos.Queries.GetEventosByUsuario;
using FluentAssertions;
using FluentValidation;

namespace Eventos.Aplicacion.UnitTests.Eventos.Queries.GetEventoByUsuario
{
    public class GetEventoByUsuarioValidatorTest
    {
        [Test]
        [TestCase("")]
        [TestCase(null)]
        public async Task Validator_Retorna_Excepcion_Con_DatosErroneos(string usuarioId)
        {
            // ARRANGE
            var sut = new GetEventosByUsuarioQueryValidator();
            var query = new GetEventosByUsuarioQuery
            {
                UsuarioId = usuarioId
            };

            // ACT
            // ASSERT
            await FluentActions.Invoking(() => sut.ValidateAndThrowAsync(query)).Should()
                .ThrowAsync<ValidationException>();
        }
    }
}
