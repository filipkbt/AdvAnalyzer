namespace AdvAnalyzer.Application.UserManagement.DTOs
{
    public class UserForCreationDto
    {
        public string Login { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
