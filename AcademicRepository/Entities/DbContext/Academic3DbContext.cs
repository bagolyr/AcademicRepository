using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace _2022_09_23.Entities.DbContextNamespace
{
    public class Academic3DbContext: DbContext
    {
        public DbSet<Position> Positions { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<Speciality> Specialitys { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        public Academic3DbContext(DbContextOptions<Academic3DbContext> options) : base(options)
        {
            Database.SetCommandTimeout(60);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>().HasOne<Speciality>(st => st.Speciality);
            modelBuilder.Entity<Teacher>().HasOne<Position>(st => st.Position);

            //modelBuilder.Entity<SubjectTeacher>().HasKey(st => new { st.SubjectId, st.TeacherId });
            //modelBuilder.Entity<SubjectTeacher>()
            //    .HasOne<Subject>(s => s.Subject)
            //    .WithMany(p => p.SubjectTeacher)
            //    .HasForeignKey(s => s.SubjectId);
            //modelBuilder.Entity<SubjectTeacher>()
            //    .HasOne<Teacher>(s => s.Teacher)
            //    .WithMany(p => p.SubjectTeacher)
            //    .HasForeignKey(s => s.TeacherId);

            //modelBuilder.Entity<SubjectStudent>().HasKey(st => new { st.SubjectId, st.StudentId });
            //modelBuilder.Entity<SubjectStudent>()
            //    .HasOne<Subject>(s => s.Subject)
            //    .WithMany(p => p.SubjectStudents)
            //    .HasForeignKey(s => s.SubjectId);
            //modelBuilder.Entity<SubjectStudent>()
            //    .HasOne<Student>(s => s.Student)
            //    .WithMany(p => p.SubjectStudents)
            //    .HasForeignKey(s => s.StudentId);

            // task 8: Állítson be global query filtert, hogy a félévek, oktatók, hallgatók és tantárgyak közül csak a nem töröltek jöjjenek le az adatbázisból.
            modelBuilder.Entity<Semester>().HasQueryFilter(s => !s.Deleted);
            modelBuilder.Entity<Teacher>().HasQueryFilter(s => !s.Deleted);
            modelBuilder.Entity<Student>().HasQueryFilter(s => !s.Deleted);
            modelBuilder.Entity<Subject>().HasQueryFilter(s => !s.Deleted);

            // task 9: órarendi információ alapértelmezett értéke „ismeretlen” legyen
            modelBuilder.Entity<Subject>().Property(s => s.Description).HasDefaultValue("Ismeretlen");  
        }
    }
}
