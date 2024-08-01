using System.Collections.Generic;

namespace JsonFileConsoleApp.Models;
public class Company
{
    public string Name { get; set; } = string.Empty;
    public List<Employee> Employees { get; set; } 
}
