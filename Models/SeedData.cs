using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProjMaster.Data;
using System;
using System.Linq;

namespace ProjMaster.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ProjMasterContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ProjMasterContext>>()))
            {
                // Look for any movies.
                if (context.Lanche.Any())
                {
                    return;   // DB has been seeded
                }

                context.Lanche.AddRange(
                    new Lanche
                    {
                        Nome = "Calabresa",
                        Genero = "Pizzas",
                        Preco = 25.99M,
                        ImagemUrl = "https://media-cdn.tripadvisor.com/media/photo-s/18/1a/d5/1e/casteloes.jpg"

                    },

                    new Lanche
                    {
                        Nome = "Esfihas de Carne",
                        Genero = "Esfihas",
                        Preco = 1.99M,
                        ImagemUrl = "https://ceoagro.com.br/wp-content/uploads/2019/06/esfilha-cordeiro_ceoagro.jpg"

                    },

                    new Lanche
                    {
                        Nome = "Coca-Cola",
                        Genero = "Bebidas",
                        Preco = 7.99M,
                        ImagemUrl = "https://www.qgjeitinhocaseiro.com/wp-content/uploads/2019/12/historia-coca-cola.jpg"

                    },

                    new Lanche
                    {
                        Nome = "Beirute",
                        Genero = "Lanches",
                        Preco = 14.99M,
                        ImagemUrl = "https://i.pinimg.com/originals/09/21/65/0921658d1590e4a30d7c5aafa807d7a6.jpg"

                    }
                );
                context.SaveChanges();
            }
        }
    }
}