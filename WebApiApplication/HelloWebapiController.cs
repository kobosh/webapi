using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
namespace WebApiApplication
{
    public class Student
    {
        public int StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class StudensController : ApiController
    {
        public List<Student> Get()
        {
            return StudentRepository.GetAllStudents();// "Hello web api";
        }
        //public HttpResponseMessage Request()
        //{
        //    HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
        //    response.Headers.Add("Access-Control-Allow-Origin", "*");
        //    response.Content = new StringContent("Some content...",
        //        System.Text.Encoding.UTF8, "text/plain");
        //    return response;
        //}

    }
    public class StudentRepository
    {
        private static List<Student> students = new List<Student> {
        new Student(){ StudentID=1, FirstName="Hass",LastName="Moh"},
         new Student(){ StudentID=2, FirstName="Hassan",LastName="Mohemm"},
          new Student(){ StudentID=3, FirstName="Hussan",LastName="Mohu"},
           new Student(){ StudentID=4, FirstName="Hessan",LastName="Moham"}
    };

        public static List<Student> GetAllStudents()
        {
            return students;
        }

        public static Student GetStudent(int studentID)
        {
            return students.Where(d => d.StudentID == studentID).First();
        }

        public static void RemoveStudent(int studentID)
        {
            var stu = students.Find(s => s.StudentID == studentID);
            students.Remove(stu);
        }

        public static void AddStudent(Student student)
        {
            students.Add(student);
        }

        public static void UpdateStudent(Student student)
        {
            //
        }

    }
    public class StudentsController : ApiController
    {
        public List<Student> Get()
        {
            return StudentRepository.GetAllStudents();
        }

        public Student Get(int id)
        {
            return StudentRepository.GetStudent(id);
        }

        public void Post(Student Student)
        {
            StudentRepository.AddStudent(Student);
        }

        public void Put(Student Student)
        {
            StudentRepository.UpdateStudent(Student);
        }

        public void Delete(int id)
        {
            StudentRepository.RemoveStudent(id);
        }
    }

}