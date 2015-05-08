using System;

namespace MusicPlay.Core.Models
{
    public class Musicas : BaseManut
    {
        public int Num_SeqlMusica { get; set; }
        public string Nom_Musica { get; set; }
        public int Num_SeqlAlbum { get; set; }
        public string Url_Video { get; set; }
        public TimeSpan Num_Tempo { get; set; }

        public Albuns Albuns { get; set; }
    }
}
