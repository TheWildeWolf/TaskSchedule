using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IScheduleRepo
    {
        Task Create(int passengerId, int appoinmentId);

    }
}
