using ETickets.Base;
using ETickets.Data;
using ETickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETickets.Services
{
    public class Actors_MoviesService : EntityBaseRepository<Actor_Movie>, IActors_MoviesService
    {
        public Actors_MoviesService(AppDbContext context) : base(context) { }
    }
    
}
