using Microsoft.EntityFrameworkCore;

namespace CaseStage.API.Models
{
    public class ProccessSystem
    {
        public int Id { get; set; }
        public int ProccessId { get; set; }
        public int SystemId { get; set; }
        /*
        public Proccess Proccess { get; set; } = null!;
        public SystemApp System { get; set; } = null!;
        */
    }
}
