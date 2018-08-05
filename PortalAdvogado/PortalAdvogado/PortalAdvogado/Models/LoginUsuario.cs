using System;
using System.Collections.Generic;
using System.Text;

namespace PortalAdvogado.Models
{
    class LoginUsuario
    {
        public string usuario { get; set; }

        public string senha { get; set; }

        public LoginUsuario(string usuario, string senha)
        {
            this.usuario = usuario;
            this.senha = senha;
        }
    }
}
