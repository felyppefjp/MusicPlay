using MusicPlay.Core.Models;
using MusicPlay.Repository.AcessoBanco;

namespace MusicPlay.Repository.Repositories
{
    public class ParticipacaoEspArtistasMusicaRepository
    {
        private enum Procedures
        {
            Sp_InsParticipacaoEspArtistaMusica
        }

        public void PostParticipacaoEspArtistaMusica(ParticipacaoEspArtistasMusica participacaoEspArtistasMusica)
        {
            using (var cb = new ConexaoBase())
            {
                cb.ExecutaProcedure(Procedures.Sp_InsParticipacaoEspArtistaMusica);
                cb.AdicionaParametros("@Num_SeqlArtista", participacaoEspArtistasMusica.Num_SeqlArtista);
                cb.AdicionaParametros("@Num_SeqlMusica", participacaoEspArtistasMusica.Num_SeqlMusica);
                cb.ExecuteNonQuery();
            }
        }
    }
}
