using AutoMapper;
using BancoApp.Application.DTOs;
using BancoApp.Application.Interface;
using BancoApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoApp.Application.Services
{
    public class BancoService : IBancoService
    {
        private readonly IMapper _mapper;
        private readonly IBancoRepository _BancoRepository;
        public BancoService(IBancoRepository BancoRepository, IMapper mapper)
        {
            _BancoRepository = BancoRepository;
            _mapper = mapper;
        }
        public Task<Banco> AtualizaBancoAsync(BancoDTO banco)
        {
            throw new NotImplementedException();
        }

        public Task<Banco> CriaBancoAsync(BancoDTO banco)
        {
            throw new NotImplementedException();
        }

        public Task<List<Banco>> GetAllBancosAsync(string nomeCampo, bool isAcendente = true, int pageNumber = 1, int pageSize = 10)
        {
            throw new NotImplementedException();
        }

        public Task<Banco?> GetBancoByIdAsync(long id)
        {
            throw new NotImplementedException();
        }
    }
}
