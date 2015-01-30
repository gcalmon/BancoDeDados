using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoDeDados.Infra.Persistencia.NH
{
    public class Usuarios : IUsuarios
    {
        protected ISession Session { get; set; }

        public Usuarios(ISession session)
        {
            this.Session = session;
        }

        public void Salvar(Usuario usuario)
        {
            this.Session.SaveOrUpdate(usuario);
        }

        public Usuario ObterPorId(int id)
        {
            return this.Session.Get<Usuario>(id);
        }

        public IList<Usuario> ObterTodos()
        {
            return this.Session
                            .Query<Usuario>()
                            .ToList();
        }

        public IList<Usuario> ObterTodos(string termo)
        {
            return this.Session
                            .Query<Usuario>()
                            .Where(u => u.Nome.Contains(termo) &&
                                        u.Email.Contains(termo))
                            .ToList();
        }

        public void Excluir(int id)
        {
            this.Session.Delete(id);
        }
    }
}
