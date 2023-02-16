using ListSmarter;
using ListSmarter.Services;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using ListSmarter.Repositories;
using FluentValidation;
using ListSmarter.validators;
namespace ListSmarter.ConsoleUI{


    class Program{


        static void Main(){
            var serviceProvider = CreateServiceProvider();
            var personService = serviceProvider.GetService<IPersonService>();
            var personController = new PersonController(personService ?? throw new Exception("Failed to resolve IPersonService from the service provider."));
            ShowMenu(personController);
            
            
        }
        static IServiceProvider CreateServiceProvider(){
            var services = new ServiceCollection();
            services.AddSingleton<IPersonRepository, PersonRepository>();
            services.AddSingleton<IPersonService,PersonService>();
            services.AddSingleton<IValidator<PersonDto>,PersonValidator>();
            services.AddAutoMapper(typeof(DtoProfiles));
            return services.BuildServiceProvider();
        }


        public static void ShowMenu(PersonController personController){
            while(true){
                Console.Clear();
                Console.WriteLine("ListSmarter Console Menu");
                Console.WriteLine("1. List all users");
                Console.WriteLine("2. List all buckets");
                Console.WriteLine("3. List all tasks");
                Console.WriteLine("4. Create new user");
                Console.WriteLine("5. Edit user");
                Console.WriteLine("6. Delete user");
                Console.WriteLine("7. Create new bucket");
                Console.WriteLine("8. Edit bucket");
                Console.WriteLine("9. Delete bucket");
                Console.WriteLine("10. Create new task");
                Console.WriteLine("11. Edit task");
                Console.WriteLine("12. Update task status");
                Console.WriteLine("13. Delete task");
                Console.WriteLine("0. Exit");
                Console.Write("\n\nEnter your choice: ");

                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("+" + new string('-', 3 * 8) + "+");
                        personController.getAllPeople().ForEach(prsn=>{
                        Console.WriteLine("| "+prsn.Id+" | "+prsn.FirstName+" | "+prsn.LastName+" |");
                        Console.WriteLine("+" + new string('-', 3 * 8) + "+");
                        });
                        Console.ReadKey();
                        
                    break;
                    case "4":
                        Console.WriteLine("Enter firstname and Last name");
                        int UsersCount = personController.getAllPeople().Count;
                        var firstName = Console.ReadLine();
                        var LastName = Console.ReadLine();
                        personController.createPeople(new PersonDto(){Id=UsersCount+1,FirstName=firstName,LastName=LastName});
                        Console.WriteLine("New user was Added Press any key to go to main menu");
                        Console.ReadKey();
                        break;
                    case "5":
                        Console.WriteLine("Enter user Id");
                        var input1= Console.ReadLine();
                        int Id1 = Int32.Parse(input1);
                        Console.WriteLine("Enter first name and last name");
                        personController.UpdatePerson(Id1,new PersonDto(){FirstName=Console.ReadLine(),LastName=Console.ReadLine()});
                    break;
                    case "6":
                        Console.WriteLine("Enter users Id");
                        var input= Console.ReadLine();
                        int Id = Int32.Parse(input);
                        personController.DeletePerson(Id);
                    break;
                    default:
                        Console.WriteLine("Invalid choice. Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
    

}