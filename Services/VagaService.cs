using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class VagaService
    {
        string dbConexao = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttchDBFileName=Locadora.mdf;";
        SqlConnection conn;

        public VagaService()
        {
            conn = new SqlConnection(dbConexao);
            conn.Open();
        }

        public int InserirVaga(Vaga vaga)
        {
            string dataInsert = "insert into Vaga (Descricao) values (@Descricao); SELECT CAST(scope_identity() AS int;)";
            SqlCommand commandInsert = new SqlCommand(dataInsert, conn);

            commandInsert.Parameters.Add(new SqlParameter("@Descricao", vaga.Descricao));
            
            //commandInsert.ExecuteNonQuery();

            return (Int32)commandInsert.ExecuteScalar();
        }
        public bool ConsultarTudoVaga()
        {
            return true;
        }
    }
}
