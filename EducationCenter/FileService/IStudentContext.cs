using EducationCenter.Model;

namespace EducationCenter.FileService;
public interface IStudentContext
{
    Student CreateStudent(Student student);
    Student DeleteStudent(int id);
    Student SearchStudent(int id);

}
