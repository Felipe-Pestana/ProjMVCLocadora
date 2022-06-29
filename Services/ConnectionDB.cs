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
        string dbConexao = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDBFileName=D:\Trabalhos-Pestana\ProjMVCLocadora\Banco\locadora2.mdf;";
        SqlConnection conn;

        public ConnectionDB()
        {
            conn = new SqlConnection(dbConexao);
        }

        public SqlConnection OpenConnectionDB()
        {
            return conn;
        }

        public void CloseConnectionDB()
        {
            conn.Close();
        }
    }
}
