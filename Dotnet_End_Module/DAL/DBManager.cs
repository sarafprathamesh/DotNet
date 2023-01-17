namespace DAL;
using BOL;
using MySql.Data.MySqlClient;

public class DBManager
{

    public static string ConString = @"server=localhost;port=3307;user=newuser;password=root123;database=dotnet";


    public static List<Student> GetAllStudents()
    {
        List<Student> allStudents = new List<Student>();

        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = ConString;
        try
        {
            con.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;
            string query = "select * from student";
            cmd.CommandText = query;
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int rollno = int.Parse(reader["rollno"].ToString());
                string name = reader["name"].ToString();
                string address = reader["address"].ToString();
                string course = reader["course"].ToString();

                Student student = new Student
                {
                    RollNo = rollno,
                    Name = name,
                    Address = address,
                    Course = course
                };

                allStudents.Add(student);

            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            con.Close();
        }
        return allStudents;
    }


    public static List<Department> GetAllDepartments()
    {
        List<Department> allDepartments = new List<Department>();

        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = ConString;
        try
        {
            con.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;
            string query = "select * from department";
            cmd.CommandText = query;
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int deptno = int.Parse(reader["deptno"].ToString());
                string dname = reader["dname"].ToString();
                string dlocation = reader["dlocation"].ToString();


                Department dept = new Department
                {
                    DeptNo = deptno,
                    DName = dname,
                    Location = dlocation
                };

                allDepartments.Add(dept);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            con.Close();
        }

        return allDepartments;
    }


    public static bool InsertStudent(Student student)
    {
        bool status = false;
        string query = "insert into student values(" + student.RollNo + ",'" + student.Name + "','" + student.Address + "','" + student.Course + "')";

        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = ConString;
        try
        {
            con.Open();
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.ExecuteNonQuery();
            status = true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            con.Close();
        }
        return status;
    }
    
    public static bool UpdateStudent(Student student)
    {
        bool status = false;
        string query = "update student set name='" + student.Name + "' and address='" + student.Address + "' and course='" + student.Course + "where rollno=" + student.RollNo;

        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = ConString;
        try
        {
            con.Open();
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.ExecuteNonQuery();
            status = true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            con.Close();
        }
        return status;
    }

    public static bool DeleteStudent(int id)
    {
        bool status = false;
        string query = "delete from student where rollno=" + id;

        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = ConString;
        try
        {
            con.Open();
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.ExecuteNonQuery();
            status = true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            con.Close();
        }
        return status;
    }

}
