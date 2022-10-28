using _2022_09_23.Entities;

namespace _2022_09_23.UnitOfWork
{
    public interface ISubjectUnitOfWork
    {
        List<Subject> GetSubjectsByTimeInterval(string from, string to);
    }
}