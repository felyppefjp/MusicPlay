using MusicPlay.Core.Models;
using MusicPlay.Repository.AcessoBanco;

namespace MusicPlay.Repository.Repositories
{
    public class ParticipacaoEspBandasMusicaRepository
    {
        private enum Procedures
        {
            Sp_InsParticipacaoEspBandaMusica
        }

        public void PostParticipacaoEspBandaMusica(ParticipacaoEspBandasMusica participacaoEspBandasMusica)
        {
            using (var cb = new ConexaoBase())
            {
                cb.ExecutaProcedure(Procedures.Sp_InsParticipacaoEspBandaMusica);
                cb.AdicionaParametros("@Num_SeqlBanda", participacaoEspBandasMusica.Num_SeqlBanda);
                cb.AdicionaParametros("@Num_SeqlMusica", participacaoEspBandasMusica.Num_SeqlMusica);
                cb.ExecuteNonQuery();
            }
        }

    }
}
