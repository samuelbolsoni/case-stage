using System.ComponentModel.DataAnnotations;

namespace CaseStage.API.Models
{
    public class Proccess
    {
        public int Id { get; set; }
        public int? IdParent { get; set; }

        [Required]
        [MaxLength(255)]
        public string Description { get; set; } = string.Empty;
        [MaxLength(800)]
        public string? Documentation { get; set; } = string.Empty;
        public bool Active { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        //Foreign keys
        public int AreaId { get; set; }
        public Area Area { get; set; }
    }
}
