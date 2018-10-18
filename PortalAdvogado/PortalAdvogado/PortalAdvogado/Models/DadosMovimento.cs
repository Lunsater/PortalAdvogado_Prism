using System;
using System.Collections.Generic;
using System.Text;

namespace PortalAdvogado.Models
{
    public class DadosMovimento
    {
        public DateTime dataMovimento { get; set; }
        public String txtMovimento { get; set; }
        public String txtIntegra { get; set; }
        public String flgSigiloso { get; set; }
        public Boolean temAnexo { get; set; }
    }
}
