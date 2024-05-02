using BancoApp.Application.Interface;
using BancoApp.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoApp.Infrastructure.Data.Repositories
{
    public class BoletoRepository : IBoletoRepository
    {
        private readonly DBContext _dbContext;
        public BoletoRepository(DBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Boleto> AtualizaBoletoAsync(Boleto boleto)
        {
            _dbContext.Entry(boleto).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return boleto;
        }

        public async Task<Boleto> CriaBoletoAsync(Boleto boleto)
        {
            await _dbContext.Boletos.AddAsync(boleto);
            await _dbContext.SaveChangesAsync();
            return boleto;
        }

        public async Task<List<Boleto>> GetAllBoletosAsync(string nomeCampo, bool isAcendente = true, int pageNumber = 1, int pageSize = 10)
        {
            int offset = (pageNumber - 1) * pageSize;
            switch (nomeCampo.ToLower())
            {
                case "id":
                    return isAcendente ? await _dbContext.Boletos.OrderBy(x => x.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync() :
                        await _dbContext.Boletos.OrderByDescending(x => x.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
                case "BancoId":
                    return isAcendente ? await _dbContext.Boletos.OrderBy(x => x.BancoId).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync() :
                        await _dbContext.Boletos.OrderByDescending(x => x.BancoId).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
                default:
                    throw new ArgumentException("Campo para ordenação inválido");
            }
        }


        public async Task<Boleto?> GetBoletoByIdAsync(long id)
        {
            return await _dbContext.Boletos.FindAsync(id);
        }
    }

}