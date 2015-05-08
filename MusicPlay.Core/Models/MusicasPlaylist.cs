namespace MusicPlay.Core.Models
{
    public class MusicasPlaylist
    {
        public int Num_SeqlPlaylist { get; set; }
        public int Num_SeqlMusica { get; set; }

        public PlayListsUsua PlayListsUsua { get; set; }
        public Musicas Musicas { get; set; }
    }
}
