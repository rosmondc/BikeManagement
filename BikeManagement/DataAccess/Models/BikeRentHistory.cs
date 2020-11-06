using System;

namespace BikeManagement.DataAccess.Models
{
    public class BikeRentHistory
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }

        public DateTime CheckOutTime { get; set; }

        public DateTime CheckInTime { get; set; }

        public double TimeSpent { get; set; }

        public DateTime DateModified { get; set; }
        
        public Bike Bike { get; set; }

    }
}
