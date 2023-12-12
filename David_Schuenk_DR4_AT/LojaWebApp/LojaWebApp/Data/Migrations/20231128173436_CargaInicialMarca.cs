using LojaWebApp.Data;
using LojaWebApp.Models;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LojaWebApp.Migrations
{
    /// <inheritdoc />
    public partial class CargaInicialMarca : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            var context = new LojaDbContext();
            context.Marca.AddRange(ObterCargaInicial());
            context.SaveChanges();

        }

        private IList<Marca> ObterCargaInicial()
        {
            return new List<Marca>()
            {
                new Marca(){Descricao = "Sony"},
                new Marca(){Descricao = "Microsoft"},
                new Marca(){Descricao = "nintendo"}
            };
        }

    }
}
