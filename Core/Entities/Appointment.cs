using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class Appointment :BaseEntity
    {
        public DateTime Date { get; set; }
        public int Capacity { get; set; }
        public bool? IsConfirmed { get; set; }

        public List<Passenger> Passengers { get; set; }
    }
}