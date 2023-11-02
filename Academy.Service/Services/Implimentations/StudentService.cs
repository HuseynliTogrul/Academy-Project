
using Academy.Core.Enums;
using Academy.Core.Models;
using Academy.Core.Repositories;
using Academy.Data.Repositoies;
using Academy.Service.Services.Interfaces;

namespace Academy.Service.Services.Implimentations
{
    public class StudentService : IStudentService
    {
        IStudentRepository _studentRepository = new StudentRepository();
        public async Task<string> CreateAsync(string fullName, string group, double average, StudentEducation studentEducation)
        {
            if (string.IsNullOrWhiteSpace(fullName))
            {
                return "fullname bos ola bilmez!";
            }
            if (string.IsNullOrWhiteSpace(group))
            {
                return "group bos ola bilmez!";
            }
            if (average < 0)
            {
                return "0-dan kicik ola bilmez!";
            }

            Student student = new Student(fullName, group, average, studentEducation);
            await _studentRepository.AddAsync(student);
            return "Successfully Create :)";
        }

        public async Task GetAllAsync()
        {
            List<Student> students = await _studentRepository.GetAllAsync();

            foreach (Student student in students)
            {
                Console.WriteLine($"Id:{student.Id},fullname:{student.FullName},average:{student.Average},studentEducation:{student.StudentEducation},create:{student.CreatAt},update:{student.UpdateAt}");
            }
        }

        public async Task<string> GetAsync(string id)
        {
            Student student = await _studentRepository.GetAsync(x=>x.Id==id);
            if(student==null)
            {
                Console.WriteLine("Student not to found!");
            }

            Console.WriteLine($"Id:{student.Id},fullname:{student.FullName},average:{student.Average},studentEducation:{student.StudentEducation},create:{student.CreatAt},update:{student.UpdateAt}");
            return "successfull";
        }

        public async Task<string> RemoveAsync(string id)
        {
            Student student = await _studentRepository.GetAsync(x => x.Id == id);
            if (student == null)
            {
                Console.WriteLine("Student not to found!");
            }

            await _studentRepository.RemoveAsync(student);
            return "successfull";
        }

        public async Task<string> UptadedAsync(string id,string fullName, string group, double average, StudentEducation studentEducation)
        {
            Student student = await _studentRepository.GetAsync(x => x.Id == id);
            if (student == null)
            {
                Console.WriteLine("Student not to found!");
            }
            student.FullName = fullName;
            student.Group = group;
            student.Average = average;
            student.UpdateAt= DateTime.UtcNow.AddHours(4);
            return "successfully";
        }
    }
}
