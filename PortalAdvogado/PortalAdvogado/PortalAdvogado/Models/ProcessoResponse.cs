using System;
using System.Collections.Generic;
using System.Text;

namespace PortalAdvogado.Models
{
    public class ProcessoResponse
    {
        public DateTime dataDistribuicao { get; set; }
        public string numProcesso { get; set; }
        public string numUnico { get; set; }
        public string assunto { get; set; }
        public string competencia { get; set; }
        public string ultimaFase { get; set; }
        public int qtdMovimento { get; set; }
        public int qtdFases { get; set; }
        public int qtdDecisoes { get; set; }
        public int qtdPartes { get; set; }
    }
}
