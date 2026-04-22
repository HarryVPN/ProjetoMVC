

namespace MeuSiteEmMVC.Models
{
    public class HomeModel
    {
         public string Email;
         public string Nome;

        public HomeModel(string email, string nome)
        {
            this.Email = email;
            this.Nome = nome;
        }
    }
}
