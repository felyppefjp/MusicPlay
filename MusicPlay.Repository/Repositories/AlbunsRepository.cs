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
                cb.AdicionaParametros("@Nom_Album", Procedures.Sp_InsAlbum);
                cb.AdicionaParametros("@Num_SeqlArtista", albuns.Num_SeqlArtista);
                cb.AdicionaParametros("@Num_SeqlBanda", albuns.Num_SeqlBanda);
                cb.AdicionaParametros("@Dat_Lanc", albuns.Dat_Lanc);
                cb.AdicionaParametros("@Cod_UsuaCad", albuns.Cod_UsuaCad);
                cb.AdicionaParametros("@Dat_Cad", albuns.Dat_Cad);
                cb.AdicionaParametros("@Cod_UsuaAlt", albuns.Cod_UsuaAlt);
                cb.AdicionaParametros("@Dat_UltAlt", albuns.Dat_UsuaAlt);
                cb.ExecuteNonQuery();
            }
        }

        public void DeleteAlbum(int id)
        {
            using (var cb = new ConexaoBase())
            {
                cb.ExecutaProcedure(Procedures.Sp_DelAlbum);
                cb.AdicionaParametros("Num_SeqlAlbum", id);
                cb.ExecuteNonQuery();
            }
        }
    }
}
