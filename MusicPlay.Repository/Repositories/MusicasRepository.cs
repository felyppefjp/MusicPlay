using MusicPlay.Core.Models;
using MusicPlay.Repository.AcessoBanco;

namespace MusicPlay.Repository.Repositories
{
    public class MusicasRepository
    {
        private enum Procedures
        {
            Sp_InsMusicasa,
            Sp_DelMusica 
        }

        public void PostMusica(Musicas musicas)
        {
            using (var cb = new ConexaoBase())
            {
                cb.ExecutaProcedure(Procedures.Sp_InsMusicasa);
                cb.AdicionaParametros("@Nom_Musica", musicas.Nom_Musica);
                cb.AdicionaParametros("@Num_SeqlAlbum", musicas.Num_SeqlAlbum);
                cb.AdicionaParametros("@Url_Video", musicas.Url_Video);
                cb.AdicionaParametros("@Cod_UsuaCad", musicas.Cod_UsuaCad);
                cb.AdicionaParametros("@Dat_Cad", musicas.Dat_Cad);
                cb.AdicionaParametros("@Cod_UsuaAlt", musicas.Cod_UsuaCad);
                cb.ExecuteNonQuery();
            }
        }

        public void DeleteMusica(int i)
        {
            using (var cb = new ConexaoBase())
            {
                cb.ExecutaProcedure(Procedures.Sp_DelMusica);
                cb.ExecuteNonQuery();
            }
        }
    }
}
