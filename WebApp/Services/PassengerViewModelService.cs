using Core.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Interfaces;
using WebApp.Models;

namespace WebApp.Services
{
    public class PassengerViewModelService : IPassengerViewModelService
    {


        private IPassengerRepo _passengerRepo;
        private IUnitOfWork _unitOfWork;
        private IScheduleRepo _scheduleRepo;
        private IAppoinmentRepo _appoinmentRepo;

        public PassengerViewModelService(IPassengerRepo repo,
            IUnitOfWork unitOfWork,
            IScheduleRepo scheduleRepo,
            IAppoinmentRepo appoinmentRepo
            )
        {
            _appoinmentRepo = appoinmentRepo;
            _passengerRepo = repo;
            _unitOfWork = unitOfWork;
            _scheduleRepo = scheduleRepo;
        }


        public async Task CreatePassenger(PassengerViewModel passengerViewModel)
        {
           await  _passengerRepo.Create(new Core.Entities.Passenger
            {
                FirstName = passengerViewModel.FirstName,
                LastName = passengerViewModel.LastName,
                Weight = passengerViewModel.Weight,
                State = Core.Entities.PassengerState.Open
            });
           await _unitOfWork.Save();
        }

        public async Task<List<PassengerViewModel>> GetListOfPassengers()
        {
            var data = await _passengerRepo.List();
            return data.Select(x => new PassengerViewModel
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                State = x.State,
                Weight = x.Weight,
                Id = x.Id
            }).ToList();
        }

        public async Task Update(int id, int appoinmentId)
        {
            await _scheduleRepo.Create(id, appoinmentId);
            await _unitOfWork.Save();
        }

        public async Task<PassengerViewModel> ViewPassenger(int id)
        {
            var data = await _passengerRepo.View(id);
            var appoinments = await _appoinmentRepo.GetAppoinments();
            return new PassengerViewModel
            {
                FirstName = data.FirstName,
                LastName = data.LastName,
                State = data.State,
                Weight = data.Weight,
                ScheduledTime = data.Appointment != null ? data.Appointment.Date.ToString() : "",
                Appoinments = new SelectList(appoinments, "Id", "Date")
            };
        }
    }
}
