namespace TestInterRapidisimo.Domain.Model.Response
{
    public class ClassmatesResponse
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; } = null!;
        public List<string> Classmates { get; set; } = new();
    }
}
