// Service class for data access
public class DataService
{
    private readonly DbContext _dbContext;

    public DataService(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IQueryable<Class> GetClassesWithMoreThan100Students()
    {
        return _dbContext.Classes
            .Where(c => _dbContext.Enrolled.Count(e => e.ClassId == c.Cid) > 100);
    }

    public IQueryable<Student> GetStudentsWithNoClassesInDepartment22()
    {
        var studentsInDept22 = _dbContext.Faculties
            .Where(f => f.Deptid == 22)
            .SelectMany(f => f.Classes)
            .SelectMany(c => c.Enrolled)
            .Select(e => e.Sid);

        return _dbContext.Students
            .Where(s => !studentsInDept22.Contains(s.Sid));
    }

    public IQueryable<Student> GetStudentsWithNoMarks()
    {
        return _dbContext.Students
            .Where(s => s.Enrolled.Any(e => !e.Marks.Any()));
    }

    public IQueryable<object> GetAverageAgeByMajor()
    {
        return _dbContext.Students
            .GroupBy(s => s.Major)
            .Select(g => new
            {
                Major = g.Key,
                AverageAge = g.Average(s => s.Standing)
            });
    }
}
