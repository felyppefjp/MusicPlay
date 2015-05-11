using MusicPlay.Core.Models;
using MusicPlay.Repository.AcessoBanco;

namespace MusicPlay.Repository.Repositories
{
    public class ArtistasRepository
    {
        private enum Procedures
        {
            Sp_InsArtista,
            Sp_DelArtista
        }

        public void PostArtista(Artistas artistas)
        {
            using (var cb = new ConexaoBase())
            {
                cb.ExecutaProcedure(Procedures.Sp_InsArtista);
                cb.AdicionaParametros("@Nom_Artistas", artistas.Nom_Artista);
                cb.AdicionaParametros("@Dat_IniCarreira", artistas.Dat_IniCarreira);
                cb.AdicionaParametros("@Num_SeqlGenero", artistas.Num_SeqlGenero);
                cb.AdicionaParametros("@Cod_UsuaCad", artistas.Cod_UsuaCad);
                cb.AdicionaParametros("@Dat_Cad", artistas.Dat_Cad);
                cb.AdicionaParametros("@Cod_UsuaAlt", artistas.Cod_UsuaAlt);
                cb.AdicionaParametros("@Dat_UltAlt", artistas.Dat_UsuaAlt);
                cb.ExecuteNonQuery();
            }
        }

        public void DeleteArtista(int id)
        {
            using (var cb = new ConexaoBase())
            {
                cb.ExecutaProcedure(Procedures.Sp_DelArtista);
                cb.AdicionaParametros("@Num_SeqlArtista", id);
                cb.ExecuteNonQuery();
            }
        }
    }
}
