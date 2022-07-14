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
        SqlConnection conn;
        ConnectionDB ConnectionDB;
        public ClienteService()
        {
            ConnectionDB = new ConnectionDB();
            conn = ConnectionDB.OpenConnectionDB();
        }
        //public int InserirCliente(Cliente cliente)
        public Cliente InserirCliente(Cliente cliente)
        {
            conn.Open();
            string dataInsert = "insert into Cliente (Nome, Telefone) values (@Nome, @Telefone); SELECT CAST(scope_identity() AS int);";
            SqlCommand commandInsert = new SqlCommand(dataInsert, conn);

            commandInsert.Parameters.Add(new SqlParameter("@Nome", cliente.Nome));
            commandInsert.Parameters.Add(new SqlParameter("@Telefone", cliente.Telefone));

            //commandInsert.ExecuteNonQuery();

            Int32 idCliente = (Int32)commandInsert.ExecuteScalar();
            cliente.Id = idCliente;
            conn.Close();
            return cliente;
        }

        public bool ConsultarTudoCliente()
        {
            return true;
        }
    }
}
