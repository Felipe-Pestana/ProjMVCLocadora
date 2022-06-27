using Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public class ClienteController
    {
        public int InserirCliente(Cliente cliente)
        {
            return new ClienteService().InserirCliente(cliente);
        }

        public bool ConsultarTudoCliente()
        {
            return new ClienteService().ConsultarTudoCliente();
        }
    }
}
