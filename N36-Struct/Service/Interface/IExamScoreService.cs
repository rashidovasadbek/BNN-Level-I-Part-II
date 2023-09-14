using N36_Struct.Model;

namespace N36_Struct.Service.Interface;

public interface IExamScoreService
{
    void Create(ExamScore examScore);
    ExamScore GetById(int id);
    void Update(ExamScore examScore);
    void Delete(int id);
    IEnumerable<ExamScore> GetAll();

}
