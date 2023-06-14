using Bizcom_Task.Entities.DTO.Subject;
using Bizcom_Task.Entities.DTO.Teacher;
using Bizcom_Task.Entities.Model;
using Bizcom_Task.Entities.ModelView;
using Bizcom_Task.Repository.RepositoryContract;
using Bizcom_Task.Service.ServiceContract;
using Entities.Exceptions;
using Mapster;

namespace Bizcom_Task.Service
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository teacherRepository;

        public TeacherService(ITeacherRepository teacherRepository)
        {
            this.teacherRepository = teacherRepository;
        }

        public async Task<TeacherDTO> CreateTeacher(CreateTeacherDTO createTeacher)
        {
            var teacher = createTeacher.Adapt<Teacher>();
            teacher.TeacherStatus = Entities.Model.Enum.ETeacherStatus.Registred;
            await teacherRepository.CreateTeacher(teacher);
            teacher.TeacherSubjects ??= new List<TeacherSubject>();

            foreach (var tsubject in createTeacher.TeacherSubjectDTOs)
            {
                var teachersubject = new TeacherSubject()
                {
                    subjectId = tsubject.subjectId,
                };
                teacher.TeacherSubjects.Add(teachersubject);
            }
            await teacherRepository.UpdateTeacher(teacher);
            var teacherView = teacher.Adapt<TeacherDTO>();
            return teacherView;
        }

        public async Task DeleteTeacher(int teacherId)
        {
            var teacher = await teacherRepository.GetTeacherById(teacherId);
            if (teacher is null)
                throw new EntityNotFoundException<Teacher>();

            await teacherRepository.DeleteTeacher(teacher);
        }

        public async Task<List<TeacherDTO>> GetAllTeachers()
        {
            var teachers = await teacherRepository.GetAllTeachers();
            return teachers.Adapt<List<TeacherDTO>>();
        }

        public async Task<TeacherDTO> GetTeacherById(int teacherId)
        {
            var teacher = await teacherRepository.GetTeacherById(teacherId);
            if (teacher is null)
                throw new EntityNotFoundException<Teacher>();
            return teacher.Adapt<TeacherDTO>();
        }

        public async Task UpdateTeacher(int teacherId, UpdateTeacherDTO updateTeacher)
        {
            var teacher = await teacherRepository.GetTeacherById(teacherId);
            if (teacher is null)
                throw new EntityNotFoundException<Teacher>();

            var config = new TypeAdapterConfig();
            config.ForType<UpdateTeacherDTO, Teacher>()
                  .IgnoreNullValues(true)
                  .BeforeMapping((src, dest) =>
                  {
                      dest.Id = teacher.Id;
                      dest.Email = teacher.Email;
                      dest.Role = teacher.Role;
                  });

            var teacherUpdate = updateTeacher.Adapt(teacher, config);
            await teacherRepository.UpdateTeacher(teacher);
        }
    }
}
