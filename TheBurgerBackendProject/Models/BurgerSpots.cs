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
        public double CoordinateLat { get; set; }
        [Column(TypeName = "decimal(18,14)")]
        public double CoordinateLon { get; set; }
        [MaxLength(500)]
        public string? OpenTimes { get; set; }
        public DateTime LastEditAt { get; set; }
        public string? IdentityUserId { get; set; }
        [ForeignKey("IdentityUserId")]
        public IdentityUser? UserId { get; set; }
    }
}
