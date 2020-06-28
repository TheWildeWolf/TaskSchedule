using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{
    public class UnitOfWorkRepo : IUnitOfWork
    {
        private readonly SchedulerDbContext _db;
        public UnitOfWorkRepo(SchedulerDbContext dbContext)
        {
            _db = dbContext;
        }
        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }
    }
}
