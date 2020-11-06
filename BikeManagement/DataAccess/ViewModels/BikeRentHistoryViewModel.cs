using System;
using System.ComponentModel.DataAnnotations;

namespace BikeManagement.DataAccess.ViewModels
{
    public class BikeRentHistoryViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string CustomerName { get; set; }

        public string CheckOutTime { get; set; }

        public string CheckInTime { get; set; }

        public string BikeId { get; set; }

        public string TimeSpent { get; set; }
    }
}
