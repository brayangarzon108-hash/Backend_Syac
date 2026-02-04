namespace TestInterRapidisimo.Domain.Model.Response
{
    public class StudentSubjectResponse
    {
        public int SubjectId { get; set; }
        public int StudentId { get; set; }
    }

    public class ListStudentSubjectResponse
    {
        public int StudentSubjectId { get; set; }
        public int SubjectId { get; set; }
        public string? NameSubjectId { get; set; }
        public int Credits { get; set; }
        public int StudentId { get; set; }
        public string? NameStudentId { get; set; }
    }
}
