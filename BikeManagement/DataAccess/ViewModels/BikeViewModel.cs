using System;
using System.ComponentModel.DataAnnotations;

namespace BikeManagement.DataAccess.ViewModels
{
    public class BikeViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
