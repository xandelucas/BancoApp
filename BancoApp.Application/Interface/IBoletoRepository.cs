using BancoApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoApp.Application.Interface
{
    public interface IBoletoRepository
    {
        Task<List<Boleto>> GetAllBoletosAsync(string nomeCampo, bool isAcendente = true, int pageNumber = 1, int pageSize = 10);

        Task<Boleto?> GetBoletoByIdAsync(long id);

        Task<Boleto> AtualizaBoletoAsync(Boleto boleto);

        Task<Boleto> CriaBoletoAsync(Boleto boleto);
    }
}
