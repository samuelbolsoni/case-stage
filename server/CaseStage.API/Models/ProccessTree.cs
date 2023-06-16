using System.ComponentModel.DataAnnotations;

namespace CaseStage.API.Models
{
    public class ProccessTree
    {
        public int Id { get; set; }
        public int? IdParent { get; set; }

        [Required]
        [MaxLength(255)]
        public string Description { get; set; } = string.Empty;

        public List<ProccessTree>? Childrens { get; set; } = null;
    }
}
