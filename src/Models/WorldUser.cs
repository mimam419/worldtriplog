using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace TheWorld.Models
{
    public class WorldUser : IdentityUser
    {
        public DateTime FirstTrip { get; set; }
    }
}
