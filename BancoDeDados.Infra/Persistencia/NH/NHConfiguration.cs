using FluentNHibernate.Cfg;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoDeDados.Infra.Persistencia.NH
{
    public class NHConfiguration
    {
        public static ISession ObterSessao()
        {
            var connectionString = "server=fec42f82-fc11-45d1-9581-a42f00b6fcef.mysql.sequelizer.com;database=dbfec42f82fc1145d19581a42f00b6fcef;uid=vgckniguogpgujwl;pwd=mBX8estruj4etVXZcQGS3ZNfz8U4SyTZnEDQKn6E5VevxiCUzTmfXiGuWSFeExG4";

            // Configuração

            var configuration = Fluently
                .Configure()
                .Database(FluentNHibernate.Cfg.Db.MySQLConfiguration.Standard.ConnectionString(connectionString));


            configuration.Mappings(f => f.FluentMappings.Add<UsuarioMap>());
            //=========================

            var cfg = configuration.BuildConfiguration();

            var SessionFactory = cfg.BuildSessionFactory();

            //new NHibernate.Tool.hbm2ddl.SchemaExport(cfg).Execute(false, true, false);

            //============================

            var session = SessionFactory.OpenSession();

            return session;
        }
    }
}
