using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IPassengerRepo
    {
        Task Create(Passenger passenger);

        Task<List<Passenger>> List();

        Task<Passenger> View(int id);

        Task<List<Passenger>> GetOpenPassengers();
    }
}
