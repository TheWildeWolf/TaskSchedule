using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{
    public class PassengerRepo : IPassengerRepo
    {
        private readonly SchedulerDbContext _db;
        public PassengerRepo(SchedulerDbContext dbContext)
        {
            _db = dbContext;
        }
        public async Task Create(Passenger passenger)
        {
            await _db.Passengers.AddAsync(passenger);
        }

        public async Task<List<Passenger>> GetOpenPassengers()
        {
            return await _db.Passengers.Where(x => x.State == PassengerState.Open).ToListAsync();
        }

        public async Task<List<Passenger>> List()
        {
           return await _db.Passengers.ToListAsync();
        }

        public async Task<Passenger> View(int id)
        {
          return  await _db.Passengers.Include(x=>x.Appointment).FirstOrDefaultAsync(x=>x.Id==id);
        }
    }
}
