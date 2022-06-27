using Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public class VagaController
    {
        public int InserirVaga(Vaga vaga)
        {
            return new VagaService().InserirVaga(vaga);
        }

        public bool ConsultarTudoVaga()
        {
            return new VagaService().ConsultarTudoVaga();
        }
    }
}
