using System;
using System.Collections.Generic;
using MusicPlay.Core.Models;
using MusicPlay.Repository.AcessoBanco; 

namespace MusicPlay.Repository.Repositories.FavoritesRepositories
{
    public class BandasFavRepository
    {
        private enum Procedures
        {
            Sp_InsBandasFavoritosUsua,
            Sp_DelBandasFavoritosUsua
        }

        public void PostBandasFavoritosUsua(int Cod_Usua, int Num_SeqlBandas)
        {
            using (var cb = new ConexaoBase())
            {
                cb.ExecutaProcedure(Procedures.Sp_InsBandasFavoritosUsua);
                cb.AdicionaParametros("@Cod_Usua", Cod_Usua);
                cb.AdicionaParametros("@Num_SeqlBandas", Num_SeqlBandas);
                cb.ExecuteNonQuery();
            }
        }

        public void DeleteBandasFavoritosUsua(int Cod_Usua, int Num_SeqlBandas)
        {
            using (var cb = new ConexaoBase())
            {
                cb.ExecutaProcedure(Procedures.Sp_DelBandasFavoritosUsua);
                cb.AdicionaParametros("@Cod_Usua", Cod_Usua);
                cb.AdicionaParametros("@Num_SeqlBandas", Num_SeqlBandas);
                cb.ExecuteNonQuery();
            }
        }
    }
}
