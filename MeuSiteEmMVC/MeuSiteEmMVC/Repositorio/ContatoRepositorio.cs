using MeuSiteEmMVC.Data;
using MeuSiteEmMVC.Models;

namespace MeuSiteEmMVC.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio
    {
        private readonly BancoContext _bancoContext;

        public ContatoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public ContatoModel Adicionar(ContatoModel contato)
        {
            _bancoContext.Contato.Add(contato);
            _bancoContext.SaveChanges();
            return contato;
        }

        public void Deletar(int id)
        {

            ContatoModel? contato = _bancoContext.Contato.FirstOrDefault(x => x.Id == id);

            if (contato == null) { throw new System.Exception("Id de contato nulo"); }

            _bancoContext.Contato.Remove(contato);
            _bancoContext.SaveChanges();
            //return contato;
        }

        public List<ContatoModel> BuscarTodos()
        {
            return _bancoContext.Contato.ToList();
        }
    }
}
