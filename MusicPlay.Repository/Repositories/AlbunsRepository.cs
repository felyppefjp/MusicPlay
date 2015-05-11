using MusicPlay.Core.Models;
using MusicPlay.Repository.AcessoBanco;

namespace MusicPlay.Repository.Repositories
{
    public class AlbunsRepository
    {
        private enum Procedures
        {
            Sp_InsAlbum,
            Sp_DelAlbum
        }

        public void PostAlbum(Albuns albuns)
        {
            using (var cb = new ConexaoBase())
            {
                cb.ExecutaProcedure(Procedures.Sp_InsAlbum);
                cb.AdicionaParameteros("@Nom_Album", Procedures.Sp_InsAlbum);
                cb.AdicionaParameteros("@Num_SeqlArtista", albuns.Num_SeqlArtista);
                cb.AdicionaParameteros("@Num_SeqlBanda", albuns.Num_SeqlBanda);
                cb.AdicionaParameteros("@Dat_Lanc", albuns.Dat_Lanc);
                cb.AdicionaParameteros("@Cod_UsuaCad", albuns.Cod_UsuaCad);
                cb.AdicionaParameteros("@Dat_Cad", albuns.Dat_Cad);
                cb.AdicionaParameteros("@Cod_UsuaAlt", albuns.Cod_UsuaAlt);
                cb.AdicionaParameteros("@Dat_UltAlt", albuns.Dat_UsuaAlt);
                cb.ExecuteNonQuery();
            }
        }

        public void DeleteAlbum(int id)
        {
            using (var cb = new ConexaoBase())
            {
                cb.ExecutaProcedure(Procedures.Sp_DelAlbum);
                cb.AdicionaParameteros("Num_SeqlAlbum", id);
                cb.ExecuteNonQuery();
            }
        }
    }
}
