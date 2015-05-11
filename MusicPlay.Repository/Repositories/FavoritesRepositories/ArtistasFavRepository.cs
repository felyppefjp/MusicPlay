using System;
using System.Collections.Generic;
using MusicPlay.Core.Models;
using MusicPlay.Repository.AcessoBanco;

namespace MusicPlay.Repository.Repositories.FavoritesRepositories
{
    public class ArtistasFavRepository
    {
        private readonly List<Artistas> artistas;

        private enum Procedures
        {
            Sp_InsArtistasFavoritosUsua,
            Sp_DelArtistasFavoritosUsua,
            Sp_SelArtistasFavoritosUsua
        }

        public List<Artistas> GetArtistasFavoritosUsua(int Cod_Usua)
        {
            using(var cb = new ConexaoBase())
            {
                cb.ExecutaProcedure(Procedures.Sp_SelArtistasFavoritosUsua);
                cb.AdicionaParametros("@Cod_Usua", Cod_Usua);
                var reader = cb.ExecuteReader();
                while (reader.Read())
                {
                    var genero = new GenerosMusicais();
                    genero.Nom_Genero = reader["Genero"].ToString();
                    var artista = new Artistas() { 
                        Num_SeqlArtista = (int)reader["Id"],
                        Nom_Artista = reader["Artista"].ToString(),
                        GenerosMusicais = genero
                    };
                    artistas.Add(artista);
                }
            }
            return artistas;
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
