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
    public class BancoRepository : IBancoRepository
    {
        private readonly DBContext _dbContext;

        public BancoRepository(DBContext dbContext) 
        {
            _dbContext = dbContext;
        }
        public async Task<Banco> AtualizaBancoAsync(Banco banco)
        {
            _dbContext.Entry(banco).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return banco;
        }

        public async Task<Banco> CriaBancoAsync(Banco banco)
        {
            _dbContext.Bancos.Add(banco);
            await _dbContext.SaveChangesAsync();
            return banco;
        }

        public async Task<List<Banco>> GetAllBancosAsync(string nomeCampo, bool isAcendente = true, int pageNumber = 1, int pageSize = 10)
        {
            int offset = (pageNumber - 1) * pageSize;
            switch (nomeCampo.ToLower())
            {
                case "id":
                    return isAcendente ? await _dbContext.Bancos.OrderBy(x => x.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync() :
                        await _dbContext.Bancos.OrderByDescending(x => x.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
                case "nome":
                    return isAcendente ? await _dbContext.Bancos.OrderBy(x => x.NomeDoBanco).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync() :
                        await _dbContext.Bancos.OrderByDescending(x => x.NomeDoBanco).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
                default:
                    throw new ArgumentException("Campo para ordenação inválido");
            }
        }

        public async Task<Banco?> GetBancoByIdAsync(long id)
        {
            return await _dbContext.Bancos.FindAsync(id);
        }
    }
}
