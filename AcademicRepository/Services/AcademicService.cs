using _2022_09_23.Entities;
using _2022_09_23.Entities.DbContextNamespace;
using _2022_09_23.Migrations.Academic2Db;
using Microsoft.EntityFrameworkCore;

namespace _2022_09_23.Services
{
    public interface IAcademicService
    {
        List<Subject> ListSubjects(string showDeleted); // task 4
        List<Teacher> ListTeachers(string showDeleted); // task 4
        List<Student> ListStudents(string showDeleted); // task 4
        List<Semester> ListSemesters(string showDeleted); // task 4
        List<Teacher> GetTeacherSubjectsByNeptunCodeAndSemester(string NeptunCode, string SemesterName, string showDeleted); // task 5
        List<Student> GetStudentSubjectsByNeptunCodeAndSemester(string NeptunCode, string SemesterName, string showDeleted); // task 6
        int CreateTeacher(Teacher teacher); // task 7
        int CreateSubject(Subject subject); // task 7, task 9
        int CreateSemester(Semester semester); // task 7
        int CreateStudent(Student student); // task 7
        int UpdateTeacher(Teacher teacher); // task 7
        int UpdateSubject(Subject subject); // task 7, task 9
        int UpdateSemester(Semester semester); // task 7
        int UpdateStudent(Student student); // task 7
        int DeleteTeacher(int id); // task 7
        int DeleteSubject(int id); // task 7
        int DeleteSemester(int id); // task 7
        int DeleteStudent(int id); // task 7
        int MapStudentSubject(int StudentId, int SubjectId); // task 7
        int MapSubjectTeacher(int SubjectId, int TeacherId); // task 7
        List<string> ListStudentsOfTeachers(int teacherId, int SemesterId); // task 10
        string ListCreditsAndStudentsOfTeachers(int teacherId, int SemesterId); // task 11
    }
    public class AcademicService : IAcademicService
    {
        private readonly Academic3DbContext _dbContext;

