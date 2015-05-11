using System;
using System.Collections.Generic;
using MusicPlay.Core.Models;
using MusicPlay.Repository.AcessoBanco; 

namespace MusicPlay.Repository.Repositories.FavoritesRepositories
{
    public class GenerosFavRepository
    {
        private readonly List<GenerosMusicais> generos;
        private enum Procedures
        {
            Sp_InsGenerosFavoritosUsua,
            Sp_DelGenerosFavoritosUsua,
            Sp_SelGenerosFavoritosUsua
        }

        public List<GenerosMusicais> GetGenerosFavoritosUsua(int Cod_Usua)
        {
            using(var cb = new ConexaoBase())
            {
                cb.ExecutaProcedure(Procedures.Sp_SelGenerosFavoritosUsua);
                cb.AdicionaParametros("@Cod_Usua", Cod_Usua);
                var reader = cb.ExecuteReader();
                while (reader.Read())
                {
                    generos.Add(new GenerosMusicais()
                    {
                        Num_SeqlGenero = (int)reader["Id"],
                        Nom_Genero = reader["Genero"].ToString()
                    });
                }
            }
            return generos;
        }

        public void PostGenerosFavoritosUsua(int Cod_Usua, int Num_SeqlGeneros)
        {
            using (var cb = new ConexaoBase())
            {
                cb.ExecutaProcedure(Procedures.Sp_InsGenerosFavoritosUsua);
                cb.AdicionaParametros("@Cod_Usua", Cod_Usua);
                cb.AdicionaParametros("@Num_SeqlGeneros", Num_SeqlGeneros);
                cb.ExecuteNonQuery();
            }
        }

        public void DeleteGenerosFavoritosUsua(int Cod_Usua, int Num_SeqlGeneros)
        {
            using (var cb = new ConexaoBase())
            {
                cb.ExecutaProcedure(Procedures.Sp_DelGenerosFavoritosUsua);
                cb.AdicionaParametros("@Cod_Usua", Cod_Usua);
                cb.AdicionaParametros("@Num_SeqlGeneros", Num_SeqlGeneros);
                cb.ExecuteNonQuery();
            }
        }
    }
}
