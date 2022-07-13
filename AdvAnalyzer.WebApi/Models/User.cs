namespace AdvAnalyzer.WebApi.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public byte[] Password { get; set; }
        public byte[] Salt { get; set; }
    }
}
