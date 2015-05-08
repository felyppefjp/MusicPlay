using System;

namespace MusicPlay.Core.Models
{
    public class Bandas : BaseManut
    {
        public int Num_SeqlBanda { get; set; }
        public string Nom_Banda { get; set; }
        public int Num_SeqlGenero { get; set; }
        public DateTime Dat_IniFormacao { get; set; }

        public GenerosMusicais GenerosMusicais{ get; set; }
    }
}
