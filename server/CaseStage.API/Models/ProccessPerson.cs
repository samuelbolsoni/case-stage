using Microsoft.EntityFrameworkCore;

namespace CaseStage.API.Models
{
    public class ProccessPerson
    {
        public int Id { get; set; }
        public int ProccessId { get; set; }
        public int PersonId { get; set; }
        
        /*
         * só para entity
        public Proccess Proccess { get; set; } = null!;
        public Person Person { get; set; } = null!;
        */
    }
}
