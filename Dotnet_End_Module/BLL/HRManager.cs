namespace BLL;
using DAL;
using BOL;
public class HRManager
{
    public  List<Student> GetAllStudents()
    {
        List<Student> allStudents = new List<Student>();
        allStudents = DBManager.GetAllStudents();
        return allStudents;
    }

    public  List<Department> GetAllDepartments()
    {
        List<Department> allDepartment = new List<Department>();
        allDepartment = DBManager.GetAllDepartments();
        return allDepartment;
    }

    public  bool InsertStudent(Student student)
    {
        if (DBManager.InsertStudent(student))
        {
            return true;
        }
        else
        {
            return false;
        }
    }



}
