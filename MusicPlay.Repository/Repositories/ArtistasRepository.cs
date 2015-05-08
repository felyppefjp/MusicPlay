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
                cb.AdicionaParameteros("@Nom_Artistas", artistas.Nom_Artista);
                cb.AdicionaParameteros("@Dat_IniCarreira", artistas.Dat_IniCarreira);
                cb.AdicionaParameteros("@Num_SeqlGenero", artistas.Num_SeqlGenero);
                cb.AdicionaParameteros("@Cod_UsuaCad", artistas.Cod_UsuaCad);
                cb.AdicionaParameteros("@Dat_Cad", artistas.Dat_Cad);
                cb.AdicionaParameteros("@Cod_UsuaAlt", artistas.Cod_UsuaAlt);
                cb.AdicionaParameteros("@Dat_UltAlt", artistas.Dat_UsuaAlt);
                cb.ExecuteNonQuery();
            }
        }

        public void DeleteArtista(int id)
        {
            using (var cb = new ConexaoBase())
            {
                cb.ExecutaProcedure(Procedures.Sp_DelArtista);
                cb.AdicionaParameteros("@Num_SeqlArtista", id);
                cb.ExecuteNonQuery();
            }
        }
    }
}
