using System;
using System.Collections.Generic;
using System.Text;

namespace PortalAdvogado.Models
{
    public class LoginAdvogado
    {
        public string codigo { get; set; }
        public string letra { get; set; }
        public string uf { get; set; }
        public string senha { get; set; }

        public LoginAdvogado(string codigo, string letra, string uf, string senha)
        {
            this.codigo = codigo;
            this.letra = letra;
            this.uf = uf;
            this.senha = senha;
        }
    }
}