namespace MusicPlay.Core.Models
{
    public class BandasFavoritasUsua
    {
        public int Cod_Usua { get; set; }
        public int Num_SeqlBanda { get; set; }

        public Usuarios Usuarios { get; set; }
        public Bandas Bandas { get; set; }
    }
}
