namespace MusicPlay.Core.Models
{
    public class ArtistasFavoritosUsua
    {
        public int Cod_Usua { get; set; }
        public int Num_SeqlArtista { get; set; }

        public Usuarios Usuarios { get; set; }
        public Artistas Artistas { get; set; }

    }
}
