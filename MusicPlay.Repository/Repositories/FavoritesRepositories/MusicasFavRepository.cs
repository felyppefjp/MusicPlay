using System;
using System.Collections.Generic;
using MusicPlay.Core.Models;
using MusicPlay.Repository.AcessoBanco; 

namespace MusicPlay.Repository.Repositories.FavoritesRepositories
{
    public class MusicasFavRepository
    {
        private enum Procedures
        {
            Sp_InsMusicasFavoritosUsua,
            Sp_DelMusicasFavoritosUsua
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
