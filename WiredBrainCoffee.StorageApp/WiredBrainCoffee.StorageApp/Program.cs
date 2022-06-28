// See https://aka.ms/new-console-template for more information
using WiredBrainCoffee.StorageApp.Entities;
using WiredBrainCoffee.StorageApp.Repositories;

var employeeRespository = new ListRepository<Employee>();
AddEmployees(employeeRespository);
GetEmployeeBiId(employeeRespository);

void GetEmployeeBiId(ListRepository<Employee> employeeRespository)
{
    var employee = employeeRespository.GetById(2);
    Console.WriteLine($"Employee with Id 2: {employee.FirstName}");
}

var organisationRepository = new ListRepository<Orginisation>();
AddOrganisations(organisationRepository);

Console.ReadLine();

static void AddOrganisations(ListRepository<Orginisation> organisationRepository)
{
    organisationRepository.Add(new Orginisation { Name = "Plural Sight" });
    organisationRepository.Add(new Orginisation { Name = "Globomantics" });
    organisationRepository.Save();
}

static void AddEmployees(ListRepository<Employee> employeeRespository)
{
    employeeRespository.Add(new Employee { FirstName = "Julia" });
    employeeRespository.Add(new Employee { FirstName = "Anna" });
    employeeRespository.Add(new Employee { FirstName = "Thomas" });
    employeeRespository.Save();
}