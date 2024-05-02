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
        private readonly IBancoRepository _bancoRepository;

        public BancoService(IBancoRepository bancoRepository, IMapper mapper)
        {
            _bancoRepository = bancoRepository;
            _mapper = mapper;
        }

        // Função para criar um novo banco
        public async Task<Banco> CriaBancoAsync(BancoDTO bancoDTO)
        {
            var banco = _mapper.Map<Banco>(bancoDTO);
            return await _bancoRepository.CriaBancoAsync(banco);
        }

        // Função para atualizar um banco
        public async Task<Banco> AtualizaBancoAsync(BancoDTO bancoDTO)
        {
            var banco = _mapper.Map<Banco>(bancoDTO);
            return await _bancoRepository.AtualizaBancoAsync(banco);
        }

        // Função para obter todos os bancos
        public async Task<List<Banco>> GetAllBancosAsync(string nomeCampo, bool isAcendente = true, int pageNumber = 1, int pageSize = 10)
        {
            return await _bancoRepository.GetAllBancosAsync(nomeCampo, isAcendente, pageNumber, pageSize);
        }

        // Função para obter um banco pelo ID
        public async Task<Banco?> GetBancoByIdAsync(long id)
        {
            return await _bancoRepository.GetBancoByIdAsync(id);
        }
    }
}
