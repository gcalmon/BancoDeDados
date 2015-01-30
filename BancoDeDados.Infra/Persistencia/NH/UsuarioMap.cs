using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;

namespace BancoDeDados.Infra.Persistencia.NH
{
    public class UsuarioMap : ClassMap<Usuario>
    {
        public UsuarioMap()
        {
            this.Id(m => m.Id)
                    .GeneratedBy.Identity();

            this.Map(m => m.Nome)
                .Not.Nullable()
                .Length(40);

            this.Map(m => m.Email);

            this.Map(m => m.Senha);
        }
    }
}
