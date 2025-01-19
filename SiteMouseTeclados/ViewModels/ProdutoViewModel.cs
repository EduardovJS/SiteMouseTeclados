using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using SiteMouseTeclados.Models;

namespace SiteMouseTeclados.ViewModels
{
    public class ProdutoViewModel
    {
        public int ProdutoId { get; set; }

        [Required(ErrorMessage = "O nome do produto é obrigatório")]
        [MaxLength(100, ErrorMessage = "O nome do produto deve ter no máximo 100 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O resumo do produto é obrigatório")]
        [MaxLength(500, ErrorMessage = "O resumo deve ter no máximo 500 caracteres")]
        public string Resumo { get; set; }

        [Required(ErrorMessage = "A categoria é obrigatória")]
        public string Categoria { get; set; }

        [Required(ErrorMessage = "O valor do produto é obrigatório")]
        [Range(0.01, 9999.99, ErrorMessage = "O valor deve estar entre 0,01 e 9999,99")]
        public decimal Valor { get; set; }
        public string ImageFileName { get; set; }
        public IFormFile Image { get; set; }
    }


}
