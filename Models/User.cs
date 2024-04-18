using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalBattle.Models
{
    public class User:IdentityUser
    {
        public string? UserImageUrl { get; set; }
        public ICollection<Post> Posts { get; set; }
        public ICollection<Canvas> Canvases { get; set; }

        [ForeignKey("ShoppingCart")]
        public int? ShoppingCartId { get; set; }
        public ShoppingCart? ShoppingCart { get; set; }
    }
}
