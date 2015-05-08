using System;

namespace MusicPlay.Core.Models
{
    public class Artistas : BaseManut
    {
        public int Num_SeqlArtista { get; set; }
        public string Nom_Artista { get; set; }
        public DateTime Dat_IniCarreira { get; set; }
        public int Num_SeqlGenero { get; set; }

        public GenerosMusicais GenerosMusicais { get; set; }
    }
}
