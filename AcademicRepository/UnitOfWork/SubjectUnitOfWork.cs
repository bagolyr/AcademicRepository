using Microsoft.EntityFrameworkCore;
using _2022_09_23.Entities.DbContextNamespace;
using _2022_09_23.Entities;
using System.Collections.Generic;

namespace _2022_09_23.UnitOfWork
{
    public class SubjectUnitOfWork: UnitOfWork, ISubjectUnitOfWork
    {
        public SubjectUnitOfWork(Academic3DbContext academicAPIDbContext) : base(academicAPIDbContext)
        {
        }

        //task 13: Készítsen UnitOfWorköt a tantárgyakhoz, a UnitOfWorkön keresztül legyen lehetőség lekérni tantárgyakat időintervallum alapján.
        //Ezt a félévek kezdő és végdátuma alapján határozza meg olyan módon, hogy ha a megadott intervallum belelóg bármennyire is a félévbe,
        //akkor annak a félévnek a tantárgyai már beleszámítanak a keresésbe.
        public List<Subject> GetSubjectsByTimeInterval(string from, string to)
        {
            List<Subject> return_val = new List<Subject>(); 

            int year_from   = Int32.Parse(from.Split(".")[0]);
            int month_from  = Int32.Parse(from.Split(".")[1]);
            int day_from    = Int32.Parse(from.Split(".")[2]);

            DateTime param_from = new DateTime(year_from, month_from, day_from);

            int year_to     = Int32.Parse(to.Split(".")[0]);
            int month_to    = Int32.Parse(to.Split(".")[1]);
            int day_to      = Int32.Parse(to.Split(".")[2]);

            DateTime param_to = new DateTime(year_to, month_to, day_to);

            List<Subject> subjects = GetDbSet<Subject>().Include(s => s.Semester).ToList();

            foreach (Subject subject in subjects)
            {
                Semester semester = GetDbSet<Semester>().Find(subject.SemesterId);

                int semester_year_from = Int32.Parse(semester.StartDate.Split(".")[0]);
                int semester_month_from = Int32.Parse(semester.StartDate.Split(".")[1]);
                int semester_day_from = Int32.Parse(semester.StartDate.Split(".")[2]);

                DateTime db_from = new DateTime(semester_year_from, semester_month_from, semester_day_from);

                int semester_year_to = Int32.Parse(semester.EndDate.Split(".")[0]);
                int semester_month_to = Int32.Parse(semester.EndDate.Split(".")[1]);
                int semester_day_to = Int32.Parse(semester.EndDate.Split(".")[2]);

                DateTime db_to = new DateTime(semester_year_to, semester_month_to, semester_day_to);

                if ((db_from <= param_from && param_from <= db_to)  // param_from is in between the range
                    || (db_from <= param_to && param_to <= db_to)   // param_to is in between the range
                    )
                {
                    return_val.Add(subject);
                }
            }

            return return_val;
        }
    }
}
