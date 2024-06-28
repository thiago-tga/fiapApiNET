using System;
using System.Collections.Generic;
using System.Linq;
using Fiap.Web.Alunos.Controllers;
using Fiap.Web.Alunos.Data;
using Fiap.Web.Alunos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using xunit;

namespace Fiap.Web.Alunos.Tests.Controllers

{
    public class AgendamentoControllerTests
    {
        [Fact]
        public void IndexDoisAgendamentos_ReturnsViewResultDoisAgendamentos()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "FiapDb")
                .Options;

            using (var context = new DatabaseContext(options))
            {
                context.Agendamentos.AddRange(
                    new AgendamentoModel { Endereco = "Endereço 1", Data = DateTime.Now, Cliente = "Cliente 1" },
                    new AgendamentoModel { Endereco = "Endereço 2", Data = DateTime.Now, Cliente = "Cliente 2" }
                );
                context.SaveChanges();
            }

            using (var context = new DatabaseContext(options))
            {
                var controller = new AgendamentoController(context);

                // Act
                var result = controller.Index();

                // Assert
                var viewResult = Assert.IsType<ViewResult>(result);
                Assert.Equal(200, viewResult.StatusCode); // Verifica se o status code é 200
                var model = Assert.IsAssignableFrom<IEnumerable<AgendamentoModel>>(viewResult.ViewData.Model);
                Assert.Equal(2, model.Count());
            }
        }
    }
}
