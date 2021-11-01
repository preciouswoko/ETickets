using ETickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETickets.Services
{
   public interface IActorsService1
    {
        Task<IEnumerable<Actor>> GetAll();
        Task<Actor> GetActor(int id);
        Task AddAsync(Actor actor);
        Task<Actor> UpdateAsync(int id, Actor newActor);
        Task DeleteAsync(int id);
    }
}
