using Controllers;
using Models;
using Services;
using System;

namespace ProjMVCLocadora
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Cliente cliente = new Cliente()
            { 
                Name = "Felipe",
                Telefone = "16 1234-9876"
            };

            Carro carro = new Carro()
            {
                Marca = "Volkswagen",
                Modelo = "Jetta",
                AnoFab = 2011,
                AnoModelo = 2012,
                Placa = "ABC-1234"
            };

            Vaga vaga = new Vaga()
            {
                Descricao = "Liberado"
            };

            Locadora locadora = new Locadora()
            {
                Nome = "Rent a Car",
                DtLocacao = DateTime.Now,
                Carro = new CarroController().InserirCarro(carro),
                Vaga = new VagaController().InserirVaga(vaga),
                Cliente = new ClienteController().InserirCliente(cliente)
            };

            new LocadoraController().InserirLocadora(locadora);
        }
    }
}
