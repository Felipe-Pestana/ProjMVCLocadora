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
        ConnectionDB ConnectionDB;
        public VagaService()
        {
            ConnectionDB = new ConnectionDB();
            conn = ConnectionDB.OpenConnectionDB();
        }
        //public int InserirVaga(Vaga vaga)
        public Vaga InserirVaga(Vaga vaga)
        {
            conn.Open();
            string dataInsert = "insert into Vaga (Descricao) values (@Descricao); SELECT CAST(scope_identity() AS int);";
            SqlCommand commandInsert = new SqlCommand(dataInsert, conn);

            commandInsert.Parameters.Add(new SqlParameter("@Descricao", vaga.Descricao));
            
            //commandInsert.ExecuteNonQuery();

            Int32 idVaga = (Int32)commandInsert.ExecuteScalar();
            vaga.Id = idVaga;
            conn.Close();

            return vaga;
        }
        public bool ConsultarTudoVaga()
        {
            return true;
        }
    }
}
