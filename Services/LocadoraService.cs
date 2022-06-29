using Models;
using System;
using System.Data.SqlClient;

namespace Services
{
    public class LocadoraService
    {
        SqlConnection conn;
        ConnectionDB connectionDB;

        public LocadoraService()
        {
            connectionDB = new ConnectionDB();
            conn = connectionDB.OpenConnectionDB();
        }

        public int InserirLocadora(Locadora locadora)
        {
            conn.Open();
            string dataInsert = "insert into Locadora (Nome, DtLocacao, idCarro, idVaga, idCliente) values (@Nome, @DtLocacao, @idCarro, @idVaga, @idCliente); SELECT CAST(scope_identity() AS int);";
            SqlCommand commandInsert = new SqlCommand(dataInsert, conn);

            commandInsert.Parameters.Add(new SqlParameter("@Nome", locadora.Nome));
            commandInsert.Parameters.Add(new SqlParameter("@DtLocacao", locadora.DtLocacao));
            commandInsert.Parameters.Add(new SqlParameter("@idCarro", locadora.Carro.Id));
            commandInsert.Parameters.Add(new SqlParameter("@idVaga", locadora.Vaga.Id));
            commandInsert.Parameters.Add(new SqlParameter("@idCliente", locadora.Cliente.Id));
            
            //commandInsert.ExecuteNonQuery();
            Int32 idLocadora = (Int32)commandInsert.ExecuteScalar();
            conn.Close();
            return idLocadora;
        }
        public bool ConsultarTudoLocadora()
        {
            return true;
        }
    }
}
