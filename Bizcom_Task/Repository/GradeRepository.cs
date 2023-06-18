using Bizcom_Task.Entities.Model;
using Bizcom_Task.Repository.RepositoryContract;
using Microsoft.EntityFrameworkCore;

namespace Bizcom_Task.Repository
{
    public class GradeRepository : IGradeRepository
    {
        private readonly AppDbContext context;

        public GradeRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task AddGrade(Grade grade)
        {
            context.Grades.Add(grade);
            await context.SaveChangesAsync();
        }

        public async Task DeleteGrade(Grade grade)
        {
            context.Grades.Remove(grade);
            await context.SaveChangesAsync();
        }

        public async Task<List<Grade>>? GetAllGrades()
        {
            var grades = await context.Grades.ToListAsync();
            return grades;
        }

        public async Task<Grade>? GetGrade(int studentId)
        {
            var grade = await context.Grades.FirstOrDefaultAsync(grade => grade.studentId == studentId);
            return grade;
        }

        public  bool IsThereStudentAndSubject(int studentId, int subjectId)
        {
          return (context.Students.Any(st => st.Id == studentId) && context.Students.Any(sub => sub.Id == subjectId));
        }

        public async Task UpdateGrade(Grade grade)
        {
            context.Grades.Update(grade);
            await context.SaveChangesAsync();
        }
    }
}
