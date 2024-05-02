using System.ComponentModel.DataAnnotations;

namespace BancoApp.Domain
{
    public class Boleto
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Nome do Pagador é obrigatório.")]
        public string NomeDoPagador { get; set; }
        [Required(ErrorMessage = "CPF/CNPJ do Pagador é obrigatório.")]
        public string CPF_CNPJDoPagador { get; set; }
        [Required(ErrorMessage = "Nome do Beneficiário é obrigatório.")]
        public string NomeDoBeneficiario { get; set; }
        [Required(ErrorMessage = "CPF/CNPJ do Beneficiário é obrigatório.")]
        public string CPF_CNPJDoBeneficiario { get; set; }
        [Required(ErrorMessage = "Valor é obrigatório.")]
        public decimal Valor { get; set; }
        [Required(ErrorMessage = "Data de Vencimento é obrigatório.")]
        public DateTime DataDeVencimento { get; set; }
        public string Observacao { get; set; }
        [Required(ErrorMessage = "Banco é obrigatório.")]
        public int BancoId { get; set; }
        public Banco Banco { get; set; }

        public override string ToString()
        {
            return $"ID: {Id}, Pagador: {NomeDoPagador}, Beneficiário: {NomeDoBeneficiario}, Valor: {Valor}, Vencimento: {DataDeVencimento.ToShortDateString()}, Banco: {Banco?.NomeDoBanco}";
        }
    }
}
