using LojaWebApp.Data;
using LojaWebApp.Models;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LojaWebApp.Migrations
{
    /// <inheritdoc />
    public partial class CargaInicialProduto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var context = new LojaDbContext();
            context.Produto.AddRange(ObterCargaInicial());
            context.SaveChanges();
        }

        private IList<Produto> ObterCargaInicial()
        {
            return new List<Produto>()
       {
          new Produto
          {
              Nome = "PlayStation 3",
              Descricao = "O PlayStation 3 ou PS3 ",
              ImagemUri = "/imagens/Ps3.jpeg",
              DataCadastro = DateTime.Now,
              EntregaExpressa = true,
              Preco = 350.00,
          },
          new Produto
          {
              Nome = "Xbox 360",
              Descricao = "Explore o Xbox 360. ",
              ImagemUri = "/imagens/xbox.png",
              DataCadastro = DateTime.Now,
              EntregaExpressa = true,
              Preco = 400.00,
          },
          new Produto
          {
              Nome = "Nintendo Wii",
              Descricao = "O Nintendo Wii é um console",
              ImagemUri = "/imagens/Wii-Console.png",
              DataCadastro = DateTime.Now,
              EntregaExpressa = true,
              Preco = 200.00,
          },

       };

        }
    }
}
