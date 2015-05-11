using System;
using System.Collections.Generic;
using MusicPlay.Core.Models;
using MusicPlay.Repository.AcessoBanco;

namespace MusicPlay.Repository.Repositories.FavoritesRepositories
{
    public class ArtistasFavRepository
    {
        private enum Procedures
        {
            Sp_InsArtistasFavoritosUsua,
            Sp_DelArtistasFavoritosUsua
        }

        public void PostArtistasFavoritosUsua(int Cod_Usua, int Num_SeqlArtista)
        {
            using (var cb = new ConexaoBase())
            {
                cb.ExecutaProcedure(Procedures.Sp_InsArtistasFavoritosUsua);
                cb.AdicionaParametros("@Cod_Usua", Cod_Usua);
                cb.AdicionaParametros("@Num_SeqlArtista", Num_SeqlArtista);
                cb.ExecuteNonQuery();
            }
        }

        public void DeleteArtistasFavoritosUsua(int Cod_Usua, int Num_SeqlArtista)
        {
            using (var cb = new ConexaoBase())
            {
                cb.ExecutaProcedure(Procedures.Sp_DelArtistasFavoritosUsua);
                cb.AdicionaParametros("@Cod_Usua", Cod_Usua);
                cb.AdicionaParametros("@Num_SeqlArtista", Num_SeqlArtista);
                cb.ExecuteNonQuery();
            }
        }

    }
}
