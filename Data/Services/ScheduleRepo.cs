using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{
    public class ScheduleRepo : IScheduleRepo
    {
        private readonly SchedulerDbContext _db;
        public ScheduleRepo(SchedulerDbContext dbContext)
        {
            _db = dbContext;
        }

        public async Task Create(int passengerId, int appoinmentId)
        {
            var passenger = await _db.Passengers.FindAsync(passengerId);
            passenger.AppoinmentId = appoinmentId;
            passenger.State = Core.Entities.PassengerState.Active;
        }
    }
}
