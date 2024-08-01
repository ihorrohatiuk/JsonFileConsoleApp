using System;
using System.Collections.Generic;
using JsonFileConsoleApp.Models;

namespace JsonFileConsoleApp.Services;
public static class DisplayService
{
    public static void DisplayCompanyInfo(Company company)
    {
        Console.WriteLine($"Company name:    {company.Name}");
        Console.WriteLine($"Employees amount: {company.Employees.Count}");
    }
    public static void DisplayEmployees(List<Employee> employees)
    {
        foreach (var employee in employees)
        {
            Console.WriteLine($"Employee ID: {employee.Id}");
            Console.WriteLine($"First name:  {employee.FirstName}");
            Console.WriteLine($"Last name:   {employee.LastName}");
            Console.WriteLine($"Position:    {employee.Position}");
            Console.WriteLine($"Department:  {employee.Department}");
            Console.WriteLine($"Email:       {employee.Email}");
            Console.WriteLine($"Phone:       {employee.PhoneNumber}");
            Console.WriteLine($"Email:       {employee.Salary}");
            Console.WriteLine($"Hire date:   {employee.HireDate}");
            Console.WriteLine();
        }
    }
}
