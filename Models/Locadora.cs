using System;

namespace Models
{
    public class Locadora
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public Carro Carro { get; set; }
        public Cliente Cliente { get; set; }
        public Vaga Vaga { get; set; }
        public DateTime DtLocacao { get; set; }

    }
}
