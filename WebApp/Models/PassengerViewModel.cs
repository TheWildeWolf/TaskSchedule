using Core.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class PassengerViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Weight { get; set; }

        public string ScheduledTime { get; set; }


        public SelectList Appoinments { get; set; }
        public PassengerState State { get; set; }
    }
}
