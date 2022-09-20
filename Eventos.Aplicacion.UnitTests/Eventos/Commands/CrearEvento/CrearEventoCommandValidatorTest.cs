using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eventos.Aplicacion.Eventos.Commands.CrearEvento;
using FluentAssertions;
using FluentValidation;

namespace Eventos.Aplicacion.UnitTests.Eventos.Commands.CrearEvento
{
    public class CrearEventoCommandValidatorTest
    {

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public async Task Validator_Retorna_Excepcion_Con_DatosErroneos(string usuarioId)
        {
            // ARRANGE
            var sut = new CrearEventoCommandValidator();
            var eventoCommand = new CrearEventoCommand
            {
                UsuarioId = usuarioId
            };

            // ACT
            // ASSERT
            await FluentActions.Invoking(() => sut.ValidateAndThrowAsync(eventoCommand))
                .Should().ThrowAsync<ValidationException>();

        }

    }
}
