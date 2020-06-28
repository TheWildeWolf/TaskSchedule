using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Interfaces
{
    public interface IAppoinmentViewModelService
    {
        Task<List<AppoinmentViewModel>> GetListOfAppoinments();

        Task CreateAppoinment(AppoinmentViewModel appoinmentViewModel);

        Task<ScheduleViewModel> ViewAppoinment(int id);

        Task UpdateAppoinment(ScheduleViewModel viewModel);
    }
}
