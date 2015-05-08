namespace MusicPlay.Core.Models
{
    public class MusicasFavoritasUsua
    {
        public int Cod_Usua { get; set; }
        public int Num_SeqlMusica { get; set; }

        public Usuarios Usuarios { get; set; }
        public Musicas Musicas { get; set; }
    }
}
