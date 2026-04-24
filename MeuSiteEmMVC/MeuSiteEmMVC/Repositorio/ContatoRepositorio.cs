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

        private static bool ContatoInvalido(ContatoModel contato) {
            return (contato.Nome == null || contato.Email == null);
        }

        public ContatoModel BuscarPorId(int id)
        {
            ContatoModel? contato = _bancoContext.Contato.FirstOrDefault(x => x.Id == id);

            if (contato == null) { throw new System.Exception("Id de contato nulo"); }
            return contato;
        }

        public bool Adicionar(ContatoModel contato)
        {
            if (ContatoInvalido(contato)) {
                return false;
            }
            
            _bancoContext.Contato.Add(contato);
            _bancoContext.SaveChanges();
            return true;
        }

        public bool Editar(ContatoModel contato)
        {
            if (ContatoInvalido(contato)) {
                return false;
            }

            _bancoContext.Contato.Update(contato);
            _bancoContext.SaveChanges();
            return true;
        }

        public void Deletar(int id)
        {
           ContatoModel contato = BuscarPorId(id);

           _bancoContext.Contato.Remove(contato);
           _bancoContext.SaveChanges();
        }

        public void Esconder(int id)
        {
            ContatoModel contato = BuscarPorId(id);

            contato.Esconder = (byte)(contato.Esconder == 1 ? 0 : (contato.Esconder == 0 ? 1 : contato.Esconder));
            
            _bancoContext.Contato.Update(contato);
            _bancoContext.SaveChanges();
        }
        
        public List<ContatoModel> BuscarTodos()
        {
            return _bancoContext.Contato.ToList();
        }

       
    }
}
