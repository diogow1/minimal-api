using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MinimalAPI.Dominio.Entidades;

namespace MinimalAPI.Infraestrutura.DB
{

    public class DBContexto : DbContext
    {
        private readonly IConfiguration _configAppSettings;
        public DBContexto(IConfiguration configAppSettings)
        {
            _configAppSettings = configAppSettings;
        }

        public DbSet<Administrador> Administradores {get; set;} = default!;
        public DbSet<Veiculo> Veiculos {get; set;} = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrador>().HasData(
                new Administrador {
                    Id = 1,
                    Email = "adm1@teste.com",
                    Senha = "123456",
                    Perfil = "Adm"
                }
            );
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
                {
                    var stringConexao = _configAppSettings.GetConnectionString("MySql");
                    if(!string.IsNullOrEmpty(stringConexao))
                    {
                        optionsBuilder.UseMySql(
                            stringConexao, 
                            ServerVersion.AutoDetect(stringConexao)
                        );
                    }
                }



        }
    }

}