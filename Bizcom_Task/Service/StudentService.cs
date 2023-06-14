using Bizcom_Task.Entities.DTO.Student;
using Bizcom_Task.Entities.Model;
using Bizcom_Task.Entities.ModelView;
using Bizcom_Task.Exceptions;
using Bizcom_Task.Repository.RepositoryContract;
using Bizcom_Task.Service.ServiceContract;
using Entities.Exceptions;
using Mapster;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Bizcom_Task.Service
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        public async Task<StudentDTO> AddStudent(CreateStudentDTO createStudent)
        {
            var student = createStudent.Adapt<Student>();
            student.StudentStatus = Entities.Model.Enum.EStudentStatus.Registred;
            student.StudentRegNumber = Guid.NewGuid();
            await studentRepository.CreateStudent(student);

            if (student is null)
                throw new EntityNullException<Student>();


            student.StudentSubjects = new List<StudentSubject>();
            student.StudentTeachers = new List<StudentTeacher>();

            foreach (var stsubject in createStudent.StudentSubjectDTOs)
            {
                var studentsubject = new StudentSubject()
                {
                    subjectId = stsubject.subjectId,
                    studentId = student.Id,
                };
                student.StudentSubjects.Add(studentsubject);

            }

            foreach (var stteacher in createStudent.TeacherSubjectDTOs)
            {
                var studentteacher = new StudentTeacher()
                {
                    teacherId = stteacher.teacherId,
                    studentId = student.Id,
                };
                student.StudentTeachers.Add(studentteacher);
            }
            try
            {
                await studentRepository.UpdateStudent(student);
            }
            catch (DbUpdateException ex)
            {
                var innerException = ex.InnerException;

                // Xatoni olish
                var sqliteException = innerException as SqliteException;
                if (sqliteException != null)
                {
                    var errorCode = sqliteException.SqliteErrorCode;
                    var errorMessage = sqliteException.Message;

                    // Xatoni xususiyatlarga qo'shing yoki uni chiqaring
                    // Misol uchun:
                    Console.WriteLine($"SQLite Error Code: {errorCode}");
                    Console.WriteLine($"SQLite Error Message: {errorMessage}");
                }
            }

            return student.Adapt<StudentDTO>();
        }

        public async Task DeleteStudent(int studentId)
        {
            var student = await studentRepository.GetStudentById(studentId);
            if (student is null)
                throw new EntityNotFoundException<Student>();
            await studentRepository.DeleteStudent(student);
        }

        public async Task<List<StudentDTO>> GetAllStudents()
        {
            var students = await studentRepository.GetAllStudents();
            if (students is null)
                new List<StudentDTO>();

            return students.Adapt<List<StudentDTO>>();
        }

        public async Task<StudentDTO> GetStudentById(int studentId)
        {
            var student = await studentRepository.GetStudentById(studentId);
            if (student is null)
                throw new EntityNotFoundException<Student>();
            return student.Adapt<StudentDTO>();
        }

        public async Task<StudentDTO> GetStudentByName(string studentName)
        {
            var student = await studentRepository.GetStudentByName(studentName);
            if (student is null)
                throw new EntityNotFoundException<Student>();
            return student.Adapt<StudentDTO>();
        }

        public async Task UpdateStudent(int studentId, UpdateStudentDTO studentDTO)
        {
            var student = await studentRepository.GetStudentById(studentId);
            if (student is null)
                throw new EntityNotFoundException<Student>();

            await studentRepository.UpdateStudent(student);
        }
    }
}
