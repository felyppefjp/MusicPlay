using System;

namespace MusicPlay.Core.Models
{
    public class BaseManut
    {
        public int Cod_UsuaCad { get; set; }
        public DateTime Dat_Cad { get; set; }
        public int Cod_UsuaAlt { get; set; }
        public DateTime Dat_UsuaAlt { get; set; }

        public Usuarios UsuariosCadastro { get; set; }
        public Usuarios UsuariosAlteracao { get; set; }
    }
}
