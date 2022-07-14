﻿using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CarroService
    {
        readonly string dbConexao = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDBFileName=C:\Users\Pes\source\repos\ProjMVCLocadora\Banco\Locadora.mdf;";
        SqlConnection conn;

        public CarroService()
        {
            conn = new SqlConnection(dbConexao);
            conn.Open();
        }
        //public int InserirCarro(Carro, carro)
        public Carro InserirCarro(Carro carro)
        {
            string dataInsert = "insert into Carro (Marca, Modelo, AnoFabricacao, AnoModelo, Placa) values (@Marca, @Modelo, @AnoFabricacao, @AnoModelo, @Placa); SELECT CAST(scope_identity() AS int);";
            SqlCommand commandInsert = new SqlCommand(dataInsert, conn);

            commandInsert.Parameters.Add(new SqlParameter("@Marca", carro.Marca));
            commandInsert.Parameters.Add(new SqlParameter("@Modelo", carro.Modelo));
            commandInsert.Parameters.Add(new SqlParameter("@AnoFabricacao", carro.AnoFab));
            commandInsert.Parameters.Add(new SqlParameter("@AnoModelo", carro.AnoModelo));
            commandInsert.Parameters.Add(new SqlParameter("@Placa", carro.Placa));

            //commandInsert.ExecuteNonQuery();
            //return (Int32)commandInsert.ExecuteScalar();
            Int32 idCarro = (Int32)commandInsert.ExecuteScalar();

            carro.Id = idCarro;
            return carro;
        }
        public bool ConsultarTudoCarro()
        {
            return true;
        }
    }
}
