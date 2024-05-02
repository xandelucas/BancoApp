using BancoApp.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace BancoApp.Infrastructure.Data
{
    public class DBContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public DBContext(){}
        public DBContext(DbContextOptions<DBContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }


        public DbSet<Boleto> Boletos { get; set; }
        public DbSet<Banco> Bancos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("host=localhost;port=5432;Database=BancoLima;Username=AlexandreLima;password=12345678");
        }
    }
}
