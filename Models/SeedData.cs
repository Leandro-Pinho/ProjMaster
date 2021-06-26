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

                    },

                    new Lanche
                    {
                        Nome = "Pepsi",
                        Genero = "Bebidas",
                        Preco = 5.99M,
                        ImagemUrl = "https://images.unsplash.com/photo-1554283180-2eb141938ee9?ixid=MnwxMjA3fDB8MHxzZWFyY2h8MTR8fHNvZGF8ZW58MHx8MHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=500&q=60"

                    },

                    new Lanche
                    {
                        Nome = "Calamussa",
                        Genero = "Pizzas",
                        Preco = 32.99M,
                        ImagemUrl = "https://images.unsplash.com/photo-1534308983496-4fabb1a015ee?ixid=MnwxMjA3fDB8MHxzZWFyY2h8MTl8fHBpenphfGVufDB8fDB8fA%3D%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=500&q=60"

                    },
                     
                    new Lanche
                    {
                        Nome = "Hamburgue",
                        Genero = "Lanche",
                        Preco = 17.99M,
                        ImagemUrl = "https://images.unsplash.com/photo-1586816001966-79b736744398?ixid=MnwxMjA3fDB8MHxzZWFyY2h8MXx8bGFuY2hlfGVufDB8fDB8fA%3D%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=500&q=60"

                    },

                    new Lanche
                    {
                        Nome = "Hamburgue duplo",
                        Genero = "Lanche",
                        Preco = 23.49M,
                        ImagemUrl = "https://images.unsplash.com/photo-1614891669421-964261109bb4?ixid=MnwxMjA3fDB8MHxzZWFyY2h8M3x8bGFuY2hlfGVufDB8fDB8fA%3D%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=500&q=60"

                    }
                    
                );
                context.SaveChanges();
            }
        }
    }
}