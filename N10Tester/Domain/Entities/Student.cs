namespace N10Tester.Domain.Entities;

public class Student
{
    public long Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? ProjectPath { get; set; }
    public string? CrmId { get; set; }
    public DateTime CreateAt { get; set; }
    public DateTime UpdateAt { get; set;}
}
