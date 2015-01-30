using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                .Length(30);

            this.Map(m => m.Email);

            this.Map(m => m.Senha);
        }
    }
}
