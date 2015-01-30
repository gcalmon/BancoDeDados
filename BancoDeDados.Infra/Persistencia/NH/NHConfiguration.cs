using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using FluentNHibernate.Cfg;
using FluentNHibernate.Mapping;
using NHibernate;
using NHibernate.Linq;

namespace BancoDeDados.Infra.Persistencia.NH
{
    public class NHConfiguration
    {
        public static ISession ObterSessao()
        {
            // MySql
            var connectionString = "server=fec42f82-fc11-45d1-9581-a42f00b6fcef.mysql.sequelizer.com;database=dbfec42f82fc1145d19581a42f00b6fcef;uid=vgckniguogpgujwl;pwd=mBX8estruj4etVXZcQGS3ZNfz8U4SyTZnEDQKn6E5VevxiCUzTmfXiGuWSFeExG4";

            // Configuração

            var configuration = Fluently
                                        .Configure()
                                        .Database(FluentNHibernate.Cfg.Db.MySQLConfiguration.Standard.ConnectionString(connectionString));

            configuration.Mappings(f => f.FluentMappings.Add<UsuarioMap>());

            var cfg = configuration.BuildConfiguration();

            var sessionFactory = cfg.BuildSessionFactory();

            var session = sessionFactory.OpenSession();

            var usuario = new Usuario("acalmon@mpes.mp.br", "André Calmon", "11223344");

            //session.SaveOrUpdate(usuario);

            var usuarioss = session.Query<Usuario>()
                                   .ToArray();


            if (false)
            {
                // Conexão
                using (var con = new MySqlConnection(connectionString))
                {
                    try
                    {
                        // Abrir a conexão
                        con.Open();

                        // Executar o comando
                        IUsuarios usuarios = new Usuarios(con);

                        usuarios.Salvar(usuario);
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                    finally
                    {
                        // Fechar a conexão
                        if (con.State == System.Data.ConnectionState.Open)
                            con.Close();
                    }
                }
            }
        }
    }
}
