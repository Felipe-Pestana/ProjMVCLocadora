using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ConnectionDB
    {
        readonly string dbConexao = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDBFileName=C:\Users\Pes\source\repos\ProjMVCLocadora\Banco\Locadora.mdf;";
        readonly SqlConnection conn;

        public ConnectionDB()
        {
            conn = new SqlConnection(dbConexao);
        }

        public SqlConnection OpenConnectionDB()
        {
            return conn;
        }

        public void CloseConnection()
        {
            conn.Close();
        }
    }
}
