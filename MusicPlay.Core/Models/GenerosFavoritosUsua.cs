namespace MusicPlay.Core.Models
{
    public class GenerosFavoritosUsua
    {
        public int Cod_Usua { get; set; }
        public int Num_SeqlGenero { get; set; }

        public Usuarios Usuarios { get; set; }
        public GenerosMusicais GenerosMusicais { get; set; }
    }
}
