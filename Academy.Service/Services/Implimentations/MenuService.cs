
using Academy.Service.Services.Interfaces;

namespace Academy.Service.Services.Implimentations
{
    public class MenuService
    {
        IStudentService studentservice = new StudentService();

        public async Task RunApp() 
        {
            Menu();
            void Menu()
            {
                Console.WriteLine("1-Create");
                Console.WriteLine("2-Uptaded");
                Console.WriteLine("3-Remove");
                Console.WriteLine("4-GetAll");
                Console.WriteLine("5-Get");
                Console.WriteLine("0-close");

            }
            string request = Console.ReadLine();

            while (request != "0")
            {
                switch (request)
                {
                    case "1":
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "4":
                        break;
                    case "5":
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
