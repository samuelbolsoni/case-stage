namespace CaseStage.Application.Areas.Models
{
    public class FileModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FileName { get; set; }

        //Foreign keys
        public int ProccessId { get; set; }
        public ProccessModel Proccess { get; set; }
    }
}
