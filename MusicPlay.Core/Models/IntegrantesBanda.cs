using System;

namespace MusicPlay.Core.Models
{
    public class IntegrantesBanda : BaseManut
    {
        public int Num_SeqlBanda { get; set; }
        public int Num_SeqlArtista { get; set; }
        public DateTime Dat_Ini { get; set; }
        public DateTime Dat_Fim { get; set; }

        public Bandas Bandas { get; set; }
        public Artistas Artistas { get; set; }
    }
}
