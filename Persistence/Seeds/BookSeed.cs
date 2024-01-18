using Domain.Entities.Library;
using Persistence.Contexts;

namespace Persistence.Seeds
{
    public static class BookSeed
    {
        public static async Task SeedLanguagesAsync(ApplicationDbContext context)
        {
            if (!context.Languages.Any())
            {
                context.Languages.AddRange(new List<Idiom>
                {
                    new Idiom
                    {
                        Code = "es",
                        Description = "Español"
                    },
                    new Idiom
                    {
                        Code = "en",
                        Description = "Inglés"
                    },
                    new Idiom
                    {
                        Code = "fr",
                        Description = "Francés"
                    },
                    new Idiom
                    {
                        Code = "ja",
                        Description = "Japonés"
                    },
                });

                await context.SaveChangesAsync();
            }
        }
        public static async Task SeedBooksAsync(ApplicationDbContext context)
        {
            if (!context.Books.Any())
            {
                context.Books.AddRange(new List<Book>
                {
                    new Book
                    {
                        Title = "The Lord of the Rings",
                        Publication = 1954,
                        Description = "La Comunidad del Anillo el primero de los tres volúmenes que forman la obra. Está subdividido a su vez en dos partes, precedidas de un prólogo.",
                        Pages = 560,
                        AverageScore = 0,
                        LanguageId = 1
                    },
                    new Book
                    {
                        Title = "The Hobbit, or There and Back Again",
                        Publication = 1937,
                        Description = "La historia comienza un día en el que el hobbit Bilbo Bolsón, habitante de la Comarca, recibe la inesperada visita del mago Gandalf y de una compañía de trece enanos, liderada por Thorin Escudo de Roble, y compuesta por Balin, Glóin, Bifur, Bofur, Bombur, Dwalin, Ori, Dori, Nori, Óin, Kíli y Fíli.",
                        Pages = 310,
                        AverageScore = 0,
                        LanguageId = 1
                    },
                });

                await context.SaveChangesAsync();
            }
        }
    }
}
