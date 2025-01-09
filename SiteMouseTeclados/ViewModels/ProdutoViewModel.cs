using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using SiteMouseTeclados.Models;

namespace SiteMouseTeclados.ViewModels
{
    public class ProdutoViewModel
    {
        public int ProdutoId { get; set; }

        [MaxLength(100)]
        [Required(ErrorMessage = "O nome do produto é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O resumo do produto é obrigatório")]
        public string Resumo { get; set; }

        public string Categoria { get; set; }

        [Required(ErrorMessage = "O valor do produto é obrigatório")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Valor { get; set; }
        public List<string> Categorias { get; set; }
        [MaxLength(100)]
        public string ImageFileName { get; set; }

    }
}
