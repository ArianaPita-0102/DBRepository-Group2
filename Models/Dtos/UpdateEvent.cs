using System.ComponentModel.DataAnnotations;

namespace DBRepository_Group2.Models.Dtos
{
    public class UpdateEvent
    {
        [Required, StringLength(200)]
        public string Title { get; init; } = string.Empty;

        [Range(1000, 2100)]
        public int Year { get; init; }
    }
}
