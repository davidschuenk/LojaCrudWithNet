using LojaWebApp.Models;

namespace LojaWebApp.Services
{
    public interface IProdutoService
    {
        IList<Produto> ObterTodos();
        Produto Obter(int id);
        void Incluir(Produto produto);
        void Alterar(Produto produto);
        void Excluir(int id);
        IList<Marca> ObterTodasAsMarcas();
    }
}
