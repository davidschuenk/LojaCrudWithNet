
using LojaWebApp.Models;
using LojaWebApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LojaWebApp.Pages
{
    [Authorize]
    public class EditModel : PageModel
    {
        private IProdutoService _service;
        public SelectList MarcaOptionItems { get; set; }

        public EditModel(IProdutoService produtoService)
        {
            _service = produtoService;
        }

        [BindProperty]
        public Produto Produto { get; set; }

        public void OnGet(int id)
        {
            Produto = _service.Obter(id);
            MarcaOptionItems = new SelectList(_service.ObterTodasAsMarcas(),
                                                nameof(Marca.MarcaId),
                                                nameof(Marca.Descricao));
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _service.Alterar(Produto);

            return RedirectToPage("/Index");
        }

        public IActionResult OnPostDelete()
        {
            _service.Excluir(Produto.ProdutoId);

            TempData["TempMensagemSucesso"] = true;

            return RedirectToPage("/Index");
        }
    }
}
