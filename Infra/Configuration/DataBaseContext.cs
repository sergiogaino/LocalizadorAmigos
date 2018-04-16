using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Infra.Configuration
{
    public class DataBaseContext : DbContext
    {

        public IConfigurationRoot Configuration { get; set; }

        public DataBaseContext(DbContextOptions<DataBaseContext> option) : base(option)
        {
            Database.EnsureCreated();
        }

        public DbSet<Friend> Friend { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            if (!optionBuilder.IsConfigured)
                optionBuilder.UseSqlServer(ReturnConnectionString());
        }

        public string ReturnConnectionString()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            Configuration = builder.Build();

            return Configuration.GetConnectionString("DefaultConnection");
        }


    }
}
