
using MeuSiteEmMVC.Models;

namespace MeuSiteEmMVC.Repositorio
{
    public interface IContatoRepositorio
    {
        List<ContatoModel> BuscarTodos();
        bool Adicionar(ContatoModel contato);
        bool Editar(ContatoModel contato);
        void Deletar(int id);
        void Esconder(int id);
        ContatoModel BuscarPorId(int id);
    }
}