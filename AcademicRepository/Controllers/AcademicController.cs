using _2022_09_23.Entities;
using _2022_09_23.Services;
using Microsoft.AspNetCore.Mvc;

namespace _2022_09_23.Controllers
{
    [Route("api/[controller]/[action]")]
    public class AcademicController : Controller
    {
        private readonly IAcademicService _academicService;

        public AcademicController(IAcademicService academicService)
        {
            _academicService = academicService;
        }
        [HttpGet("{showDeleted?}")]
        public IActionResult subjects(string showDeleted) // task 4 Az alkalmazásban lehessen listázni az összes tantárgyat, oktatót, hallgatót, félévet külön-külön végpontokon.
        {
            return Ok(_academicService.ListSubjects(showDeleted));
        }
        [HttpGet("{showDeleted?}")]
        public IActionResult teachers(string showDeleted) // task 4 Az alkalmazásban lehessen listázni az összes tantárgyat, oktatót, hallgatót, félévet külön-külön végpontokon.
        {
            return Ok(_academicService.ListTeachers(showDeleted));
        }
        [HttpGet("{showDeleted?}")]
        public IActionResult students(string showDeleted) // task 4 Az alkalmazásban lehessen listázni az összes tantárgyat, oktatót, hallgatót, félévet külön-külön végpontokon.
        {
            return Ok(_academicService.ListStudents(showDeleted));
        }
        [HttpGet("{showDeleted?}")]
        public IActionResult semesters(string showDeleted) // task 4 Az alkalmazásban lehessen listázni az összes tantárgyat, oktatót, hallgatót, félévet külön-külön végpontokon.
        {
            return Ok(_academicService.ListSemesters(showDeleted));
        }

        [HttpGet("{NeptunCode}/{SemesterName}/{showDeleted?}")]
        public IActionResult teachers(string NeptunCode, string SemesterName, string showDeleted) // task 5: Lehessen lekérni egy oktató egy félévben oktatott összes tantárgyát
        {
            return Ok(_academicService.GetTeacherSubjectsByNeptunCodeAndSemester(NeptunCode, SemesterName, showDeleted));
        }

        [HttpGet("{NeptunCode}/{SemesterName}/{showDeleted?}")]
        public IActionResult students(string NeptunCode, string SemesterName, string showDeleted) // task 6: Lehessen lekérni egy hallgató egy félévben felvett összes tantárgyát.
        {
            return Ok(_academicService.GetStudentSubjectsByNeptunCodeAndSemester(NeptunCode, SemesterName, showDeleted));
        }

        [HttpPost]
        public IActionResult createteacher([FromBody] Teacher teacher) // task 7: Lehessen új oktatót, tantárgyat, félévet és hallgatót felvinni a rendszerbe
        {
            return Ok(_academicService.CreateTeacher(teacher));
        }

        [HttpPost]
        public IActionResult createsubject([FromBody] Subject subject/*, string Description*/) // task 7, 9: Lehessen új oktatót, tantárgyat, félévet és hallgatót felvinni a rendszerbe
        {
            return Ok(_academicService.CreateSubject(subject));
        }

        [HttpPost]
        public IActionResult createsemester([FromBody] Semester semester) // task 7: Lehessen új oktatót, tantárgyat, félévet és hallgatót felvinni a rendszerbe
        {
            return Ok(_academicService.CreateSemester(semester));
        }

        [HttpPost]
        public IActionResult createstudent([FromBody] Student student) // task 7: Lehessen új oktatót, tantárgyat, félévet és hallgatót felvinni a rendszerbe
        {
            return Ok(_academicService.CreateStudent(student));
        }
        [HttpPost]
        public IActionResult updateteacher([FromBody] Teacher teacher) // task 7: lehessen módosítani
        {
            return Ok(_academicService.UpdateTeacher(teacher));
        }

        [HttpPost]
        public IActionResult updatesubject([FromBody] Subject subject) // task 7, 9: lehessen módosítani
        {
            return Ok(_academicService.UpdateSubject(subject));
        }

        [HttpPost]
        public IActionResult updatesemester([FromBody] Semester semester) // task 7: lehessen módosítani
        {
            return Ok(_academicService.UpdateSemester(semester));
        }

        [HttpPost]
        public IActionResult updatestudent([FromBody] Student student) // task 7: lehessen módosítani
        {
            return Ok(_academicService.UpdateStudent(student));
        }
        [HttpGet("{id}")]
        public IActionResult deleteteacher(int id) // task 7: lehessen logikailag törölni
        {
            return Ok(_academicService.DeleteTeacher(id));
        }
        [HttpGet("{id}")]
        public IActionResult deletesubject(int id) // task 7: lehessen logikailag törölni
        {
            return Ok(_academicService.DeleteSubject(id));
        }
        [HttpGet("{id}")]
        public IActionResult deletesemester(int id) // task 7: lehessen logikailag törölni
        {
            return Ok(_academicService.DeleteSemester(id));
        }
        [HttpGet("{id}")]
        public IActionResult deletestudent(int id) // task 7: lehessen logikailag törölni
        {
            return Ok(_academicService.DeleteStudent(id));
        }
        [HttpGet("{id}/{SemesterId}")]
        public IActionResult teacherstudents(int id, int SemesterId) // task 10: Lehessen lekérni az oktató által adott félévben oktatott összes hallgató listáját.
        {
            return Ok(_academicService.ListStudentsOfTeachers(id, SemesterId));
        }
        [HttpGet("{id}/{SemesterId}")]
        public IActionResult teachercreditsandstudents(int id, int SemesterId) // task 11: Lehessen lekérni, egy listát, amely tartalmazza, hogy megadott félévben a megadott oktató összesen mennyi kreditértékű tantárgyat oktatott és összesen hány hallgató volt ezeken a tantárgyakon(egy hallgató csak egyszer legyen összeszámolva, hiába oktatta több tárgyon is az oktató).
        {
            return Ok(_academicService.ListCreditsAndStudentsOfTeachers(id, SemesterId));
        }
    }
}
