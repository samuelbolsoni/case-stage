using Microsoft.EntityFrameworkCore;

namespace CaseStage.API.Models
{
    [Keyless]
    public class ProccessPerson
    {
        public int ProccessId { get; set; }
        public int PersonId { get; set; }

        public Proccess Proccess { get; set; } = null!;
        public Person Person { get; set; } = null!;
    }
}
