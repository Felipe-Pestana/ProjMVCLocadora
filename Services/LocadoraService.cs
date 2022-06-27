using Models;
using System;
using System.Data.SqlClient;

namespace Services
{
    public class LocadoraService
    {
        string dbConexao = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttchDBFileName=Locadora.mdf;";
        SqlConnection conn;

        public LocadoraService()
        {
            conn = new SqlConnection(dbConexao);
            conn.Open();
        }

        public int InserirLocadora(Locadora locadora)
        {
            string dataInsert = "insert into Locadora (Nome, DtLocacao, idCarro, idVaga, idCliente) values (@Nome, @DtLocacao, @idCarro, @idVaga, @idCliente); SELECT CAST(scope_identity() AS int;)";
            SqlCommand commandInsert = new SqlCommand(dataInsert, conn);

            commandInsert.Parameters.Add(new SqlParameter("@Nome", locadora.Nome));
            commandInsert.Parameters.Add(new SqlParameter("@DtLocacao", locadora.DtLocacao));
            commandInsert.Parameters.Add(new SqlParameter("idCarro", locadora.Carro));
            commandInsert.Parameters.Add(new SqlParameter("@idVaga", locadora.Vaga));
            commandInsert.Parameters.Add(new SqlParameter("@idCliente", locadora.Cliente));
            
            //commandInsert.ExecuteNonQuery();

            return (Int32)commandInsert.ExecuteScalar();
        }
        public bool ConsultarTudoLocadora()
        {
            return true;
        }
    }
}
