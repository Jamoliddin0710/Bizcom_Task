using Bizcom_Task.Entities.Model;
using Bizcom_Task.Repository.RepositoryContract;
using Microsoft.EntityFrameworkCore;

namespace Bizcom_Task.Repository
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly AppDbContext _context;

        public SubjectRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateSubject(Subject subject)
        {
            _context.Subjects.Add(subject);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSubject(Subject subject)
        {
            _context.Subjects.Remove(subject);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Subject>> GetAllSubjects()
        {
            var subjects = _context.Subjects.ToList();
            return subjects;
        }

        public async Task<Subject> GetSubjectById(int subjectId)
        {
            var subject = await _context.Subjects.FirstOrDefaultAsync(subject => subject.Id == subjectId);
            return subject;
        }

        public async Task UpdateSubject(Subject subject)
        {
            _context.Subjects.Update(subject);
            await _context.SaveChangesAsync();
        }
    }
}
