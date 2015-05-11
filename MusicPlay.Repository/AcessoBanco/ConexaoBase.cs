using System;
using System.Data;
using System.Data.SqlClient;

namespace MusicPlay.Repository.AcessoBanco
{
    public class ConexaoBase : IDisposable
    {
        private static SqlConnection SqlConnection { get; set; }
        private SqlCommand SqlCommand { get; set; }

        public ConexaoBase()
        {
            SqlConnection = new SqlConnection(@"data source=.; Integrated Security=SSPI;Initial Catalog=MusicPlay");
            SqlConnection.Open();
        }

        public void AdicionaParametros(string nomeParametro, object valor)
        {
            SqlCommand.Parameters.AddWithValue(nomeParametro, valor);
        }

        public void ExecutaProcedure(object procedure)
        {
            SqlCommand = new SqlCommand(procedure.ToString(), SqlConnection)
            {
                CommandType = CommandType.StoredProcedure,
                CommandTimeout = 99999
            };
        }

        public int ExecuteNonQuery()
        {
            return SqlCommand.ExecuteNonQuery();
        }

        public IDataReader ExecuteReader()
        {
            return SqlCommand.ExecuteReader();
        }
        public void Dispose()
        {
            if (SqlConnection.State == ConnectionState.Open)
            {
                SqlConnection.Close();
            }
        }
    }
}
