// See https://aka.ms/new-console-template for more information
using WiredBrainCoffee.StorageApp.Data;
using WiredBrainCoffee.StorageApp.Entities;
using WiredBrainCoffee.StorageApp.Repositories;

//Action<Employee> itemAdded =EmployeeAdded;

var employeeRepository = new SqlRepository<Employee>(new StorageAppDbContext());
employeeRepository.ItemAdded += EmployeeRepository_ItemAdded;


AddEmployees(employeeRepository);
AddManagers(employeeRepository);

GetEmployeeById(employeeRepository);
WriteAllToConsole(employeeRepository);

var organisationRepository = new ListRepository<Orginisation>();
AddOrganisations(organisationRepository);
WriteAllToConsole(organisationRepository);

Console.ReadLine();

void EmployeeRepository_ItemAdded(object? sender, Employee e)
{
    Console.WriteLine($"Employee added => {e.FirstName}");
};

void WriteAllToConsole(IReadRepository<IEntity> repository)
{
    var items = repository.GetAll();
    foreach (var item in items)
    {
        Console.WriteLine(item);
    }
}
static void GetEmployeeById(IRepository<Employee> employeeRespository)
{
    var employee = employeeRespository.GetById(2);
    Console.WriteLine($"Employee with Id 2: {employee.FirstName}");
    employeeRespository.PrintNonsense();
}
 void AddEmployees(IRepository<Employee> employeeRespository)
{
    var employees = new[]
    {
        new Employee { FirstName = "Julia" },
        new Employee { FirstName = "Anna" },
        new Employee { FirstName = "Thomas" },
};
    //RepositoryExtensions.AddBatch<Employee>(employeeRepository, employees);//
    employeeRepository.AddBatch(employees);
    employeeRespository.Save();
}
static void AddManagers(IWriteRepository<Manager> managerRepository)
{
    var saraManager = new Manager { FirstName = "Sara" };
    var sareManagerCopy = saraManager.Copy();
    managerRepository.Add(saraManager);

    if(sareManagerCopy != null)
    {
        sareManagerCopy.FirstName += "_Copy";
        managerRepository.Add(sareManagerCopy);
    }
    managerRepository.Add(new Manager { FirstName = "Henry" });
    managerRepository.Save();

    static Manager SaraManager()
    {
        return new Manager { FirstName = "Sara" };
    }
}
static void AddOrganisations(IRepository<Orginisation> organisationRepository)
{
    var organisation = new[]
    {
        new Orginisation { Name = "Plural Sight" },
        new Orginisation { Name = "Globomantics" }
    };
    //RepositoryExtensions.AddBatch(organisationRepository, organisation);//before extension was created
    organisationRepository.AddBatch(organisation);
    organisationRepository.Save();
}
