using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IAppoinmentRepo
    {
        Task Create(Appointment appointment);

        Task<Appointment> View(int id);

        Task<List<Appointment>> List();

        Task SetConfirm(int id, bool isConfirm);

        Task<List<Appointment>> GetAppoinments();
    }
}
