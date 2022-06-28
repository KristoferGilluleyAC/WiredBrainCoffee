// See https://aka.ms/new-console-template for more information
using WiredBrainCoffee.StorageApp.Data;
using WiredBrainCoffee.StorageApp.Entities;
using WiredBrainCoffee.StorageApp.Repositories;

//var employeeRespository = new ListRepository<Employee>();
var employeeRepository = new SqlRepository<Employee>(new StorageAppDbContext());
AddEmployees(employeeRepository);
GetEmployeeById(employeeRepository);
WriteAllToConsole(employeeRepository);

void WriteAllToConsole(IRepository<Employee> employeeRepository)
{
    var items = employeeRepository.GetAll();
    foreach (var item in items)
    {
        Console.WriteLine(item);
    }
}

static void GetEmployeeById(IRepository<Employee> employeeRespository)
{
    var employee = employeeRespository.GetById(2);
    Console.WriteLine($"Employee with Id 2: {employee.FirstName}");
}

var organisationRepository = new ListRepository<Orginisation>();
AddOrganisations(organisationRepository);

Console.ReadLine();

static void AddEmployees(IRepository<Employee> employeeRespository)
{
    employeeRespository.Add(new Employee { FirstName = "Julia" });
    employeeRespository.Add(new Employee { FirstName = "Anna" });
    employeeRespository.Add(new Employee { FirstName = "Thomas" });
    employeeRespository.Save();
}

static void AddOrganisations(IRepository<Orginisation> organisationRepository)
{
    organisationRepository.Add(new Orginisation { Name = "Plural Sight" });
    organisationRepository.Add(new Orginisation { Name = "Globomantics" });
    organisationRepository.Save();
}