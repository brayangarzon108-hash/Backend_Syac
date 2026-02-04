namespace TestInterRapidisimo.Domain.Model.Response
{
    public class CreateStudentResponse
    {
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int ProgramId { get; set; }
    }
}
