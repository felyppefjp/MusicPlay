using System;
using System.Collections.Generic;
using MusicPlay.Core.Models;
using MusicPlay.Repository.AcessoBanco; 

namespace MusicPlay.Repository.Repositories.FavoritesRepositories
{
    public class MusicasFavRepository
    {
        private readonly List<Musicas> musicas;

        private enum Procedures
        {
            Sp_InsMusicasFavoritosUsua,
            Sp_DelMusicasFavoritosUsua,
            Sp_SelMusicasFavoritasUsua
        }

        public List<Musicas> GetMusicasFavoritasUsua(int Cod_Usua) 
        {
            using(var cb = new ConexaoBase())
            {
                cb.ExecutaProcedure(Procedures.Sp_SelMusicasFavoritasUsua);
                cb.AdicionaParametros("@Cod_Usua", Cod_Usua);
                var reader = cb.ExecuteReader();
                while(reader.Read())
                musicas.Add(new Musicas()
                {
                    Num_SeqlMusica = (int)reader["Id"],
                    Nom_Musica = reader["Musica"].ToString(),
                    Url_Video = reader["Video"].ToString(),
                    Num_Tempo = (TimeSpan)reader["Duracao"]
                });
            }
            
            return musicas;
        }

        public void PostMusicasFavoritosUsua(int Cod_Usua, int Num_SeqlMusica)
        {
            using (var cb = new ConexaoBase())
            {
                cb.ExecutaProcedure(Procedures.Sp_InsMusicasFavoritosUsua);
                cb.AdicionaParametros("@Cod_Usua", Cod_Usua);
                cb.AdicionaParametros("@Num_SeqlMusica", Num_SeqlMusica);
                cb.ExecuteNonQuery();
            }
        }

        public void DeleteMusicasFavoritosUsua(int Cod_Usua, int Num_SeqlMusica)
        {
            using (var cb = new ConexaoBase())
            {
                cb.ExecutaProcedure(Procedures.Sp_DelMusicasFavoritosUsua);
                cb.AdicionaParametros("@Cod_Usua", Cod_Usua);
                cb.AdicionaParametros("@Num_SeqlMusica", Num_SeqlMusica);
                cb.ExecuteNonQuery();
            }
        }
    }
}
