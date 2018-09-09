using System;
using System.Collections.Generic;
using System.Text;

namespace PortalAdvogado.Models
{
    public class FaseResponse
    {
        public string numProcesso { get; set; }
        public List<DadosFase> listaFases { get; set; }
    }
}
