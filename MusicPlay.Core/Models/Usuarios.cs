using System;

namespace MusicPlay.Core.Models
{
    public class Usuarios : BaseManut
    {
        public int Cod_Usua { get; set; }
        public string Nom_Usua { get; set; }
        public int Num_SeqlTipo { get; set; }
        public string Nom_Email { get; set; }
        public string Nom_Senha { get; set; }

        public TiposUsuario TiposUsuario { get; set; }
        
    }
}
