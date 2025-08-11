using System.ComponentModel.DataAnnotations;

namespace Kometha.API.Models.DTOs
{
    public class UpdateRegionRequestDTO
    {
        [Required]
        [MinLength(3, ErrorMessage = "El código debe de tener al menos 3 caracteres")]
        [MaxLength(6, ErrorMessage = "El código debe de tener máximo 3 caracteres")]
        public string Code { get; set; }
        [Required]
        [MaxLength(30, ErrorMessage = "El nombre debe de tener máximo 30 caracteres")]
        public string Name { get; set; }
        public string? RegionImageUrl { get; set; }
    }
}
