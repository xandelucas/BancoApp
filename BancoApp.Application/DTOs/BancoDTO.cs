using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoApp.Application.DTOs
{
    public class BancoDTO
    {
        public int Id { get; set; }
        public string NomeDoBanco { get; set; }
        public string CodigoDoBanco { get; set; }
        public decimal PercentualDeJuros { get; set; }
    }
}
