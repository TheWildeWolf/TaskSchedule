using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class ScheduleViewModel
    {
        public AppoinmentViewModel Appoinment { get; set; }
        public List<PassengerViewModel> Passengers { get; set; }



        public decimal TotalWeight { 
            get {
                return Passengers != null ? Passengers.Sum(x => x.Weight):0;
            }
            
        }
        public int Count { 
            get {
                return Passengers != null ? Passengers.Count() : 0;
            } 
        }
    }
}
