using LojaWebApp.Models;
using LojaWebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LojaWebApp.Pages
{
    public class CreateModel : PageModel
    {
        private IProdutoService _service;
        public SelectList MarcaOptionItems { get; set; }

        public CreateModel(IProdutoService produtoService)
        {
            _service = produtoService;
        }

        public void OnGet()
        {
            MarcaOptionItems = new SelectList(_service.ObterTodasAsMarcas(),
                                                nameof(Marca.MarcaId),
                                                nameof(Marca.Descricao));
        }


        [BindProperty]
        public Produto Produto { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _service.Incluir(Produto);

            return RedirectToPage("/Index");
        }
    }
}