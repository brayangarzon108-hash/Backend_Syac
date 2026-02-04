namespace TestInterRapidisimo.Domain.Model.Response
{
    public class HeadStudentListResponse
    {
        public HeadStudentListResponse()
        {
        }
        public int CountRegister { get; set; }
        public List<StudentListResponse> InfomationProcess { get; set; }

    }
    public class StudentListResponse
    {
        public int StudentId { get; set; }
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int ProgramId { get; set; }
        public string ProgramName { get; set; } = null!;
    }
}
