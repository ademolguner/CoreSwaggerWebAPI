using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreSwaggerWebAPI.Models
{
    public  class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public int Age { get; set; }


        //Test datası
        public static List<Student> GetList()
        {
            List<Student> students = new List<Student>();

            Student studentOne = new Student
            {
                Id = 1,
                FirstName = "Adem",
                SurName = "Olguner",
                Age = 34
            };
            Student studentTwo = new Student
            {
                Id = 2,
                FirstName = "Erdem",
                SurName = "Olguner",
                Age = 30
            };
            students.Add(studentOne);
            students.Add(studentTwo);

            return students;
        }
    }
}
