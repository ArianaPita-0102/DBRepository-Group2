using System.ComponentModel.DataAnnotations;

namespace DBRepository_Group2.Models.Dtos
{
    public class CreateEventDto
    {
        [Required, StringLength(200)]
        public string Title { get; init; } = string.Empty;

        [Range(1000, 2100)]
        public int Capacity { get; init; }
    }
}
