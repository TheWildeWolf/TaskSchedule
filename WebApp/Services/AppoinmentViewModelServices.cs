using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Interfaces;
using WebApp.Models;

namespace WebApp.Services
{
    public class AppoinmentViewModelServices : IAppoinmentViewModelService
    {
        private IAppoinmentRepo _appoinmentRepo;
        private IUnitOfWork _unitOfWork;

        public AppoinmentViewModelServices(IAppoinmentRepo repo,
            IUnitOfWork unitOfWork
            )
        {
            _appoinmentRepo = repo;
            _unitOfWork = unitOfWork;
        }
        public async Task CreateAppoinment(AppoinmentViewModel appoinmentViewModel)
        {
           await _appoinmentRepo.Create(new Core.Entities.Appointment
            {
                Capacity = appoinmentViewModel.Capacity,
                Date = appoinmentViewModel.Date,
                IsConfirmed = null
            });
           await _unitOfWork.Save();
        }

        public async Task<List<AppoinmentViewModel>> GetListOfAppoinments()
        {
            var list = await _appoinmentRepo.List();
            return list.Select(n => new AppoinmentViewModel
            {
                Capacity = n.Capacity,
                Date = n.Date,
                Id = n.Id,
                IsConfirmed = n.IsConfirmed,
                Confirmation = n.IsConfirmed == null ? Confirmation.NoAction :
                     (n.IsConfirmed == true ? Confirmation.Confirmed : Confirmation.Denied)

            }).ToList();
        }

        public async Task UpdateAppoinment(ScheduleViewModel viewModel)
        {
            if (viewModel.Appoinment.Confirmation != Confirmation.NoAction)
            {
               await _appoinmentRepo.SetConfirm(viewModel.Appoinment.Id, viewModel.Appoinment.Confirmation == Confirmation.Denied ? false : true);
               await _unitOfWork.Save();
            }
        }

        public async Task<ScheduleViewModel> ViewAppoinment(int id)
        {
            var data = await _appoinmentRepo.View(id);
            var vm = new ScheduleViewModel();
            vm.Appoinment = new AppoinmentViewModel
            {
                Capacity = data.Capacity,
                Date = data.Date,
                Id = data.Id,
                IsConfirmed = data.IsConfirmed,
                Confirmation = data.IsConfirmed == null ? Confirmation.NoAction :
                     (data.IsConfirmed == true ? Confirmation.Confirmed : Confirmation.Denied)
            };
            vm.Passengers = new List<PassengerViewModel>();
            foreach (var passenger in data.Passengers)
            {
                vm.Passengers.Add(new PassengerViewModel
                {
                    FirstName = passenger.FirstName,
                    LastName = passenger.LastName,
                    Weight = passenger.Weight
                });
            }
            return vm;
        }
    }
}
