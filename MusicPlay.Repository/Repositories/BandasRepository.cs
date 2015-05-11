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
                cb.AdicionaParametros("@Nom_Banda", bandas.Nom_Banda);
                cb.AdicionaParametros("@Num_SeqlGenero", bandas.Num_SeqlGenero);
                cb.AdicionaParametros("@Data_IniFormacao", bandas.Dat_IniFormacao);
                cb.AdicionaParametros("@Cod_UsuaCad", bandas.Cod_UsuaCad);
                cb.AdicionaParametros("@Dat_Cad", bandas.Dat_Cad);
                cb.AdicionaParametros("@Cod_UsuaAlt", bandas.Cod_UsuaAlt);
                cb.AdicionaParametros("@Dat_UltAlt", bandas.Dat_UsuaAlt);
                cb.ExecuteNonQuery();
            }
        }

        public void DeleteBanda(int id)
        {
            using (var cb = new ConexaoBase())
            {
                cb.ExecutaProcedure(Procedures.Sp_DelBandas);
                cb.AdicionaParametros("@Num_SeqlBanda", id);
                cb.ExecuteNonQuery();
            }
        }
    }
}
