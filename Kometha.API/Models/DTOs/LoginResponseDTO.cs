namespace Kometha.API.Models.DTOs
{
    public class LoginResponseDTO
    {
        public string Jwt { get; set; }
        public DateTime Expiration { get; set; }
    }
}
