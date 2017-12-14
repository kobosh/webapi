using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;



namespace WebApiApplication
{
    public class Student
    {
        public int StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class StudentsController : ApiController
    {

        public HttpResponseMessage Get()
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK,
                StudentRepository.GetAllStudents());
            response.Headers.Add("Access-Control-Allow-Origin", "*");
            return response;
        }


    }
    public class StudentRepository
    {
        private static List<Student> students = new List<Student> {
        new Student(){ StudentID=1, FirstName="Hass",LastName="Moh"},
         new Student(){ StudentID=2, FirstName="Hassan",LastName="Mohemm"},
          new Student(){ StudentID=3, FirstName="Hussan",LastName="Mohu"},
           new Student(){ StudentID=4, FirstName="Hessan",LastName="Moham"}
    };




        static public List<Student> GetAllStudents()
        {
            return students;
        }



    }


}