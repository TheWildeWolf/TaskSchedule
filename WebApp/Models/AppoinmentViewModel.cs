using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class AppoinmentViewModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Capacity { get; set; }
        public bool? IsConfirmed { get; set; }

        public Confirmation Confirmation { get; set; }
    }

    public enum Confirmation {
        Confirmed =1,
        Denied =0,
        [Display(Name = "No Action")]
        NoAction = 3,
    }
}
