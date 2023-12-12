using LojaWebApp.Data;
using LojaWebApp.Models;

namespace LojaWebApp.Services.Data
{
    public class ProdutoService : IProdutoService
    {
        private LojaDbContext _context;

        public ProdutoService(LojaDbContext context)
        {
            _context = context;
        }

        public void Alterar(Produto produto)
        {
            var ProdutoEncontrado = Obter(produto.ProdutoId);
            ProdutoEncontrado.Nome = produto.Nome;
            ProdutoEncontrado.Descricao = produto.Descricao;
            ProdutoEncontrado.Preco = produto.Preco;
            ProdutoEncontrado.EntregaExpressa = produto.EntregaExpressa;
            ProdutoEncontrado.DataCadastro = produto.DataCadastro;
            ProdutoEncontrado.ImagemUri = produto.ImagemUri;
            ProdutoEncontrado.MarcaId = produto.MarcaId;

            _context.SaveChanges();
        }

        public void Excluir(int id)
        {
            var ProdutoEncontrado = Obter(id);
            _context.Produto.Remove(ProdutoEncontrado);
            _context.SaveChanges();
        }

        public void Incluir(Produto produto)
        {
            _context.Produto.Add(produto);
            _context.SaveChanges();
        }

        public Produto Obter(int id)
        {
            return _context.Produto.SingleOrDefault(item => item.ProdutoId == id);
        }

        public IList<Marca> ObterTodasAsMarcas()
        {
            return _context.Marca.ToList();
        }

        public IList<Produto> ObterTodos()
        {
            return _context.Produto.ToList();
        }
    }
}
