using System.ComponentModel.DataAnnotations.Schema;

namespace FinalBattle.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        [ForeignKey("User")]
        public string? UserId { get; set; }
        public User? User { get; set; }

        public ICollection<Course> Courses { get; set; }
    }
}
