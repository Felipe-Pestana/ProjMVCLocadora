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
        SqlConnection conn;
        ConnectionDB connectionDB;

        public VagaService()
        {
            connectionDB = new ConnectionDB();
            conn = connectionDB.OpenConnectionDB();
        }

        public int InserirVaga(Vaga vaga)
        {
            conn.Open();
            string dataInsert = "insert into Vaga (Descricao) values (@Descricao); SELECT CAST(scope_identity() AS int);";
            SqlCommand commandInsert = new SqlCommand(dataInsert, conn);

            commandInsert.Parameters.Add(new SqlParameter("@Descricao", vaga.Descricao));

            //commandInsert.ExecuteNonQuery();
            int idVaga = (int)commandInsert.ExecuteScalar();
            conn.Close();

            return idVaga;
        }
        public bool ConsultarTudoVaga()
        {
            return true;
        }
    }
}
