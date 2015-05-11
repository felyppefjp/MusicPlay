using System;
using System.Collections.Generic;
using MusicPlay.Core.Models;
using MusicPlay.Repository.AcessoBanco; 

namespace MusicPlay.Repository.Repositories.FavoritesRepositories
{
    public class GenerosFavRepository
    {
        private enum Procedures
        {
            Sp_InsGenerosFavoritosUsua,
            Sp_DelGenerosFavoritosUsua
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
