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
            SqlConnection = new SqlConnection("Server=192.168.7.12; Database=64Beats; User Id=sqlhomolog; password=1eng@ENG");
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

            OpenConnection();
        }

        protected SqlConnection OpenConnection()
        {
            if (SqlCommand.Connection.State == ConnectionState.Broken)
            {
                SqlCommand.Connection.Close();
                SqlCommand.Connection.Open();
            }

            if (SqlCommand.Connection.State == ConnectionState.Closed)
                SqlCommand.Connection.Open();

            return SqlCommand.Connection;
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
