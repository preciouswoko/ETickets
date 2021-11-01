using ETickets.Data.Enums;
using ETickets.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETickets.Data
{
    public class AppDbInitializer
    {
        public static void seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                context.Database.EnsureCreated();

                //Cinema
                if (!context.Cinemas.Any())
                {
                    context.Cinemas.AddRange(new List<Cinema>()
                    {
                        new Cinema()
                        {
                        Name = "Cinema 1",
                        Logo = "http://dotnethow.net/images/cinemas/cinema-1.jpeg",
                        Description = "This is the description of the first cinema"
                        },
                        new Cinema()
                    {
                        Name = "Cinema 2",
                        Logo = "http://dotnethow.net/images/cinemas/cinema-2.jpeg",
                        Description = "This is the description of the Second cinema"
                    },
                        new Cinema()
                    {
                        Name = "Cinema 3",
                        Logo = "http://dotnethow.net/images/cinemas/cinema-3.jpeg",
                        Description = "This is the description of the third cinema"
                    },
                    new Cinema()
                    {
                        Name = "Cinema 4",
                        Logo = "http://dotnethow.net/images/cinemas/cinema-4.jpeg",
                        Description = "This is the description of the fourth cinema"
                    },
                    new Cinema()
                    {
                        Name = "Cinema 5",
                        Logo = "http://dotnethow.net/images/cinemas/cinema-5.jpeg",
                        Description = "This is the description of the fifth cinema"
                    }
                    });


                    context.SaveChanges();
                };


                //Producer
                if (!context.Producers.Any())
                {
                    context.Producers.AddRange(new List<Producer>()
                     {
                          new Producer()
                    {
                        FullName = "Producer 1",
                        ProfilePictureUrl = "http://dotnethow.net/images/producer/producer-1.jpeg",
                        Bio = "This is the description of the first producer"
                    },
                new Producer()
                {
                    FullName = "Producer 2",
                    ProfilePictureUrl = "http://dotnethow.net/images/producer/producer-2.jpeg",
                    Bio = "This is the description of the second producer"
                },
                new Producer()
                {
                    FullName = "Producer 3",
                    ProfilePictureUrl = "http://dotnethow.net/images/producer/producer-3.jpeg",
                    Bio = "This is the description of the third producer"
                },
                new Producer()
                {
                    FullName = "Producer 4",
                    ProfilePictureUrl = "http://dotnethow.net/images/producer/producer-4.jpeg",
                    Bio = "This is the description of the fourth producer"
                },
                new Producer()
                {
                    FullName = "Producer 5",
                    ProfilePictureUrl = "http://dotnethow.net/images/producer/producer-5.jpeg",
                    Bio = "This is the description of the fifth producer"
                },
            });
                    context.SaveChanges();
                }

                //Actor
                if (!context.Actors.Any())
                {
                    context.Actors.AddRange(new List<Actor>()
                    {
                        new Actor()
                    {
                        FullName = "Actor 1",
                        ProfilePictureUrl = "http://dotnethow.net/images/actor/actor-1.jpeg",
                        Bio = "This is the description of the first actor"
                    },
                    new Actor()
                    {
                        FullName = "Actor 2",
                        ProfilePictureUrl = "http://dotnethow.net/images/actor/actor-2.jpeg",
                        Bio = "This is the description of the second actor"
                    },
                    new Actor()
                    {
                        FullName = "Actor 3",
                        ProfilePictureUrl = "http://dotnethow.net/images/actor/actor-3.jpeg",
                        Bio = "This is the description of the third actor"
                    },
                    new Actor()
                    {
                        FullName = "Actor 4",
                        ProfilePictureUrl = "http://dotnethow.net/images/actor/actor-4.jpeg",
                        Bio = "This is the description of the fourth actor"
                    },
                    new Actor()
                    {
                        FullName = "Actor 5",
                        ProfilePictureUrl = "http://dotnethow.net/images/actor/actor-5.jpeg",
                        Bio = "This is the description of the fifth actor"
                    },
                });
                    context.SaveChanges();
                }

                //Actors_Movies
                if (!context.Actors_Movies.Any())
                    context.Actors_Movies.AddRange(new List<Actor_Movie>()
                    {
                        new Actor_Movie()
                        {
                            ActorId = 5,
                            MovieId = 5
                        },
                        new Actor_Movie()
                        {
                            ActorId =3,
                            MovieId = 4
                        },
                        new Actor_Movie()
                        {
                            ActorId = 3,
                            MovieId = 6
                        },
                        new Actor_Movie()
                        {
                            ActorId =5,
                            MovieId = 6
                        },new Actor_Movie()
                        {
                            ActorId =1,
                            MovieId = 7
                        },new Actor_Movie()
                        {
                            ActorId =2,
                            MovieId = 2
                        },new Actor_Movie()
                        {
                            ActorId =3,
                            MovieId = 1
                        },new Actor_Movie()
                        {
                            ActorId =4,
                            MovieId = 4
                        },
                    });
                context.SaveChanges();

                //Movies
                if (!context.Movies.Any())
                {
                    context.Movies.AddRange(new List<Movie>()
                    {
                        new Movie()
                        {
                            Name = "Scoob",
                            Description =" This is the Scoob movie description",
                            Price = 3900,
                            ImageUrl = "http://dotnethow.net/images/movies/movie-1.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-2),
                            CinemaId = 1,
                            ProducerId =3,
                            movieCategory = MovieCategory.Cartoon
                        },
                         new Movie()
                        {
                            Name = "Cold Soles",
                            Description =" This is the Cold Soles movie description",
                            Price = 4000,
                            ImageUrl = "http://dotnethow.net/images/movies/movie-2.jpeg",
                            StartDate = DateTime.Now.AddDays(3),
                            EndDate = DateTime.Now.AddDays(20),
                            CinemaId = 1,
                            ProducerId =5,
                            movieCategory = MovieCategory.Drama
                        }, 
                        new Movie()
                        {
                            Name = "Ghost",
                            Description =" This is the Ghost movie description",
                            Price = 2500,
                            ImageUrl = "http://dotnethow.net/images/movies/movie-4.jpeg",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(7),
                            CinemaId = 4,
                            ProducerId =4,
                            movieCategory = MovieCategory.Horror
                        },
                        new Movie()
                        {
                            Name = "Race",
                            Description =" This is the Race movie description",
                            Price = 3000,
                            ImageUrl = "http://dotnethow.net/images/movies/movie-6.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-5),
                            CinemaId = 1,
                            ProducerId =2,
                            movieCategory = MovieCategory.Documentary
                        },
                        new Movie()
                        {
                            Name = "The Shawshank Redemption",
                            Description =" This is the Shawshank Redemption movie description",
                            Price = 5000,
                            ImageUrl = "http://dotnethow.net/images/movies/movie-1.jpeg",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(4),
                            CinemaId = 1,
                            ProducerId =1,
                            movieCategory = MovieCategory.Action
                        },
                });
                    context.SaveChanges();
                }



            }

        }
    }
}
