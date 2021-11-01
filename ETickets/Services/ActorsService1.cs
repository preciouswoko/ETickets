using ETickets.Data;
using ETickets.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ETickets.Services
{
    public class ActorsService1 : IActorsService1
    {
        private readonly AppDbContext _context;
        public ActorsService1(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Actor actor)
        {

            await _context.Actors.AddAsync(actor);
            await _context.SaveChangesAsync();

        }

        public async Task DeleteAsync(int id)
        {
            var result = await _context.Actors.FirstOrDefaultAsync(n => n.Id == id);
            _context.Actors.Remove(result);
            await _context.SaveChangesAsync();

        }

        public async Task<Actor> GetActor(int id)
        {
            var result = await _context.Actors.FirstOrDefaultAsync(m => m.Id == id);
            return result;
        }

        public async Task<IEnumerable<Actor>> GetAll()
        {
            var result = await _context.Actors.ToListAsync();
            return result;
        }

        public async Task<Actor> UpdateAsync(int id, Actor newActor)
        {
        
            _context.Update(newActor);
            await _context.SaveChangesAsync();
            return newActor;
        }


    }
}

