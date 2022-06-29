using Models;
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
        SqlConnection conn;
        ConnectionDB connectionDB;

        public CarroService()
        {
            connectionDB = new ConnectionDB();
            conn = connectionDB.OpenConnectionDB();
        }
        //public int InserirCarro(Carro carro)
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
            conn.Open();
            Int32 idCarro = (Int32)commandInsert.ExecuteScalar();
            conn.Close();
            carro.Id = idCarro;

            //return idCarro;
            return carro;
        }
        public bool ConsultarTudoCarro()
        {
            return true;
        }
    }
}
