using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eventos.Aplicacion.Eventos.Queries.GetEventosByUsuario;
using Eventos.Dominio.Entidades;
using FluentAssertions;
using FluentValidation;

namespace Eventos.Aplicacion.IntegrationTest.Eventos.Queries;

using static Testing;

public class GetEventosByUsuarioQueryTest
{

    [Test]
    [TestCase(null)]
    [TestCase("")]
    public async Task Query_Retorna_Excepcion_Con_DatosInvalidos(string usuarioId)
    {
        // ARRANGE
        var query = new GetEventosByUsuarioQuery
        {
            UsuarioId = usuarioId
        };

        // ACT
        // ASSERT
        await FluentActions.Invoking(() => SendAsync(query)).Should().ThrowAsync<ValidationException>();
    }

    [Test]
    public async Task Query_Retorna_ListaEventos_Con_UsuarioValido()
    {
        // ARRANGE
        var usuarioId = Guid.NewGuid().ToString();

        var listaEventos = new List<Evento>
        {
            new Evento
            {
                UsuarioId = usuarioId
            },
            new Evento
            {
                UsuarioId = usuarioId
            }
        };
        var query = new GetEventosByUsuarioQuery
        {
            UsuarioId = usuarioId
        };

        // ACT
        await AddAsync(listaEventos[0]);
        await AddAsync(listaEventos[1]);

        var eventos = await SendAsync(query);

        // ASSERT
        eventos.Should().NotBeNull();
        eventos.Should().BeAssignableTo<IList<Evento>>();
        eventos.Count.Should().Be(2);
    }

}