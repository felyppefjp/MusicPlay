using System;
using System.Collections.Generic;
using MusicPlay.Core.Models;
using MusicPlay.Repository.AcessoBanco; 

namespace MusicPlay.Repository.Repositories.FavoritesRepositories
{
    public class BandasFavRepository
    {
        private readonly List<Bandas> bandas;

        private enum Procedures
        {
            Sp_InsBandasFavoritosUsua,
            Sp_DelBandasFavoritosUsua,
            Sp_SelBandasFavoritasUsua
        }

        public List<Bandas> GetBandasFavoritasUsua(int Cod_Usua)
        { 
            using(var cb = new ConexaoBase())
            {
                cb.ExecutaProcedure(Procedures.Sp_SelBandasFavoritasUsua);
                cb.AdicionaParametros("@Cod_Usua", Cod_Usua);
                var reader = cb.ExecuteReader();
                int i = -1; // Controla os indices da lista de bandas
                while (reader.Read())
                {                 
                    var id = 0;
                    if ((int)reader["id"] != id)
                    {
                        i++;
                        var genero = new GenerosMusicais();
                        genero.Nom_Genero = reader["Genero"].ToString();

                        var artista = new Artistas();
                        artista.Nom_Artista = reader["Artista"].ToString();

                        bandas[i].Num_SeqlBanda = (int)reader["Id"];
                        bandas[i].Nom_Banda = reader["Banda"].ToString();
                        bandas[i].Integrantes.Add(artista);                        
                        id = (int)reader["Id"];
                    }
                    else 
                    {
                        var artista = new Artistas();
                        artista.Nom_Artista = reader["Artista"].ToString();
                        bandas[i].Integrantes.Add(artista);
                    }
                }
                return bandas;
            }
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
