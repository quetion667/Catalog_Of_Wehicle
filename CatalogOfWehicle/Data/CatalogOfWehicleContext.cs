using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CatalogOfWehicle.Models;

namespace CatalogOfWehicle.Data
{

    //определяем здесь Контекст и набор сущностей DbSet
    public class CatalogOfWehicleContext : DbContext
    {
        public CatalogOfWehicleContext (DbContextOptions<CatalogOfWehicleContext> options)
            : base(options)
        {
        }

        // создаем набор сущностей
        public DbSet<CatalogOfWehicle.Models.Wehicle> Wehicle { get; set; }
    }
}
