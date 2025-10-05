using System.ComponentModel.DataAnnotations;

namespace DBRepository_Group2.Models.dtos
{
    public record CreateGuestDto
    {
        public string FullName { get; set; } = string.Empty;
        public bool Confirmed { get; set; }
    }
}


