using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;

namespace BancoDeDados.Infra.Persistencia.NH
{
    public class Usuarios : IUsuarios
    {
        protected ISession Session { get; set; }



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
                       .Contains<Usuario>(termo);
        }
    }
}
