
using Academy.Core.Enums;
using Academy.Service.Services.Interfaces;

namespace Academy.Service.Services.Implimentations
{
    public class MenuService
    {
        IStudentService studentservice = new StudentService();
        public async Task RunApp() 
        {
           await Menu();
            string request = Console.ReadLine(); 
            async Task Menu()
            {
                Console.WriteLine("1-Create");
                Console.WriteLine("2-Uptaded");
                Console.WriteLine("3-Remove");
                Console.WriteLine("4-GetAll");
                Console.WriteLine("5-Get");
                Console.WriteLine("0-close");
            }

            while (request != "0")
            {
                switch (request)
                {
                    case "1":
                        await CreatStudent();
                        break;
                    case "2":
                        await UpdateStudent();
                        break;
                    case "3":
                        await RemoveAsync();
                        break;
                    case "4":
                        await GetAllAsync();
                        break;
                    case "5":
                        await GetAsync();
                        break;
                    default:
                        Console.WriteLine("enter correct value!");
                        break;
                }
                await Menu();
                request = Console.ReadLine();
            }
        }
        async Task CreatStudent()
        {
            Console.WriteLine("Add FullName:");
            string FullName = Console.ReadLine();
            Console.WriteLine("Add Group:");
            string Group = Console.ReadLine();
            Console.WriteLine("Add Average:");
            double.TryParse(Console.ReadLine(), out double Average);
            int i = 1;
            foreach (var item in Enum.GetValues(typeof(StudentEducation)))
            {
                Console.WriteLine($"{i}-{item}");
                i++;
            }
            bool isExsist;
            int EnumIndex;
            do
            {
                Console.WriteLine("Choose StudentEducation:");
                int.TryParse(Console.ReadLine(), out EnumIndex);
                isExsist = Enum.IsDefined(typeof(StudentEducation),(StudentEducation)EnumIndex);
            }
            while (!isExsist);

            string result = await studentservice.CreateAsync(FullName, Group, Average, (StudentEducation)EnumIndex);
            Console.WriteLine(result);
        }
        async Task UpdateStudent()
        {
            Console.WriteLine("Add id:");
            string Id = Console.ReadLine();
            Console.WriteLine("Add FullName:");
            string FullName = Console.ReadLine();
            Console.WriteLine("Add Group:");
            string Group = Console.ReadLine();
            Console.WriteLine("Add Average:");
            double.TryParse(Console.ReadLine(), out double Average);
            int i = 1;
            foreach (var item in Enum.GetValues(typeof(StudentEducation)))
            {
                Console.WriteLine($"{i}-{item}");
                i++;
            }
            bool isExsist;
            int EnumIndex;
            do
            {
                Console.WriteLine("Add StudentEducation:");
                int.TryParse(Console.ReadLine(), out EnumIndex);
                isExsist = Enum.IsDefined(typeof(StudentEducation), (StudentEducation)EnumIndex);
            }
            while (!isExsist);

          string result =  await studentservice.UptadedAsync(Id, FullName, Group, Average, (StudentEducation)EnumIndex);
            Console.WriteLine(result);
        }
        async Task RemoveAsync()
        {
            Console.WriteLine("Add id:");
            string Id = Console.ReadLine();
            string result = await studentservice.RemoveAsync(Id);
            Console.WriteLine(result);
        }
        async Task GetAllAsync()
        {
            await studentservice.GetAllAsync();
        }
        async Task GetAsync()
        {
            Console.WriteLine("Add id:");
            string Id = Console.ReadLine();
            string result = await studentservice.GetAsync(Id);
            Console.WriteLine(result);
        }
    }
}