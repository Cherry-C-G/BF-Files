public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Salary { get; set; }
}

[ApiController]
[Route("[controller]")]
public class EmployeeController : ControllerBase
{
   // private readonly List<Employee> _employee=new ;
    private readonly EmployeeDbContext _employeeDbContext;

    public EmployeeController(EmployeeDbContext employeeDbContext)
    {
        _employeeDbContext = employeeDbContext;
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var employee = _employeeDbContext.Employee.FindAsync(id);
        if (employee == null)
        {
            return NotFound();
        }
        return OK(employee);
    }

    [HttpPost]
    public IActionResult Create([FromBody]Employee employee)
    {
       
        _employeeDbContext.Employee.Add(employee);
        _employeeDbContext.SaveChanges();
        return CreateNewEmployee(employee);
    }
}


