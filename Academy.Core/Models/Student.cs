
using Academy.Core.Enums;
using Academy.Core.Models.BaseModels;

namespace Academy.Core.Models
{
    public class Student : BaseModel
    {
        static int _id;
        public string FullName { get; set; }
        public string Group { get; set; }
        public double Average { get; set; }
        public StudentEducation StudentEducation { get; set; }

        public Student(string fullName, string group, double average, StudentEducation studentEducation)
        {
            
            
            FullName = fullName;
            Group = group;
            Average = average;
            StudentEducation = studentEducation;
            _id++;
            Id = $"{StudentEducation.ToString()[0]}-{_id}";
        }
    }
}
