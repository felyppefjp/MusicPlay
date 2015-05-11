using MusicPlay.Core.Models;
using MusicPlay.Repository.AcessoBanco;

namespace MusicPlay.Repository.Repositories
{
    public class BandasRepository
    {
        private enum Procedures
        {
            Sp_InsBandas,
            Sp_DelBandas
        }

        public void PostBanda(Bandas bandas)
        {
            using (var cb = new ConexaoBase())
            {
                cb.ExecutaProcedure(Procedures.Sp_InsBandas);
                cb.AdicionaParameteros("@Nom_Banda", bandas.Nom_Banda);
                cb.AdicionaParameteros("@Num_SeqlGenero", bandas.Num_SeqlGenero);
                cb.AdicionaParameteros("@Data_IniFormacao", bandas.Dat_IniFormacao);
                cb.AdicionaParameteros("@Cod_UsuaCad", bandas.Cod_UsuaCad);
                cb.AdicionaParameteros("@Dat_Cad", bandas.Dat_Cad);
                cb.AdicionaParameteros("@Cod_UsuaAlt", bandas.Cod_UsuaAlt);
                cb.AdicionaParameteros("@Dat_UltAlt", bandas.Dat_UsuaAlt);
                cb.ExecuteNonQuery();
            }
        }

        public void DeleteBanda(int id)
        {
            using (var cb = new ConexaoBase())
            {
                cb.ExecutaProcedure(Procedures.Sp_DelBandas);
                cb.AdicionaParameteros("@Num_SeqlBanda", id);
                cb.ExecuteNonQuery();
            }
        }
    }
}
