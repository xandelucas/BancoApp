using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoApp.Application.DTOs
{
    public class BoletoDTO
    {
        public int Id { get; set; }
        public string NomeDoPagador { get; set; }
        public string CPF_CNPJDoPagador { get; set; }
        public string NomeDoBeneficiario { get; set; }
        public string CPF_CNPJDoBeneficiario { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataDeVencimento { get; set; }
        public string Observacao { get; set; }
        public int BancoId { get; set; }
    }
}
