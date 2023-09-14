using N36_Struct.Model;
using N36_Struct.Service.Interface;

namespace N36_Struct.Service;

public class ExamScoreService : IExamScoreService
{
    List<ExamScore> examScoreServices = new List<ExamScore>();
    public void Create(ExamScore service)
    {
        examScoreServices.Add(service);
    }
    public ExamScore GetById(int id)
    {
        return examScoreServices.FirstOrDefault(examscore => examscore.Id == id);
    }
    public void Update(ExamScore examscore)
    {
        var index = examScoreServices.FindIndex(examscore => examscore.Id == examscore.Id);
        examScoreServices[index].Score = examscore.Score;
        examScoreServices[index].UserId = examscore.UserId;
    }
    public void Delete(int id)
    {
        var examscore = examScoreServices.FirstOrDefault(remove =>  remove.Id == id);   
        if(examscore != null)
        {
            examScoreServices.Remove(examscore);
        }
    }
    public IEnumerable<ExamScore> GetAll()
    {
        return examScoreServices;
    }
}
