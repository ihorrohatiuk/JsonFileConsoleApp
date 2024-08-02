using System;
using System.Threading.Tasks;
using JsonFileConsoleApp.Models;
using JsonFileConsoleApp.Services;

namespace JsonFileConsoleApp;

public class Program
{
    static void Main(string[] args)
    {
        var company = GetCompanyFromJsonAsync().Result;

        DisplayService.DisplayCompanyInfo(company);
        DisplayService.DisplayEmployees(company.Employees);
    }

    static async Task<Company> GetCompanyFromJsonAsync()
    {
        Company company;
        var parseService = new ParseService("../../../employees.json");

        try
        {
            company = await parseService.ReadEmployeesFromJsonToListAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return company;
    }
}
