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
                cb.AdicionaParameteros("@Nom_Musica", musicas.Nom_Musica);
                cb.AdicionaParameteros("@Num_SeqlAlbum", musicas.Num_SeqlAlbum);
                cb.AdicionaParameteros("@Url_Video", musicas.Url_Video);
                cb.AdicionaParameteros("@Cod_UsuaCad", musicas.Cod_UsuaCad);
                cb.AdicionaParameteros("@Dat_Cad", musicas.Dat_Cad);
                cb.AdicionaParameteros("@Cod_UsuaAlt", musicas.Cod_UsuaCad);
                cb.AdicionaParameteros("@Dat_UltAlt", musicas.Dat_Cad);
                cb.AdicionaParameteros("@Num_Temo", musicas.Num_Tempo);
                cb.ExecuteNonQuery();
            }
        }

        public void DeleteMusica(int i)
        {
            using (var cb = new ConexaoBase())
            {
                cb.ExecutaProcedure(Procedures.Sp_DelMusica);
                cb.AdicionaParameteros("@Num_SeqlMusica", i);
                cb.ExecuteNonQuery();
            }
        }
    }
}
