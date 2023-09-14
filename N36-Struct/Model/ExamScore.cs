using System.Reflection.Metadata;

namespace N36_Struct.Model;

public class ExamScore
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int Score { get; set; }

    public ExamScore(int id, int userid, int score)
    {
        Id = id;
        UserId = userid;
        Score = score;      
    }
}
