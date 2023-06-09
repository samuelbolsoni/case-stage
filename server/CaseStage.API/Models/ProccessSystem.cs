using Microsoft.EntityFrameworkCore;

namespace CaseStage.API.Models
{
    [Keyless]
    public class ProccessSystem
    {
        public int ProccessId { get; set; }
        public int SystemId { get; set; }

        public Proccess Proccess { get; set; } = null!;
        public SystemApp System { get; set; } = null!;
    }
}
