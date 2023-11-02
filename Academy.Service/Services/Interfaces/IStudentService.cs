
using Academy.Core.Enums;

namespace Academy.Service.Services.Interfaces
{
    public interface IStudentService
    {
        public Task<string> CreateAsync(string fullName, string group, double average, StudentEducation studentEducation);
        public Task<string> UptadedAsync(string fullName, string group, double average, StudentEducation studentEducation);
        public Task<string> RemoveAsync(string id);
        public Task GetAsync(string id);
        public Task<string> GetAllAsync();

    }
}
