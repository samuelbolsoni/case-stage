using System.ComponentModel.DataAnnotations;

namespace CaseStage.Application.Areas.Models
{
    public class AreaModel
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        public bool Active { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public ICollection<ProccessModel> Proccess { get; set; }
    }
}
