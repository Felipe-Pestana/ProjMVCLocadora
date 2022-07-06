using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Services
{
    public class LocadoraService
    {
        SqlConnection conn;
        ConnectionDB connectionDB;

        public LocadoraService()
        {
            connectionDB = new ConnectionDB();
            conn = connectionDB.OpenConnectionDB();
        }

        public Locadora InserirLocadora(Locadora locadora)
        {
            conn.Open();
            string dataInsert = "insert into Locadora (Nome, DtLocacao, idCarro, idVaga, idCliente) values (@Nome, @DtLocacao, @idCarro, @idVaga, @idCliente); SELECT CAST(scope_identity() AS int);";
            SqlCommand commandInsert = new SqlCommand(dataInsert, conn);

            commandInsert.Parameters.Add(new SqlParameter("@Nome", locadora.Nome));
            commandInsert.Parameters.Add(new SqlParameter("@DtLocacao", locadora.DtLocacao));
            commandInsert.Parameters.Add(new SqlParameter("@idCarro", locadora.Carro.Id));
            commandInsert.Parameters.Add(new SqlParameter("@idVaga", locadora.Vaga.Id));
            commandInsert.Parameters.Add(new SqlParameter("@idCliente", locadora.Cliente.Id));
            
            //commandInsert.ExecuteNonQuery();
            Int32 idLocadora = (Int32)commandInsert.ExecuteScalar();
            conn.Close();

            locadora.Id = idLocadora;

            return locadora;
        }
        public List<Locadora> ConsultarTudoLocadora()
        {

            List<Locadora> lst = new List<Locadora>();

            StringBuilder sb = new StringBuilder();

            sb.Append(" select l.Id, ");
            sb.Append("        l.Nome, ");
            sb.Append("        l.DtLocacao, ");
            sb.Append("        c.Modelo ModeloCarro, ");
            sb.Append("        v.Descricao, ");
            sb.Append("        p.Nome NomeCliente ");
            sb.Append("   from Locadora l, ");
            sb.Append("        Carro c,");
            sb.Append("        Vaga v, ");
            sb.Append("        Cliente p ");
            sb.Append("  where l.idCarro = c.Id ");
            sb.Append("    and l.idCliente = p.Id ");
            sb.Append("    and l.idVaga = v.Id ");

            conn.Open();

            SqlCommand command = new SqlCommand(sb.ToString(), conn);
            SqlDataReader sqlDataReader = command.ExecuteReader();

            while (sqlDataReader.Read())
            {
                Locadora locadora = new Locadora();

                locadora.Id = Convert.ToInt32(sqlDataReader["Id"]);
                locadora.Nome = sqlDataReader["Nome"].ToString();
                locadora.DtLocacao = DateTime.Parse(sqlDataReader["DtLocacao"].ToString());
                locadora.Carro = new Carro() { Modelo = sqlDataReader["ModeloCarro"].ToString() };
                locadora.Vaga = new Vaga() { Descricao = sqlDataReader["Descricao"].ToString() };
                locadora.Cliente = new Cliente() { Nome = sqlDataReader["NomeCliente"].ToString() };

                lst.Add(locadora);
            }
            conn.Close();
            return lst;
        }
    }
}
