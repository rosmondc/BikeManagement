using System.Collections.Generic;

namespace BikeManagement.DataAccess.Models
{
    public class Bike
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public ICollection<BikeRentHistory> BikeRentedHistory { get; set; }
    }
}
