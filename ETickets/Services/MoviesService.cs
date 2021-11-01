using ETickets.Base;
using ETickets.Data;
using ETickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETickets.Services
{
    public class MoviesService : EntityBaseRepository<Movie>, IMoviesService
    {
        public MoviesService(AppDbContext context) : base(context) { }
    }
    
    
}
