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
                cb.AdicionaParameteros("@Num_SeqlArtista", integrantesBanda.Num_SeqlArtista);
                cb.AdicionaParameteros("@Dat_Ini", integrantesBanda.Dat_Ini);
                cb.AdicionaParameteros("@Dat_Fim", integrantesBanda.Dat_Fim);
                cb.ExecuteNonQuery();
            }
        }

        public void DeleteIntegranteBanda(int id)
        {
            using (var cb = new ConexaoBase())
            {
                cb.ExecutaProcedure(Procedures.Sp_DelIntegranteBanda);
                cb.AdicionaParameteros("@Num_SeqlBanda", id);
                cb.ExecuteNonQuery();
            }
        }
    }
}
