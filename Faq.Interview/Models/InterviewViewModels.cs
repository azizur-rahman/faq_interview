using System;
using System.Collections.Generic;
using System.Web.Mvc;

public class DataListItem
{
    public string Value { get; set; }
    public string Text { get; set; }
}

public class AutocompleteListItem
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class ValidationViewModel
{

    public string Name { get; set; }
    public DateTime Date { get; set; }
    public bool Agreed { get; set; }
}

public class DinnerViewModel
{
    public DinnerViewModel()
    {
        Sizes = new List<Size>();
    }
    public string Name { get; set; }
    public string Description { get; set; }
    public List<Size> Sizes { get; set; }
}

public class Size
{
    public string Name { get; set; }
    public double Price { get; set; }
    public double Unit { get; set; }
}

public class Employee
{
    public Employee()
    {
        Salaries = new List<Salary>();
    }
    public int Id { get; set; }
    public string Name { get; set; }

    public List<Salary> Salaries { get; set; }
}

public class Salary
{
    public int EmployeeId { get; set; }
    public DateTime Date { get; set; }
    public double Amount { get; set; }
}