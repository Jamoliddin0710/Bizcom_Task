using Bizcom_Task.Entities.Model;
using Bizcom_Task.Repository.RepositoryContract;
using Microsoft.EntityFrameworkCore;

namespace Bizcom_Task.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _context;

        public StudentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateStudent(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();

        }

        public async Task DeleteStudent(Student student)
        {
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Student>>? GetAllStudents()
        {
            var students = _context.Students.ToList();
            return students;
        }

        public async Task<Student>? GetStudentById(int studentId)
        {
            var student = await _context.Students.FirstOrDefaultAsync(student => student.Id == studentId);
            return student;
        }

        public async Task<Student>? GetStudentByName(string studentName)
        {
            var student = await _context.Students.FirstOrDefaultAsync(student => student.FirstName.Equals(studentName));
            return student;
        }

        public async Task UpdateStudent(Student student)
        {
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
        }
    }
}
