namespace MusicPlay.Core.Models
{
    public class ParticipacaoEspArtistasMusica
    {
        public int Num_SeqlArtista { get; set; }
        public int Num_SeqlMusica { get; set; }

        public Artistas Artistas { get; set; }
        public Musicas Musicas { get; set; }
    }
}
