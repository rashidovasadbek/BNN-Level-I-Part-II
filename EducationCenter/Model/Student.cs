using EducationCenter.Model.Common;

namespace EducationCenter.Model;
public class Student:DateAt 
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int SubjectId { get; set; }
    public string Email { get; set; }
}
