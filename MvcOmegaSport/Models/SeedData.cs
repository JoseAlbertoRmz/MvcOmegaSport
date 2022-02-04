using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcOmegaSport.Data;
using System;
using System.Linq;


namespace MvcOmegaSport.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcOmegaSportContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcOmegaSportContext>>()))
            {
                // Look for any movies.
                if (context.Jersey.Any())         //Si hay algun jersey no se agregan los datos del seed
                {
                    return;   // DB has been seeded
                }

                context.Jersey.AddRange(
                    new Jersey
                    {
                        Nombre = "Jersey Bayern Munich 21/22",
                        Talla = "M",
                        Equipacion = "Local",
                        Marca = "Adidas",
                        Precio = 1599
                    },

                    new Jersey
                    {
                        Nombre = "Jersey Liverpool 21/22",
                        Talla = "M",
                        Equipacion = "Local",
                        Marca = "Nike",
                        Precio = 1599
                    }
                );
                context.SaveChanges();
            }
        }
    }
}



