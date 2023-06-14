using Bizcom_Task.Entities.Model;
using Bizcom_Task.Repository.RepositoryContract;
using Microsoft.EntityFrameworkCore;

namespace Bizcom_Task.Repository
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly AppDbContext _appDbContext;

        public TeacherRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task CreateTeacher(Teacher teacher)
        {
            _appDbContext.Teachers.Add(teacher);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteTeacher(Teacher teacher)
        {
            _appDbContext.Teachers.Remove(teacher);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<List<Teacher>> GetAllTeachers()
        {
            var teachers = await _appDbContext.Teachers.ToListAsync();
            return teachers;
        }

        public async Task<Teacher> GetTeacherById(int teacherId)
        {
            var teacher = _appDbContext.Teachers.FirstOrDefault(teacher => teacher.Id == teacherId);
            return teacher;
        }

        public async Task UpdateTeacher(Teacher teacher)
        {
            _appDbContext.Teachers.Update(teacher);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
