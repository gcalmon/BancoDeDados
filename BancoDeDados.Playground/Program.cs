using BancoDeDados.Infra;
using FluentNHibernate.Cfg;
using FluentNHibernate.Mapping;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Linq;
using BancoDeDados.Infra.Persistencia.NH;


namespace BancoDeDados.Playground
{
    

    class Program
    {
        static void Main(string[] args)
        {

            // MySql
            var connectionString = "server=fec42f82-fc11-45d1-9581-a42f00b6fcef.mysql.sequelizer.com;database=dbfec42f82fc1145d19581a42f00b6fcef;uid=vgckniguogpgujwl;pwd=mBX8estruj4etVXZcQGS3ZNfz8U4SyTZnEDQKn6E5VevxiCUzTmfXiGuWSFeExG4";

            var session = NHConfiguration.ObterSessao();

            var usuario = new Usuario("denisferrari@azys.com.br", "Denis Ferrari", "123456");

            IUsuarios usuariosNH = new BancoDeDados.Infra.Persistencia.NH.Usuarios(session);


            Console.ReadLine();

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
