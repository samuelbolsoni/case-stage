using System.ComponentModel.DataAnnotations;

namespace CaseStage.Application.Areas.Models
{
    public class SystemModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(800)]
        public bool Active { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        //public List<ProccessSystem> ProccessSystem { get; set; } = new();
        public List<ProccessModel> Proccess { get; set; } = new();
    }
}
