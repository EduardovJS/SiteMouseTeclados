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
    public IActionResult NovoProduto(ProdutoViewModel model, IFormFile image)
    {
        // Verifica se o arquivo foi enviado
        if (image != null && image.Length > 0)
        {
            var fileName = Path.GetFileName(image.FileName); // Extrai o nome do arquivo
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", "Produto", fileName);

         
            using (var stream = new FileStream(path, FileMode.Create))
            {
                image.CopyTo(stream);
            }


            model.ImageFileName = path;

            

        }
        else
        {
            // Se não houver imagem, você pode atribuir um valor padrão ou lançar um erro
            ModelState.AddModelError("image", "A imagem é obrigatória.");
            return View(model);
        }

        // Verifica se o modelo é válido antes de salvar no banco
        if (!ModelState.IsValid)
        {
            return View(model); // Retorna para a view com os erros de validação
        }

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



}
