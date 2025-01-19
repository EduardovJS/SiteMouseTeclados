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
    public IActionResult NovoProduto(ProdutoViewModel model)
    {

        var fileName = Path.GetFileName(model.Image.FileName); // Extrai o nome do arquivo
        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", fileName);


        using (var stream = new FileStream(path, FileMode.Create))
        {
            model.Image.CopyTo(stream);
        }


        model.ImageFileName = fileName;

        var produto = new Produto
        {
            Nome = model.Nome,
            Resumo = model.Resumo,
            Categoria = model.Categoria,
            Valor = model.Valor,
            ImageFileName = model.ImageFileName, // Salva o nome do arquivo da imagem (relativo)
                                                 // ImageUrl = model.ImageUrl, // Se você for armazenar a URL completa, descomente esta linha
        };

        _context.Produtos.Add(produto);
        _context.SaveChanges();

        return RedirectToAction("Index"); // Redireciona para a página inicial após salvar
    }
    public IActionResult Delete(int id)
    {
        var produto = _context.Produtos.FirstOrDefault(p => p.Id == id);

        if (produto == null)
        {
            return NotFound();
        }

        _context.Produtos.Remove(produto);
        _context.SaveChanges();

        return RedirectToAction("Index");

    }

    public IActionResult EditarProduto()
    {
        return View();
    }


}
