﻿using UserRegistration.Models;

namespace UserRegistration.Services;
public class EmployeeService
{
    public readonly List<Employee> Employees = new();

    public Employee? GetByEmail(string emailAddress)
    {
        Thread.Sleep(5000);
        return Employees.FirstOrDefault(employee => employee.EmailAddress == emailAddress);
    }

    public void Add(Employee employee)
    {
        Employees.Add(employee);
    }
}
