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
            Nome = p.Nome,
            Resumo = p.Resumo,
            Categoria = p.Categoria,
            Valor = p.Valor,
        }).ToList();

        return View(produtoViewModels);

    }
}
