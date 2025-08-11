using Kometha.API.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace Kometha.API.Models.DTOs
{
    public class UpdateWalkRequestDTO
    {
        [Required]
        [MinLength(1, ErrorMessage = "El nombre no puede estar vacio")]
        [MaxLength(50, ErrorMessage = "El nombre es demasiado largo")]
        public string Name { get; set; }
        [Required]
        [MaxLength(1000, ErrorMessage = "La descripción super los 1000 caracteres")]
        public string Description { get; set; }
        [Required]
        public double LengthInKm { get; set; }
        public string? WalkImageUrl { get; set; }
        [Required]
        public Guid DifficultyId { get; set; }
        [Required]

        public Guid RegionId { get; set; }
    }
}
