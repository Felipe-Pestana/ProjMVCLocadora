using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public abstract class Pessoa
    {
        public int Id { get; set;  }
        public string Nome { get; set; }
        public string Telefone { get; set; }
    }
}
