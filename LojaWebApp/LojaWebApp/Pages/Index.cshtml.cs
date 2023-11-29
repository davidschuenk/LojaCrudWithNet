using LojaWebApp.Models;
using LojaWebApp.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LojaWebApp.Pages;

public class IndexModel : PageModel
{
    private IProdutoService _service;

    public IndexModel(IProdutoService produtoService)
    {
        _service = produtoService;
    }

    public IList<Produto> ListaProduto { get; private set; }

    public void OnGet()
    {
        ViewData["Title"] = "Home page";

        ListaProduto = _service.ObterTodos();
    }
}