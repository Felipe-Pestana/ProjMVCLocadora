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
        ConnectionDB ConnectionDB;
        public LocadoraService()
        {
            ConnectionDB = new ConnectionDB();
            conn = ConnectionDB.OpenConnectionDB();
        }

        public Locadora InserirLocadora(Locadora locadora)
        {
            conn.Open();

            string dataInsert = "insert into Locadora (Nome, DtLocacao, idCarro, idVaga, idCliente) values (@Nome, @DtLocacao, @idCarro, @idVaga, @idCliente); SELECT CAST(scope_identity() AS int);";
            SqlCommand commandInsert = new SqlCommand(dataInsert, conn);

            commandInsert.Parameters.Add(new SqlParameter("@Nome", locadora.Nome));
            commandInsert.Parameters.Add(new SqlParameter("@DtLocacao", locadora.DtLocacao));
            commandInsert.Parameters.Add(new SqlParameter("idCarro", locadora.Carro.Id));
            commandInsert.Parameters.Add(new SqlParameter("@idVaga", locadora.Vaga.Id));
            commandInsert.Parameters.Add(new SqlParameter("@idCliente", locadora.Cliente.Id));
            
            //commandInsert.ExecuteNonQuery();

            Int32 idLocadora = (Int32)commandInsert.ExecuteScalar();
            commandInsert.ExecuteScalar();
            locadora.Id = idLocadora;
            conn.Close();
            return locadora;
        }
        public List<Locadora> ConsultarTudoLocadora()
        {
            List<Locadora> locadoraList = new List<Locadora>();

            StringBuilder querySelect = new StringBuilder();
            
            querySelect.Append("SELECT l.Id, ");
            querySelect.Append("l.Nome, ");
            querySelect.Append("l.DtLocacao, ");
            querySelect.Append("c.Modelo ModeloCarro, ");
            querySelect.Append("v.Descricao, ");
            querySelect.Append("p.Nome NomeCliente ");
            querySelect.Append("FROM Locadora l, ");
            querySelect.Append("Carro c, ");
            querySelect.Append("Vaga v, ");
            querySelect.Append("Cliente p ");
            querySelect.Append("WHERE l.idCarro = c.Id ");
            querySelect.Append("AND l.idCliente = p.Id ");
            querySelect.Append("AND l.idVaga = v.Id");

            conn.Open();
            SqlCommand dataReader = new SqlCommand(querySelect.ToString(), conn);

            SqlDataReader sqlDataReader = dataReader.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Locadora locadora = new Locadora();

                locadora.Id = Convert.ToInt32(sqlDataReader["Id"]);
                locadora.Nome = sqlDataReader["Nome"].ToString();
                locadora.DtLocacao = DateTime.Parse(sqlDataReader["DtLocacao"].ToString());
                locadora.Carro = new Carro() { Modelo = sqlDataReader["ModeloCarro"].ToString() };
                locadora.Vaga = new Vaga() { Descricao = sqlDataReader["Descricao"].ToString() };
                locadora.Cliente = new Cliente() { Nome = sqlDataReader["NomeCliente"].ToString() };

                locadoraList.Add(locadora);
            }
            conn.Close();
            return locadoraList;
        }
    }
}