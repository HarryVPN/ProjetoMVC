
using MeuSiteEmMVC.Models;

namespace MeuSiteEmMVC.Repositorio
{
    public interface IContatoRepositorio
    {

        List<ContatoModel> BuscarTodos();
        ContatoModel Adicionar(ContatoModel contato);
        void Deletar(int id);
    }
}