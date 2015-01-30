using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoDeDados
{
    public class Usuario
    {
        public virtual int Id { get; set; }

        public virtual string Email { get; set; }

        public virtual string Nome { get; set; }

        public virtual string Senha { get; set; }

        public Usuario()
        { 
            
        }

        public Usuario(string email, string nome, string senha)
        {
            this.Email = email;
            this.Nome = nome;
            this.Senha = senha;
        }
    }
}