        public AcademicService(Academic3DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        // task 4 Az alkalmazásban lehessen listázni az összes tantárgyat, oktatót, hallgatót, félévet külön-külön végpontokon.
        public List<Subject> ListSubjects(string showDeleted)
        {
            // task 8: Az összes listázást végző végpontnál lehessen megadni, hogy a töröltek is legyenek a listában vagy ne
            if (showDeleted == "showDeleted")
            {
                return _dbContext.Subjects.IgnoreQueryFilters().ToList();
            }
            else
            {
                return _dbContext.Subjects.ToList();
            }
        }
        // task 4 Az alkalmazásban lehessen listázni az összes tantárgyat, oktatót, hallgatót, félévet külön-külön végpontokon.
        public List<Teacher> ListTeachers(string showDeleted) 
        {
            // task 8: Az összes listázást végző végpontnál lehessen megadni, hogy a töröltek is legyenek a listában vagy ne
            if (showDeleted == "showDeleted")
            {
                return _dbContext.Teachers.Include(t => t.Position).IgnoreQueryFilters().ToList();
            }
            else
            {
                return _dbContext.Teachers.Include(t => t.Position).ToList();
            }
        }
        // task 4 Az alkalmazásban lehessen listázni az összes tantárgyat, oktatót, hallgatót, félévet külön-külön végpontokon.
        public List<Student> ListStudents(string showDeleted)
        {
            // task 8: Az összes listázást végző végpontnál lehessen megadni, hogy a töröltek is legyenek a listában vagy ne
            if (showDeleted == "showDeleted")
            {
                var return_val = _dbContext.Students
                    .Include(s => s.Speciality)
                    .IgnoreQueryFilters()
                    .ToList();
                return return_val;
            }
            else
            {
                var return_val = _dbContext.Students
                    .Include(s => s.Speciality)
                    .ToList();
                return return_val;
            }
        }
        // task 4 Az alkalmazásban lehessen listázni az összes tantárgyat, oktatót, hallgatót, félévet külön-külön végpontokon.
        public List<Semester> ListSemesters(string showDeleted) 
        {
            // task 8: Az összes listázást végző végpontnál lehessen megadni, hogy a töröltek is legyenek a listában vagy ne
            if (showDeleted == "showDeleted")
            {
                return _dbContext.Semesters.IgnoreQueryFilters().ToList();
            }
            else
            {
                return _dbContext.Semesters.ToList();
            }
        }
        // task 5: Lehessen lekérni egy oktató egy félévben oktatott összes tantárgyát
        public List<Teacher> GetTeacherSubjectsByNeptunCodeAndSemester(string NeptunCode, string SemesterName, string showDeleted)
        {
            // task 8: Az összes listázást végző végpontnál lehessen megadni, hogy a töröltek is legyenek a listában vagy ne
            if (showDeleted == "showDeleted")
            {
                var return_val = _dbContext.Teachers
                    .Where(s => s.NeptunCode == NeptunCode)
                    .Include(s => s.Subjects.Where(s => s.Semester.Name == SemesterName))
                    .IgnoreQueryFilters()
                    .ToList();

                return return_val;
            }
            else
            {
                var return_val = _dbContext.Teachers
                    .Where(s => s.NeptunCode == NeptunCode)
                    .Include(s => s.Subjects.Where(s => s.Semester.Name == SemesterName))
                    .ToList();

                return return_val;
            }
        }
        // task 6: Lehessen lekérni egy hallgató egy félévben felvett összes tantárgyát.
        public List<Student> GetStudentSubjectsByNeptunCodeAndSemester(string NeptunCode, string SemesterName, string showDeleted) 
        {
            // task 8: Az összes listázást végző végpontnál lehessen megadni, hogy a töröltek is legyenek a listában vagy ne
            if (showDeleted == "showDeleted")
            {
                var return_val = _dbContext.Students
                    .Where(s => s.NeptunCode == NeptunCode)
                    .Include(s => s.Subjects.Where(s => s.Semester.Name == SemesterName))
                    .IgnoreQueryFilters()
                    .ToList();

                return return_val;
            }
            else
            {
                var return_val = _dbContext.Students
                    .Where(s => s.NeptunCode == NeptunCode)
                    .Include(s => s.Subjects.Where(s => s.Semester.Name == SemesterName))
                    .ToList();

                return return_val;
            }
        }

        // task 7: Lehessen új oktatót, tantárgyat, félévet és hallgatót felvinni a rendszerbe
        public int CreateTeacher(Teacher teacher)
        {
            _dbContext.Teachers.Add(teacher);
            return _dbContext.SaveChanges();
        }

        // task 7: Lehessen új oktatót, tantárgyat, félévet és hallgatót felvinni a rendszerbe
        public int CreateSubject(Subject subject)
        {
            // task 9:  ha nem ad mega felhasználó semmilyen értéket, akkor a mező értéke az előbbiekben leírt alapértelmezett értéket kapja meg.
            if (subject.Description == null)
            {
                subject.Description = "Ismeretlen";
            }
            _dbContext.Subjects.Add(subject);
            return _dbContext.SaveChanges();
        }

        // task 7: Lehessen új oktatót, tantárgyat, félévet és hallgatót felvinni a rendszerbe
        public int CreateSemester(Semester semester)
        {
            _dbContext.Semesters.Add(semester);
            return _dbContext.SaveChanges();
        }

        // task 7: Lehessen új oktatót, tantárgyat, félévet és hallgatót felvinni a rendszerbe
        public int CreateStudent(Student student)
        {
            _dbContext.Students.Add(student);
            return _dbContext.SaveChanges();
        }

        // task 7: lehessen módosítani
        public int UpdateTeacher(Teacher teacher)
        {
            _dbContext.Teachers.Update(teacher);
            return _dbContext.SaveChanges();
        }
        // task 7: lehessen módosítani
        public int UpdateSubject(Subject subject)
        {
            // task 9:  ha nem ad mega felhasználó semmilyen értéket, akkor a mező értéke az előbbiekben leírt alapértelmezett értéket kapja meg.
            if (subject.Description == null) 
            {
                subject.Description = "Ismeretlen";
            }
            _dbContext.Subjects.Update(subject);
            return _dbContext.SaveChanges();
        }
        // task 7: lehessen módosítani
        public int UpdateSemester(Semester semester)
        {
            _dbContext.Semesters.Update(semester);
            return _dbContext.SaveChanges();
        }
        // task 7: lehessen módosítani
        public int UpdateStudent(Student student)
        {
            _dbContext.Students.Update(student);
            return _dbContext.SaveChanges();
        }
        // task 7: lehessen logikailag törölni
        public int DeleteTeacher(int id)
        {
            Teacher teacher = _dbContext.Teachers.Find(id);
            teacher.Deleted = true;
            _dbContext.Teachers.Update(teacher);
            return _dbContext.SaveChanges();
        }
        // task 7: lehessen logikailag törölni
        public int DeleteSubject(int id)
        {
            Subject subject = _dbContext.Subjects.Find(id);
            subject.Deleted = true;
            _dbContext.Subjects.Update(subject);
            return _dbContext.SaveChanges();
        }
        // task 7: lehessen logikailag törölni
        public int DeleteSemester(int id)
        {
            Semester semester = _dbContext.Semesters.Find(id);
            semester.Deleted = true;
            _dbContext.Semesters.Update(semester);
            return _dbContext.SaveChanges();
        }
        // task 7: lehessen logikailag törölni
        public int DeleteStudent(int id)
        {
            Student student = _dbContext.Students.Find(id);
            student.Deleted = true;
            _dbContext.Students.Update(student);
            return _dbContext.SaveChanges();
        }
        // task 7: Készítse el továbbá a szükséges végpontokat ahhoz, hogy az adatok egymással összerendelhetőek legyenek.
        public int MapStudentSubject(int StudentId, int SubjectId)
        {
            return 0;
        }
        // task 7: Készítse el továbbá a szükséges végpontokat ahhoz, hogy az adatok egymással összerendelhetőek legyenek.
        public int MapSubjectTeacher(int SubjectId, int TeacherId)
        {
            return 0;
        }
        // task 10: Lehessen lekérni az oktató által adott félévben oktatott összes hallgató listáját.
        // A listában legyen benne a hallgató neve, Neptun kódja és hogy az oktató melyik tantárgyán oktatja őt.
        // A lista a tantárgykódok és a hallgatók neve alapján legyen növekvő sorrendbe rendezve.
        // A listában legyen benne minden adat, beleértve a törölteket is.

        public List<string> ListStudentsOfTeachers(int teacherId, int SemesterId)
        {
            Teacher teacher = _dbContext.Teachers.Find(teacherId);

            List<Subject> subjects_of_teacher = _dbContext.Subjects
                .Where(t => t.Teachers.Contains(teacher))
                .Include(s => s.Students)
                .Where(t => t.SemesterId == SemesterId)
                .IgnoreQueryFilters() // A listában legyen benne minden adat, beleértve a törölteket is.
                .ToList();

            List<int> student_ids =  new List<int>();
            SortedDictionary<int, string> student_subject_mapping = new SortedDictionary<int, string>();
            int idx = 0;

            foreach(Subject subject in subjects_of_teacher)
            {
                foreach(Student student in subject.Students)
                {
                    if (!student_subject_mapping.ContainsKey(student.StudentId + idx))
                    {
                        student_ids.Add(student.StudentId);
                        int key = student.StudentId + idx;
                        student_subject_mapping.Add(key, subject.Name);
                        idx++;
                    }
                }
            }

            List<string> strings = new List<string>();

            List<Student> all_students = _dbContext.Students.ToList();

            List<Student> filtered_students = new List<Student>();

            idx = 0;

            foreach(Student student in all_students)
            {
                foreach(int i in student_ids)
                {
                    if (student.StudentId == i)
                    {
                        int key = i + idx;
                        filtered_students.Add(student);
                        // A listában legyen benne a hallgató neve, Neptun kódja és hogy az oktató melyik tantárgyán oktatja őt.
                        strings.Add("Name: " + student.Name + ", Neptun code: " + student.NeptunCode + ", Subject: " + student_subject_mapping[key]);
                        idx++;
                    }
                }
            }
            // A lista a tantárgykódok és a hallgatók neve alapján legyen növekvő sorrendbe rendezve.
            strings.Sort();

            return strings;
        }
        // task 11: Lehessen lekérni, egy listát, amely tartalmazza, hogy megadott félévben a megadott oktató
        // összesen mennyi kreditértékű tantárgyat oktatott és összesen hány hallgató volt ezeken a
        // tantárgyakon(egy hallgató csak egyszer legyen összeszámolva, hiába oktatta több tárgyon is az oktató).
        public string ListCreditsAndStudentsOfTeachers(int teacherId, int SemesterId)
        {
            Teacher teacher = _dbContext.Teachers.Find(teacherId);

            List<Subject> subjects_of_teacher = _dbContext.Subjects
                .Where(t => t.Teachers.Contains(teacher))
                .Include(s => s.Students)
                .Where(t => t.SemesterId == SemesterId)
                //.IgnoreQueryFilters() // A listában legyen benne minden adat, beleértve a törölteket is.
                .ToList();

            List<int> student_ids = new List<int>();
            SortedDictionary<int, string> student_subject_mapping = new SortedDictionary<int, string>();
            
            int student_counter = 0;
            int credit_counter = 0;

            foreach (Subject subject in subjects_of_teacher)
            {
                foreach (Student student in subject.Students)
                {
                    if (!student_subject_mapping.ContainsKey(student.StudentId))
                    {
                        student_ids.Add(student.StudentId);
                        int key = student.StudentId;
                        student_subject_mapping.Add(key, subject.Name);
                        student_counter++;
                    }
                }
                credit_counter += subject.Credit;
            }

            string return_value = "Teacher name: " + teacher.Name + ", Student counter: " + student_counter + ", Sum of credits: " + credit_counter;

            return return_value;
        }
    }
}
