using BancoApp.Application.DTOs;
using BancoApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoApp.Application.Interface
{
    public interface IBancoService
    {
        Task<List<Banco>> GetAllBancosAsync(string nomeCampo, bool isAcendente = true, int pageNumber = 1, int pageSize = 10);

        Task<Banco?> GetBancoByIdAsync(long id);

        Task<Banco> AtualizaBancoAsync(BancoDTO banco);

        Task<Banco> CriaBancoAsync(BancoDTO banco);
    }
}
