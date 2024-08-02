using System;
using System.IO;
using System.Threading.Tasks;
using JsonFileConsoleApp.Models;
using Newtonsoft.Json;

namespace JsonFileConsoleApp.Services;
public class ParseService
{
    private readonly string _pathToJsonFile;

    public ParseService(string pathToJsonFile) => _pathToJsonFile = pathToJsonFile;
    
    public async Task<Company> ReadEmployeesFromJsonToListAsync()
    {
        if (!File.Exists(_pathToJsonFile) || _pathToJsonFile is null) 
            throw new FileNotFoundException($"Cannot find the file: ", _pathToJsonFile);

        Company company;
        using StreamReader reader = new StreamReader(_pathToJsonFile);
        var jsonFile = await reader.ReadToEndAsync();
        try
        {
            company = JsonConvert.DeserializeObject<Company>(jsonFile);
        }
        catch (Exception e)
        {
            throw new InvalidOperationException("Failed to deserialize JSON data.");
        }

        return company;
    }
}
