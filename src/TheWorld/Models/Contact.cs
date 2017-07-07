
using System.ComponentModel.DataAnnotations;

namespace TheWorld.Models {
    public class Contact {
        [Required]
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
    }
}