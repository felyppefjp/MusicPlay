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
    class PlayListUsuaRepositories
    {
        private List<PlayListsUsua> playLists; 
        private enum Procedures
        {
            Sp_DelPlaylist,
            SP_InserPlayList,
            Sp_SelMusicasPlayList
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
    }
}
