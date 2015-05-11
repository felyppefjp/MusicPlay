using MusicPlay.Core.Models;
using MusicPlay.Repository.AcessoBanco;

namespace MusicPlay.Repository.Repositories
{
    public class IntegrantesBandaRepository
    {
        private enum Procedures
        {
            Sp_InsIntegranteBanda,
            Sp_DelIntegranteBanda
        }

        public void PostIntegranteBanda(IntegrantesBanda integrantesBanda)
        {
            using (var cb = new ConexaoBase())
            {
                cb.ExecutaProcedure(Procedures.Sp_InsIntegranteBanda);
                cb.AdicionaParametros("@Num_SeqlArtista", integrantesBanda.Num_SeqlArtista);
                cb.AdicionaParametros("@Dat_Ini", integrantesBanda.Dat_Ini);
                cb.AdicionaParametros("@Dat_Fim", integrantesBanda.Dat_Fim);
                cb.ExecuteNonQuery();
            }
        }

        public void DeleteIntegranteBanda(int id)
        {
            using (var cb = new ConexaoBase())
            {
                cb.ExecutaProcedure(Procedures.Sp_DelIntegranteBanda);
                cb.AdicionaParametros("@Num_SeqlBanda", id);
                cb.ExecuteNonQuery();
            }
        }
    }
}
