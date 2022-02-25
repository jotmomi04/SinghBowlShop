using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SinghBowlShop.Data;
using System;
using System.Linq;

namespace SinghBowlShop.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(serviceProvider.GetRequiredService<
                DbContextOptions<ApplicationDbContext>>()))
            {

                if (context.BowlMaker.Any())
                {
                    return;
                }
                context.BowlMaker.AddRange(
                    new BowlMaker
                    {
                        Type = "Italiian",
                        Size = "Large",
                        Color = "Brown",
                        Price = 5.9M,
                        Rating = 4
                    }, new BowlMaker
                    {
                        Type = "Indian",
                        Size = "Large",
                        Color = "Red",
                        Price = 5.9M,
                        Rating = 5
                    }, new BowlMaker
                    {
                        Type = "Transparent",
                        Size = "Medium",
                        Color = "Green",
                        Rating = 4
                    }, new BowlMaker
                    {
                        Type = "Plastic",
                        Size = "Large/Small",
                        Color = "Green",
                        Price = 3.6M,
                        Rating = 2
                    }, new BowlMaker
                    {
                        Type = "Chinese",
                        Size = "Medium",
                        Color = "Green",
                        Price = 7.6M,
                        Rating = 5
                    }, new BowlMaker
                    {
                        Type = "Ceramic",
                        Size = "Large",
                        Color = "Green",
                        Price = 2.6M,
                        Rating = 2
                    }, new BowlMaker
                    {
                        Type = "Wood",
                        Size = "Small/Large/Medium",
                        Color = "Green",
                        Price = 8.6M,
                        Rating = 2
                    }, new BowlMaker
                    {
                        Type = "Steel",
                        Size = "Small",
                        Color = "Green",
                        Price = 7.6M,
                        Rating = 2
                    }, new BowlMaker
                    {
                        Type = "Glass/Transpatrent",
                        Size = "Large",
                        Color = "Green",
                        Price = 3.5M,
                        Rating = 2
                    }, new BowlMaker
                    {
                        Type = "Glass/Clear",
                        Size = "Large",
                        Color = "Green",
                        Price = 3.6M,
                        Rating = 2
                    }, new BowlMaker
                    {
                        Type = "Cooper",
                        Size = "Large",
                        Color = "Green",
                        Price = 6.6M,
                        Rating = 2
                    }
                    );
                context.SaveChanges();
            }

        }
    }
}
