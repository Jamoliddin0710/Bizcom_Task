using Bizcom_Task.Entities.Model;
using Bizcom_Task.Entities.ModelView;
using Bizcom_Task.Exceptions;
using Entities.Exceptions;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Bizcom_Task.Service.ServiceContract
{
    public class StatisticsService : IStatisticsService
    {
        private readonly AppDbContext context;

        public StatisticsService(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<List<StudentDTO>> GetStudentAgeTo20()
        {
            var students = await context.Students.ToListAsync();
            var curentStudents = students.Where(student => AgeComparewith20(student.DateOfBirth)).ToList();
            if (curentStudents is null)
                new List<StudentDTO>();
            return curentStudents.Adapt<List<StudentDTO>>();
        }

        public async Task<List<SubjectDTO>> GetAllStudentSubjectMaxScore(int studentId)
        {
            throw new NotImplementedException();
        }

        //12-avgustdan 18-sentabrgacha tug'ilgan talabalar
        public async Task<List<StudentDTO>> GetStudentFrom12To18()
        {
            var students = await context.Students.ToListAsync();
            var curentStudents = students.Where(student => From12AugustTo18September(student.DateOfBirth)).ToList();
            if (curentStudents is null)
                new List<StudentDTO>();
            return curentStudents.Adapt<List<StudentDTO>>();
        }

        public async Task<List<StudentDTO>> GetStudentByName(string name)
        {
            var students = await context.Students.ToListAsync();
            if (students is null)
                throw new EntityNullException<Student>();
            var currentStudents = students.Where(st => st.FirstName.Contains(name)  || st.LastName.Contains(name));
            if (currentStudents is null)
                new List<StudentDTO>();
            return currentStudents.Adapt<List<StudentDTO>>();
        }

        public async Task<List<TeacherDTO>> GetTeacherFrom55()
        {
            var teachers = await context.Teachers.ToListAsync();
            var currentTeachers = teachers.Where(teacher => AgeComparewithWith55(teacher.BirthDate));
            return currentTeachers.Adapt<List<TeacherDTO>>();
        }

        public async Task<Tuple<List<StudentDTO>, List<TeacherDTO>>>? GetBeelinUser()
        {
            var students = await context.Students.ToListAsync();
            var teachers = await context.Teachers.ToListAsync();

            var beelineStudent = students.Where(student => student.Phone.StartsWith("90") || student.Phone.StartsWith("91")).Adapt<List<StudentDTO>>();
            var beelineTeacher = teachers.Where(teacher => teacher.Phone.StartsWith("90") || teacher.Phone.StartsWith("91")).Adapt<List<TeacherDTO>>();

            var beelineUsers = await Task.FromResult(new Tuple<List<StudentDTO>, List<TeacherDTO>>(beelineStudent, beelineTeacher));
            return beelineUsers;

        }


        public async Task<List<SubjectDTO>> GetStudentMaxScore10(int teacherId)
        {
            try
            {
                var teacher = await context.Teachers.FirstOrDefaultAsync(teacher => teacher.Id == teacherId);
                if (teacher is null)
                    throw new EntityNotFoundException<Teacher>();

                var grades = teacher.Grades.Where(gr => gr.Score > 80).Take(10).ToList();
                var subjectIds = grades.Select(gr => gr.subjectId).ToList();
                var CurrentSubjects = context.Subjects.Where(sub => subjectIds.Contains(sub.Id)).ToList();
                return CurrentSubjects.Adapt<List<SubjectDTO>>();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<TeacherDTO>> GetTeacherByMaxScoreFrom97()
        {
            var grades = context.Grades.Where(st => st.Score > 97);
            if (grades.Any())
                return new List<TeacherDTO>();

            var teacherIds = grades.Select(gr => gr.teacherId).ToList();
            var teachers = await context.Teachers.Where(teacher => teacherIds.Contains(teacher.Id)).ToListAsync();
            if (teachers.Any())
                return new List<TeacherDTO>();

            return teachers.Adapt<List<TeacherDTO>>();
        }


        public async Task<SubjectDTO> GetSubjectStudentBall(int studentId)
        {
            try
            {
                var maxScoreSubjectId = MaxScoreSubjectId(context.Grades.Where(gr => gr.studentId == studentId).ToList());
                var subject = await context.Subjects.FirstOrDefaultAsync(sub => sub.Id == maxScoreSubjectId);
                return subject.Adapt<SubjectDTO>();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private bool AgeComparewith20(DateTime DateOfBirth)
        {
            int age = DateTime.Now.Year - DateOfBirth.Year;
            if (DateTime.Now.Month < DateOfBirth.Month || (DateTime.Now.Month == DateOfBirth.Month && DateTime.Now.Day < DateOfBirth.Day))
            {
                age--; // Agar tug'ilgan kun boshlang'ichidan keyin bo'lsa, yoshni 1 taga kamaytiramiz
            }
            return age < 20;
        }

        private bool AgeComparewithWith55(DateTime DateOfBirth)
        {
            int age = DateTime.Now.Year - DateOfBirth.Year;
            if (DateTime.Now.Month < DateOfBirth.Month || (DateTime.Now.Month == DateOfBirth.Month && DateTime.Now.Day < DateOfBirth.Day))
            {
                age--; // Agar tug'ilgan kun boshlang'ichidan keyin bo'lsa, yoshni 1 taga kamaytiramiz
            }
            return age > 55;
        }

        private bool From12AugustTo18September(DateTime DateOfBirth)
        {
            var month = DateOfBirth.Month;
            var day = DateOfBirth.Day;
            if (month == 8)
            {
                if (day >= 12)
                    return true;
            }
            else if (month == 9)
            {
                if (day <= 18)
                    return true;
            }
            return false;
        }

        private int MaxScoreSubjectId(List<Grade> grades)
        {
            Decimal maxScore = Decimal.MinValue;
            int maxScoreSubjectId = 1;
            foreach (var grade in grades)
            {
                if (grade.Score > maxScore)
                {
                    maxScore = grade.Score;
                    maxScoreSubjectId = grade.subjectId;
                }
            }
            return maxScoreSubjectId;
        }

        public async Task<SubjectDTO> GetSubjectByStudentMaxBall(int studentId)
        {
            var student = await context.Students.FirstOrDefaultAsync(st => st.Id == studentId);
            if (student is null)
                throw new EntityNotFoundException<Student>();

            var maxScore = student.Grades.Max(g => g.Score);

            int? maxScoresubjectId = student.Grades.First(gr => gr.Score == maxScore).subjectId;

            if (maxScoresubjectId is null)
                throw new Exception("max Score is not found");

            var subject = context.Subjects.Find(maxScoresubjectId);
            if (subject is null)
                throw new Exception($"{maxScoresubjectId} is not found");
            return subject.Adapt<SubjectDTO>();
        }
    }
}
