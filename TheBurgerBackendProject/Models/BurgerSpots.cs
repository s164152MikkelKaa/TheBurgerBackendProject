using Microsoft.AspNetCore.Identity;
using Microsoft.SqlServer.Server;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheBurgerBackendProject.Models
{
    public class BurgerSpots
    {
        public int Id { get; set; }
        [MaxLength(200)]
        public string SpotName { get; set; }
        [MaxLength(200)]
        public string SpotAddress { get; set; }
        [Column(TypeName = "decimal(18,14)")]
        public decimal CoordinateLat { get; set; }
        [Column(TypeName = "decimal(18,14)")]
        public decimal CoordinateLon { get; set; }
        [MaxLength(500)]
        public string? OpenTimes { get; set; }
        public DateTime LastEditAt { get; set; } = DateTime.UtcNow;
        public string? LastEditBy { get; set; }
        [ForeignKey("LastEditBy")]
        public IdentityUser? User { get; set; }
    }

    /*
     * Note:
     * CoordinateLat og CoordinateLon blev ændret fra double til decimal (på C# siden), grundet: se UserReview.cs [NRefVal = 1]
     * 
     * ("NRefVal" Note Reference Value)
    // */
}
