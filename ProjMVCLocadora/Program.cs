using Controllers;
using Models;
using Services;
using System;
using System.Collections.Generic;

namespace ProjMVCLocadora
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            Cliente cliente = new Cliente()
            { 
                Nome = "Felipe",
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
                //Carro = new Carro() { Id = new CarroService().InserirCarro(carro) },
                Carro = new CarroController().InserirCarro(carro),
                Vaga = new Vaga() { Id = new VagaController().InserirVaga(vaga), Descricao = vaga.Descricao },
                Cliente = new ClienteController().InserirCliente(cliente)
            };

            //Inserir Locadora
            new LocadoraController().InserirLocadora(locadora);*/

            List<Locadora> lst = new LocadoraController().ConsultarTudoLocadora();

            lst.ForEach(l => Console.WriteLine(l));
            
            
        }
    }
}
