using System;
using System.Collections.Generic;
using System.Text;

namespace PortalAdvogado.Models
{
    public class MovimentoResponse
    {
        public string numProcesso { get; set; }
        public List<DadosMovimento> listaMovimentos { get; set; }
    }
}
