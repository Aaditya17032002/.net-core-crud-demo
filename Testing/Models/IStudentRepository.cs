namespace Testing.Models
{
    public interface IStudentRepository
    {
        Student GetStudentById(int StudentId);
        IEnumerable<Student> GetAllStudentByBranch(string Branch);
        Student UpdateStudentNameById(int StudentId, string newName, string newBranch);
        bool DeleteStudentById(int studentId);
    }
}
