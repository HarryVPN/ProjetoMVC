using System.ComponentModel.DataAnnotations.Schema;

namespace MeuSiteEmMVC.Models
{
    public class DenunciaModel
    {
        public int id { get; set; }
        public string? imagem { get; set; }
        public required string contexto { get; set; }
        
        [NotMapped] 
        public virtual IFormFile? arquivoImg { get; set; }
    }
}
