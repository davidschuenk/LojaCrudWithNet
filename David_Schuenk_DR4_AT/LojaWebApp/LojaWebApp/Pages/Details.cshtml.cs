
using LojaWebApp.Models;
using LojaWebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LojaWebApp.Pages;

public class DetailsModel : PageModel
{
    private IProdutoService _service;

    public DetailsModel(IProdutoService produtoService)
    {
        _service = produtoService;
    }

    public Produto produto { get; private set; }
    public Marca Marca { get; private set; }

    public IActionResult OnGet(int id)
    {
        produto = _service.Obter(id);
        Marca = _service.ObterTodasAsMarcas().SingleOrDefault(item => item.MarcaId == produto.MarcaId);

        if (produto == null)
        {
            return NotFound();
        }

        return Page();
    }
}
