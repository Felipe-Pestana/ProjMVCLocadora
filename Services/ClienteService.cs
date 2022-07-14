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
        readonly string dbConexao = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDBFileName=C:\Users\Pes\source\repos\ProjMVCLocadora\Banco\Locadora.mdf;";
        SqlConnection conn;

        public ClienteService()
        {
            conn = new SqlConnection(dbConexao);
            conn.Open();
        }
        //public int InserirCliente(Cliente cliente)
        public Cliente InserirCliente(Cliente cliente)
        {
            string dataInsert = "insert into Cliente (Nome, Telefone) values (@Nome, @Telefone); SELECT CAST(scope_identity() AS int);";
            SqlCommand commandInsert = new SqlCommand(dataInsert, conn);

            commandInsert.Parameters.Add(new SqlParameter("@Nome", cliente.Name));
            commandInsert.Parameters.Add(new SqlParameter("@Telefone", cliente.Telefone));

            //commandInsert.ExecuteNonQuery();

            Int32 idCliente = (Int32)commandInsert.ExecuteScalar();
            cliente.Id = idCliente;

            return cliente;
        }

        public bool ConsultarTudoCliente()
        {
            return true;
        }
    }
}
