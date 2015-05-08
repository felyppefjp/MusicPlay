using System;

namespace MusicPlay.Core.Models
{
    public class Albuns : BaseManut
    {
        public int Num_SeqlAlbum { get; set; }
        public string Nom_Album { get; set; }
        public int Num_SeqlArtista { get; set; }
        public int Num_SeqlBanda { get; set; }
        public DateTime Dat_Lanc { get; set; }

        public Artistas Artistas { get; set; }
        public Bandas Bandas { get; set; }
    }
}
