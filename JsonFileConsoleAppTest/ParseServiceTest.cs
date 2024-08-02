using System;
using System.IO;
using System.Threading.Tasks;
using JsonFileConsoleApp.Services;
using Newtonsoft.Json;
using Xunit;

namespace JsonFileConsoleAppTest;

public class ParseServiceTest
{
    [Fact]
    public async Task IfPathNotExist_ThrowFileNotFoundException()
    {
        // Arrange

        string path = null;
        var parseService = new ParseService(path);

        // Act & Assert 

        await Assert.ThrowsAsync<FileNotFoundException>(() => parseService.ReadEmployeesFromJsonToListAsync());
    }

    [Fact]
    public async Task ReadEmployeesFromFile_InvalidJson_ThrowsInvalidOperationException()
    {
        // Arrange

        string invalidJsonFilePath = "invalid.json";

        // Creating a file with invalid JSON
        await File.WriteAllTextAsync(invalidJsonFilePath, "Invalid JSON content");
        var parseService = new ParseService(invalidJsonFilePath);

        // Act & Assert

        await Assert.ThrowsAsync<InvalidOperationException>(() => parseService.ReadEmployeesFromJsonToListAsync());

        // Clean up
        File.Delete(invalidJsonFilePath);
    }

    [Fact]
    public async Task ReadEmployeesFromFile_ValidJson_NoExceptionThrown()
    {
        // Arrange 

        string validJsonFilePath = "valid.json";

        // Creating valid JSON content
        var data = new
        {
            name = "Tech Solutions LLC",
            employees = new[]
            {
                new
                {
                    id = 101,
                    firstName = "Alex",
                    lastName = "Johnson",
                    position = "Software Engineer",
                    department = "Engineering",
                    email = "alex.johnson@techsolutions.com",
                    phone = "+1-555-123-4567",
                    salary = 85000,
                    hireDate = "2022-03-15"
                }
            }
        };

        string validJsonContent = JsonConvert.SerializeObject(data, Formatting.Indented);

        await File.WriteAllTextAsync(validJsonFilePath, validJsonContent);

        var parseService = new ParseService(validJsonFilePath);


        // Act

        var resultCompany = parseService.ReadEmployeesFromJsonToListAsync();


        // Assert

        Assert.NotNull(resultCompany.Result);
        Assert.Equal("Tech Solutions LLC", resultCompany.Result.Name);
        Assert.Single(resultCompany.Result.Employees);
        Assert.Equal("Alex", resultCompany.Result.Employees[0].FirstName);


        // Clean up
        File.Delete(validJsonFilePath);
    }
}