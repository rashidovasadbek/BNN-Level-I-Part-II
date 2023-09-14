using N36_Struct.Model;
using N36_Struct.Service.Interface;

namespace N36_Struct.Service;

public class ExamAnalytics
{
    private IExamScoreService _examScoreService;
    private IUserService _userService;

    public ExamAnalytics(IExamScoreService examScoreService, IUserService userService)
    {
        _examScoreService = examScoreService;
        _userService = userService;
    }

    public IEnumerable<(string Fullname,int Score)> GetAllScores()
    {
       var examScores =  _examScoreService.GetAll();
       var users = _userService.GetAll();

        var scores = new List<(string Fullname, int Score)>();
        foreach ( var examScore in examScores )
        {
            var user = users.FirstOrDefault(user => user.Id == examScore.Id);
            
            if ( user != null)
            {
                scores.Add((user.FirstName+" "+ user.LastName,examScore.Score));
            }
        }
        return scores;
    }
}
