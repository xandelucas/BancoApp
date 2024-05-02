using BancoApp.Domain;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BancoApp.Application.Interface;
using BancoApp.Application.DTOs;

namespace BancoApp.Application.Services
{
    public class BoletoService : IBoletoService
    {
        private readonly IMapper _mapper;
        private readonly IBoletoRepository _boletoRepository;

        public BoletoService(IBoletoRepository boletoRepository, IMapper mapper)
        {
            _boletoRepository = boletoRepository;
            _mapper = mapper;
        }

        // Função para criar um novo boleto
        public async Task<Boleto> CriaBoletoAsync(BoletoDTO boletoDTO)
        {
            var boleto = _mapper.Map<Boleto>(boletoDTO);
            return await _boletoRepository.CriaBoletoAsync(boleto);
        }

        // Função para ler um boleto pelo ID
        public async Task<Boleto> GetBoletoByIdAsync(long id)
        {
            return await _boletoRepository.GetBoletoByIdAsync(id);
        }

        // Função para calcular juros
        public decimal CalcularJuros(decimal valor, decimal percentualDeJuros)
        {
            return valor * (percentualDeJuros / 100);
        }

        // Função para obter todos os boletos paginadamente
        public async Task<List<Boleto>> GetAllBoletosAsync(string nomeCampo, bool isAcendente = true, int pageNumber = 1, int pageSize = 10)
        {
            return await _boletoRepository.GetAllBoletosAsync(nomeCampo, isAcendente, pageNumber, pageSize);
        }

        // Função para atualizar um boleto
        public async Task<Boleto> AtualizaBoletoAsync(BoletoDTO boletoDTO)
        {
            var boleto = _mapper.Map<Boleto>(boletoDTO);
            return await _boletoRepository.AtualizaBoletoAsync(boleto);
        }
    }
}
