using Microsoft.AspNetCore.Mvc;
using SiteMouseTeclados.Context;
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

        var produtoViewModels = produtos.Select(p=> new ProdutoViewModel
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
}
