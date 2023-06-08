using System.ComponentModel.DataAnnotations;

namespace CaseStage.Application.Areas.Models
{
    public class ProccessModel
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
        public AreaModel Area { get; set; }

        //public List<ProccessPerson> ProccessPerson { get; set; } = new();
        public List<PersonModel> Persons { get; set; } = new();

        //public List<ProccessSystem> ProccessSystem { get; set; } = new();
        public List<SystemModel> Systems { get; set; } = new();

        public ICollection<FileModel> File { get; set; }
    }
}
