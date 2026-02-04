using Microsoft.EntityFrameworkCore;
using TCI.API.Domain.Class.ActivosO.Activos;

namespace Console.Migration.Context
{
    public class SqlServerContext : DbContext
    {
        public SqlServerContext(DbContextOptions options) : base(options) { }
        public DbSet<StudentDto> Students { get; set; }
        public DbSet<ProgramDto> Programs { get; set; }
        public DbSet<ProfessorDto> Professors { get; set; }
        public DbSet<SubjectDto> Subjects { get; set; }
        public DbSet<StudentSubjectDto> StudentSubjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Student
            modelBuilder.Entity<StudentDto>()
                .HasIndex(s => s.Email)
                .IsUnique();

            // StudentSubject unique
            modelBuilder.Entity<StudentSubjectDto>()
                .HasIndex(ss => new { ss.StudentId, ss.SubjectId })
                .IsUnique();

            // Relationships
            modelBuilder.Entity<StudentSubjectDto>()
                .HasOne(ss => ss.Student)
                .WithMany(s => s.StudentSubjects)
                .HasForeignKey(ss => ss.StudentId);

            modelBuilder.Entity<StudentSubjectDto>()
                .HasOne(ss => ss.Subject)
                .WithMany(s => s.StudentSubjects)
                .HasForeignKey(ss => ss.SubjectId);

            modelBuilder.Entity<ProgramDto>(
                b =>
                {
                    b.HasKey(e => new { e.ProgramId });
                });

            modelBuilder.Entity<StudentDto>(
               b =>
               {
                   b.HasKey(e => new { e.StudentId });
               });


            modelBuilder.Entity<SubjectDto>(
               b =>
               {
                   b.HasKey(e => new { e.SubjectId });
               });


            modelBuilder.Entity<ProfessorDto>(
               b =>
               {
                   b.HasKey(e => new { e.ProfessorId });
               });

            modelBuilder.Entity<StudentSubjectDto>(
               b =>
               {
                   b.HasKey(e => new { e.StudentSubjectId });
               });
        }    
    }
}
