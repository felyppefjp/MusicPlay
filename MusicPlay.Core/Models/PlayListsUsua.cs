namespace MusicPlay.Core.Models
{
    public class PlayListsUsua
    {
        public int Num_SeqlPlaylist { get; set; }
        public string Nom_Playlist { get; set; }
        public int Cod_Usua { get; set; }
        public MusicasPlaylist Musicas { get; set; }

        public Usuarios Usuarios { get; set; }

    }
}
