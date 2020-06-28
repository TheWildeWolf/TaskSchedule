using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Services
{
    public class AppoinmentRepo : IAppoinmentRepo
    {
        private readonly SchedulerDbContext _db;
        public AppoinmentRepo(SchedulerDbContext dbContext)
        {
            _db = dbContext;
        }

        public async Task Create(Appointment appointment)
        {
            await _db.Appointments.AddAsync(appointment);
        }

        public async Task<List<Appointment>> GetAppoinments()
        {
          return await _db.Appointments
                .Include(x=>x.Passengers)
                .Where(x => 

                (x.Capacity > x.Passengers.Count || x.Passengers.Count == 0)
                && (x.IsConfirmed == null|| x.IsConfirmed == true)
                
                ).ToListAsync();
        }


        public async Task<List<Appointment>> List()
        {
           return await _db.Appointments.ToListAsync();
        }

        public async Task SetConfirm(int id,bool isConfirm)
        {
           var appoinment = await _db.Appointments.Include(x => x.Passengers).FirstOrDefaultAsync(d => d.Id == id);
            appoinment.IsConfirmed = isConfirm;
            foreach (var passenger in appoinment.Passengers)
            {
                passenger.State = isConfirm ? PassengerState.Booked : PassengerState.Open;
                passenger.AppoinmentId = isConfirm ? passenger.AppoinmentId : null;
            }
        }

        public async Task<Appointment> View(int id)
        {
            return await _db.Appointments.Include(x=>x.Passengers).FirstOrDefaultAsync(d => d.Id == id);
        }
    }
}
