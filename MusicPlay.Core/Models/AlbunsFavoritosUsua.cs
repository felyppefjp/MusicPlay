using System.Runtime;
using System.Runtime.ConstrainedExecution;

namespace MusicPlay.Core.Models
{
    public class AlbunsFavoritosUsua
    {
        public int Cod_Usua { get; set; }
        public int Num_SeqlAlbum { get; set; }

        public Usuarios Usuarios { get; set; }
        public Albuns Albuns { get; set; }
    }
}
