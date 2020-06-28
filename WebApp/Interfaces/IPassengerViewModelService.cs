using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Interfaces
{
    public interface IPassengerViewModelService
    {
        Task<List<PassengerViewModel>> GetListOfPassengers();
        Task CreatePassenger(PassengerViewModel passengerViewModel);
        Task<PassengerViewModel> ViewPassenger(int id);

        Task Update(int id, int appoinmentId);

    }
}
