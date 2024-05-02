using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoApp.Domain
{
    public class Banco
    {
        public int Id { get; set; }
        public string NomeDoBanco { get; set; }
        public string CodigoDoBanco { get; set; }
        public decimal PercentualDeJuros { get; set; }

        public override string ToString()
        {
            return $"ID: {Id}, Nome: {NomeDoBanco}, Código: {CodigoDoBanco}, Juros: {PercentualDeJuros}%";
        }
    }
}
