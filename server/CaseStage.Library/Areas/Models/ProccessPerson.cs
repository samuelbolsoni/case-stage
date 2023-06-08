using Microsoft.EntityFrameworkCore;

namespace CaseStage.Application.Areas.Models
{
    [Keyless]
    public class ProccessPerson
    {
        public int ProccessId { get; set; } 
        public int PersonId { get; set; }

        public ProccessModel Proccess { get; set; } = null!;
        public PersonModel Person { get; set; } = null!;
        
    }
}
