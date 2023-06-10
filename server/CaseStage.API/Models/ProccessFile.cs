namespace CaseStage.API.Models
{
    public class ProccessFile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FileName { get; set; }

        //Foreign keys
        public int ProccessId { get; set; }
        /*
         * * Entity Migration
        public Proccess Proccess { get; set; }
        */
    }
}
