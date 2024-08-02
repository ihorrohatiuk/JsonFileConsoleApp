using System;
using System.IO;
using System.Threading.Tasks;
using JsonFileConsoleApp.Models;
using JsonFileConsoleApp.Services;
using Newtonsoft.Json;

namespace JsonFileConsoleApp;

public class Program
{
    private static readonly string PathToJsonFile = "../../../employees.json";

    static void Main(string[] args)
    {
        // Reading info from Json
        var company = GetCompanyFromJsonAsync().Result;

        // Displaying in console
        DisplayService.DisplayCompanyInfo(company);
        DisplayService.DisplayEmployees(company.Employees);

        // Changing some info
        company.Name = "Software Inc.";

        // Updating Json
        UpdateJsonFile(company);

        // Displaying new info in console
        DisplayService.DisplayCompanyInfo(company);

    }

    static async Task<Company> GetCompanyFromJsonAsync()
    {
        Company company;
        var parseService = new ParseService(PathToJsonFile);

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

    static void UpdateJsonFile(Company company)
    {
        var content = JsonConvert.SerializeObject(company, Formatting.Indented);
        File.WriteAllText(PathToJsonFile, content);
    }
}
