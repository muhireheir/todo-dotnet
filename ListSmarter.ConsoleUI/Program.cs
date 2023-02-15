using ListSmarter;
using ListSmarter.Services;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using ListSmarter.Repositories;
namespace ListSmarter.ConsoleUI{


    class Program{


        static void Main(){
            var serviceProvider = CreateServiceProvider();
            var personService = serviceProvider.GetService<IPersonService>();
            var personController = new PersonController(personService ?? throw new Exception("Failed to resolve IPersonService from the service provider."));
            personController.getAllPeople().ForEach(prsn=>{
                Console.WriteLine(prsn.FirstName);
            });
        }
        static IServiceProvider CreateServiceProvider(){
            var services = new ServiceCollection();
            services.AddSingleton<IPersonRepository, PersonRepository>();
            services.AddSingleton<IPersonService,PersonService>();
            services.AddAutoMapper(typeof(DtoProfiles));
            return services.BuildServiceProvider();
        }
    }
    

}