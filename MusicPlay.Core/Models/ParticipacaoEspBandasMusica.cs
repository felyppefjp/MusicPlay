namespace MusicPlay.Core.Models
{
    public class ParticipacaoEspBandasMusica
    {
        public int Num_SeqlBanda { get; set; }
        public int Num_SeqlMusica { get; set; }

        public Bandas Bandas { get; set; }
        public Musicas Musicas { get; set; }
    }
}
