using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicPlay.Core.Models;
using MusicPlay.Repository.AcessoBanco;

namespace MusicPlay.Repository.Repositories.PlaylistRepositories
{
    internal class PlayListUsuaRepositories
    {
        private List<PlayListsUsua> playLists;

        private enum Procedures
        {
            Sp_DelPlaylist,
            SP_InserPlayList,
            Sp_SelMusicasPlayList,
            Sp_InserMusicasPlayList
        }

        public List<PlayListsUsua> GetPlayListsUsua(int Cod_Usua)
        {
            using (var cb = new ConexaoBase())
            {
                cb.ExecutaProcedure(Procedures.Sp_SelMusicasPlayList);
                cb.AdicionaParametros("@Cod_Usua", Cod_Usua);
                var reader = cb.ExecuteReader();
                while (reader.Read())
                {
                    var musicasPlaylist = new MusicasPlaylist();
                    musicasPlaylist.Num_SeqlMusica = (int) reader["musica"];
                    var playlist = new PlayListsUsua();
                    playlist.Num_SeqlPlaylist = (int) reader["id"];
                    playlist.Nom_Playlist = reader["playlist"].ToString();
                    playlist.Musicas = musicasPlaylist;
                    playLists.Add(playlist);
                }
            }
            return playLists;
        }

        public void PostPlayListaUsua(int Cod_Usua, string Nom_Playlist)
        {
            using (var cb = new ConexaoBase())
            {
                cb.ExecutaProcedure(Procedures.SP_InserPlayList);
                cb.AdicionaParametros("@Cod_Usua", Cod_Usua);
                cb.AdicionaParametros("@Nom_Playlist", Nom_Playlist);
                cb.ExecuteNonQuery();
            }

        }

        public void PostMusicasPlayList(int Num_SeqlPlaylist, int Num_SeqlMusica)
        {
            using (var cb = new ConexaoBase())
            {
                cb.ExecutaProcedure(Procedures.Sp_InserMusicasPlayList);
                cb.AdicionaParametros("@Num_SeqlPlaylist", Num_SeqlPlaylist);
                cb.AdicionaParametros("@Num_SeqlMusica", Num_SeqlMusica);
                cb.ExecuteNonQuery();

            }
        }

        public void DeletarPlayList(int Num_SeqlPlaylist, int Cod_Usua)
        {
            using (var cb = new ConexaoBase())
            {
                cb.ExecutaProcedure(Procedures.Sp_DelPlaylist);
                cb.AdicionaParametros("@Num_SeqlPlaylist", Num_SeqlPlaylist);
                cb.AdicionaParametros("@Cod_usa", Cod_Usua);
                cb.ExecuteNonQuery();
            }
        }
    }
}

