using System;
using System.ComponentModel.DataAnnotations;

namespace TheWorld.ViewModels
{
    public class TripViewModel
    {
        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string Name { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
    }
}
