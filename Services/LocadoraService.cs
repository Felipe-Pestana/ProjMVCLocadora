using Models;
using System;
using System.Data.SqlClient;

namespace Services
{
    public class LocadoraService
    {
        readonly string dbConexao = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDBFileName=C:\Users\Pes\source\repos\ProjMVCLocadora\Banco\Locadora.mdf;";
        SqlConnection conn;

        public LocadoraService()
        {
            conn = new SqlConnection(dbConexao);
            conn.Open();
        }

        public Locadora InserirLocadora(Locadora locadora)
        {
            string dataInsert = "insert into Locadora (Nome, DtLocacao, idCarro, idVaga, idCliente) values (@Nome, @DtLocacao, @idCarro, @idVaga, @idCliente); SELECT CAST(scope_identity() AS int);";
            SqlCommand commandInsert = new SqlCommand(dataInsert, conn);

            commandInsert.Parameters.Add(new SqlParameter("@Nome", locadora.Nome));
            commandInsert.Parameters.Add(new SqlParameter("@DtLocacao", locadora.DtLocacao));
            commandInsert.Parameters.Add(new SqlParameter("idCarro", locadora.Carro.Id));
            commandInsert.Parameters.Add(new SqlParameter("@idVaga", locadora.Vaga.Id));
            commandInsert.Parameters.Add(new SqlParameter("@idCliente", locadora.Cliente.Id));
            
            //commandInsert.ExecuteNonQuery();

            Int32 idLocadora = (Int32)commandInsert.ExecuteScalar();
            //locadora.Id = idLocadora;

            return locadora;
        }
        public bool ConsultarTudoLocadora()
        {
            return true;
        }
    }
}
