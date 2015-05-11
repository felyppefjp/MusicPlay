using System;
using System.Collections.Generic;
using MusicPlay.Core.Models;
using MusicPlay.Repository.AcessoBanco;

namespace MusicPlay.Repository.Repositories.FavoriteRepositories
{
    public class AlbunsFavRepository
    {
        private List<Albuns> albuns = new List<Albuns>();

        private enum Procedures
        {
            Sp_InsAlbunsFavoritosUsua,
            Sp_DelAlbunsFavoritosUsua,
            Sp_SelAlbunsFavoritosArtistasUsua,
            Sp_SelAlbunsFavoritosBandasUsua
        }

        

        public void PostAlbunsFavoritosUsua(int Cod_Usua, int Num_SeqlAlbum)
        {
            using (var cb = new ConexaoBase())
            {
                cb.ExecutaProcedure(Procedures.Sp_InsAlbunsFavoritosUsua);
                cb.AdicionaParametros("@Cod_Usua", Cod_Usua);
                cb.AdicionaParametros("@Num_SeqlAlbum", Num_SeqlAlbum);
                cb.ExecuteNonQuery();
            }
        }

        public void DeleteAlbunsFavoritosUsua(int Cod_Usua, int Num_SeqlAlbum)
        {
            using (var cb = new ConexaoBase())
            {
                cb.ExecutaProcedure(Procedures.Sp_DelAlbunsFavoritosUsua);
                cb.AdicionaParametros("@Cod_Usua", Cod_Usua);
                cb.AdicionaParametros("@Num_SeqlAlbum", Num_SeqlAlbum);
                cb.ExecuteNonQuery();
            }
        }


        private List<Albuns> GetListaAlbunsBandas(int Cod_Usua)
        {
            using (var cb = new ConexaoBase())
            {
                cb.ExecutaProcedure(Procedures.Sp_SelAlbunsFavoritosBandasUsua);
                cb.AdicionaParametros("@Cod_Usua", Cod_Usua);
                var reader = cb.ExecuteReader();
                while (reader.Read())
                {
                    var genero = new GenerosMusicais();
                    genero.Nom_Genero = reader["Genero"].ToString();

                    var banda = new Bandas();
                    banda.Nom_Banda = reader["Banda"].ToString();
                    banda.GenerosMusicais = genero;

                    var album = new Albuns()
                    {
                        Num_SeqlAlbum = (int)reader["Id"],
                        Nom_Album = reader["Album"].ToString(),
                        Dat_Lanc = Convert.ToDateTime(reader["Lancamento"]),
                        Bandas = banda
                    };

                    albuns.Add(album);
                }

            }
            return albuns;

        }

        private List<Albuns> GetListaAlbunsArtistas(int Cod_Usua)
        {
            using (var cb = new ConexaoBase())
            {
                cb.ExecutaProcedure(Procedures.Sp_SelAlbunsFavoritosArtistasUsua);
                cb.AdicionaParametros("@Cod_Usua", Cod_Usua);
                var reader = cb.ExecuteReader();
                while (reader.Read())
                {
                    var genero = new GenerosMusicais();
                    genero.Nom_Genero = reader["Genero"].ToString();

                    var artista = new Artistas();
                    artista.Nom_Artista = reader["Artista"].ToString();
                    artista.GenerosMusicais = genero;

                    var album = new Albuns()
                    {
                        Num_SeqlAlbum = (int)reader["Id"],
                        Nom_Album = reader["Album"].ToString(),
                        Dat_Lanc = Convert.ToDateTime(reader["Lancamento"]),
                        Artistas = artista
                    };
                    albuns.Add(album);
                }

            }
            return albuns;
        }

        public List<Albuns> GetAlbunsFavoritosBandasUsua(int Cod_Usua)
        {
            GetListaAlbunsBandas(Cod_Usua);
            GetListaAlbunsArtistas(Cod_Usua);
            return albuns;

        }

    }
}
