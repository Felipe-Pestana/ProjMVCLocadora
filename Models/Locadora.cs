using System;

namespace Models
{
    public class Locadora
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Carro Carro { get; set; }
        public Cliente Cliente { get; set; }
        public Vaga Vaga { get; set; }
        public DateTime DtLocacao { get; set; }

        public override string ToString()
        {
            return "Código: " + Id +
                   "\nLocadora: " + Nome +
                   "\nModelo Carro: " + Carro.Modelo +
                   "\nVaga: " + Vaga.Descricao +
                   "\nCliente: " + Cliente.Nome +
                   "\nData: " + DtLocacao +
                   "\n\n";
        }
    }
}
