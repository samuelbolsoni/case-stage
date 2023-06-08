using Microsoft.EntityFrameworkCore;

namespace CaseStage.Application.Areas.Models
{
    [Keyless]
    public class ProccessSystem
    {
        public int ProccessId { get; set; }
        public int SystemId { get; set; }

       // public ProccessModel Proccess { get; set; } = null!;
        public SystemModel System { get; set; } = null!;
    }
}
