using Eventos.Aplicacion.Eventos.Commands.CrearEvento;
using Eventos.Dominio.Entidades;
using Eventos.Dominio.Enums;
using FluentAssertions;
using FluentValidation;

namespace Eventos.Aplicacion.IntegrationTest.Eventos;

using static Testing;

public class CrearEventoCommandTest : TestBase
{

    [Test]
    [TestCase("",TipoOrigen.TIMEWEBHOUSE)]
    [TestCase(null,TipoOrigen.BIOMETRICO)]
    public async Task Command_Retorna_Excepcion_Con_DatosInvalidos(string usuarioId, TipoOrigen tipoOrigen)
    {
        // ARRANGE
        var command = new CrearEventoCommand
        {
            UsuarioId = usuarioId,
            TipoOrigen = tipoOrigen
        };

        // ACT
        // ASSERT

        await FluentActions.Invoking(() =>
            SendAsync(command)).Should().ThrowAsync<ValidationException>();
    }

    [Test]
    public async Task Command_Registra_Evento_Con_DatosValidos()
    {
        var usuarioId = Guid.NewGuid().ToString();

        var command = new CrearEventoCommand
        {
            UsuarioId = usuarioId,
            TipoOrigen = TipoOrigen.BIOMETRICO
        };

        var eventoId = await SendAsync(command);

        var evento = await FindAsync<Evento>(eventoId);

        evento.Should().NotBeNull();
        evento!.Id.Should().Be(1);
        evento!.UsuarioId.Should().Be(usuarioId);
    }

}