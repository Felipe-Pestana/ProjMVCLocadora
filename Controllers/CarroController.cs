using Models;
using Services;
using System;

namespace Controllers
{
    public class CarroController
    {
        //public int InserirCarro(Carro carro)
        public Carro InserirCarro(Carro carro)
        {
            return new CarroService().InserirCarro(carro);
        }

        public bool ConsultarTudoCarro()
        {
            return new CarroService().ConsultarTudoCarro();
        }
    }
}
