using Bizcom_Task.Repository;
using Bizcom_Task.Repository.RepositoryContract;
using Bizcom_Task.Service;
using Bizcom_Task.Service.ServiceContract;

namespace Bizcom_Task.Extensions
{
    public static class ServiceExtension
    {
        public static void ConfigurationRepository(this IServiceCollection services)
        {
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<ITeacherRepository, TeacherRepository>();
            services.AddScoped<ISubjectRepository, SubjectRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }

        public static void ConfigurationServices(this IServiceCollection services)
        {
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<ISubjectService, SubjectService>();
            services.AddScoped<ITeacherService, TeacherService>();
            services.AddScoped<IUserService, UserService>();
        }

    }
}
