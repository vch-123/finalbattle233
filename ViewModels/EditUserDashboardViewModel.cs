namespace FinalBattle.ViewModels
{
    public class EditUserDashboardViewModel
    {
        public string Id { get; set; }
        
        public string? UserImageUrl { get; set; }
        
        public IFormFile Image { get; set; }
    }
}
