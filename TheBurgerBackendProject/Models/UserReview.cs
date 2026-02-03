using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheBurgerBackendProject.Models
{
    public class UserReview
    {
        public int Id { get; set; }
        public int BurgerSpotsId { get; set; }
        [ForeignKey("BurgerSpotsId")]
        public BurgerSpots BurgerSpots { get; set; }
        public string? UserId { get; set; }
        [ForeignKey("UserId")]
        public IdentityUser? User { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? LastEditAt { get; set; }
        [Column(TypeName = "decimal(2,1)")]
        public double? Score { get; set; }
        [MaxLength(2000)]
        public string? ReviewText { get; set; }
        [MaxLength(500)]
        public string? PictureName { get; set; }
    }
}
