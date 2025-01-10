using Microsoft.AspNetCore.Mvc;
using SiteMouseTeclados.Context;
using SiteMouseTeclados.Models;
using SiteMouseTeclados.ViewModels;

public class ProdutosController : Controller
{
    private readonly AppDbContext _context;

    public ProdutosController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var produtos = _context.Produtos.ToList();

        var produtoViewModels = produtos.Select(p => new ProdutoViewModel
        {
            ProdutoId = p.Id,
            Nome = p.Nome,
            Resumo = p.Resumo,
            Categoria = p.Categoria,
            Valor = p.Valor,
            ImageFileName = p.ImageFileName,
        }).ToList();

        return View(produtoViewModels);
    }

    public IActionResult NovoProduto()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> NovoProduto(ProdutoViewModel model)
    {
        if (ModelState.IsValid)
        {
            // Mapear o ViewModel para a entidade Produto
            var produto = new Produto
            {
                Nome = model.Nome,
                Resumo = model.Resumo,
                Categoria = model.Categoria,
                Valor = model.Valor,
                ImageFileName = model.ImageFileName // Salvar o nome do arquivo como texto
            };

            // Salvar no banco de dados
            _context.Add(produto);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        return View(model);
    }






}
