using EducationCenter.Model.Common;

namespace EducationCenter.Model;
public class Payment : DateAt
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public decimal Amount { get; set; }

}
