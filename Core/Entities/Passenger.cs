using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class Passenger : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Weight { get; set; }
        public PassengerState State { get; set; }

        public int? AppoinmentId { get; set; }
        public Appointment Appointment { get; set; }
    }

    public enum PassengerState :byte 
    {
        Open,
        Active,
        Booked

    }
}
