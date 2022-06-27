﻿using Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public class LocadoraController
    {
        public int InserirLocadora(Locadora locadora)
        {
            return new LocadoraService().InserirLocadora(locadora);
        }

        public bool ConsultarTudoLocadora()
        {
            return new LocadoraService().ConsultarTudoLocadora();
        }
    }
}