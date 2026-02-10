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
        public decimal? Score { get; set; }
        [MaxLength(2000)]
        public string? ReviewText { get; set; }
        [MaxLength(500)]
        public string? PictureName { get; set; }
    }

    /*
     * Note (NRefVal = 1):
     *      Oprindelig:
     *      [Column(TypeName = "decimal(2,1)")]
     *      public double? Score { get; set; }
     *      
     *      Ændret til:
     *      [Column(TypeName = "decimal(2,1)")]
     *      public decimal? Score { get; set; }
     *      
     *      Årsag (anvendte ChatGPT for forklaringen):
     * "Why this mismatch is risky
        1. Precision & rounding issues
            SQL decimal is a base-10 exact type (great for money, measurements, etc.)
            C# double is a base-2 floating-point type (approximate)"...
     * "3. You probably won’t get a compile-time error
        EF will happily map it and:
            ✔ App starts
            ✔ Queries run
            ❌ Bugs show up later (the worst kind)"...
    // */
}
