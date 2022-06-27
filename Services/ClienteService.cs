using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ClienteService
    {
        string dbConexao = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttchDBFileName=Locadora.mdf;";
        SqlConnection conn;

        public ClienteService()
        {
            conn = new SqlConnection(dbConexao);
            conn.Open();
        }

        public int InserirCliente(Cliente cliente)
        {
            string dataInsert = "insert into Cliente (Nome, Telefone) values (@Nome, @Telefone); SELECT CAST(scope_identity() AS int;)";
            SqlCommand commandInsert = new SqlCommand(dataInsert, conn);

            commandInsert.Parameters.Add(new SqlParameter("@Nome", cliente.Name));
            commandInsert.Parameters.Add(new SqlParameter("@Telefone", cliente.Telefone));

            //commandInsert.ExecuteNonQuery();

            return (Int32)commandInsert.ExecuteScalar();
        }

        public bool ConsultarTudoCliente()
        {
            return true;
        }
    }
}
