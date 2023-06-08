using System.ComponentModel.DataAnnotations;

namespace CaseStage.Application.Areas.Models
{
    public class PersonModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MaxLength(100)]
        public string Email { get; set; }
        public bool Active { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        //public List<ProccessPerson> ProccessPerson { get; set; } = new();
        public List<ProccessModel> Proccess { get; set; } = new();
    }
}
