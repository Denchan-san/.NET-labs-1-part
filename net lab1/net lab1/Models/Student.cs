using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace net_lab1
{
    internal class Student
    {
        public int Id;
        public string Name;
        public string Faculty;
        public string Cathedra;
        public int Course;
        public string Gender;
        public int DateOfBirth;

        public Student(int id, string name, string faculty, string cathedra, int course,string gender, int dateOfBirth)
        {
            Id = id;   
            Name = name;
            Faculty = faculty;
            Cathedra = cathedra;
            Course = course;
            Gender = gender;
            DateOfBirth = dateOfBirth;
        }
        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Faculty: {Faculty}, Cathedra: {Cathedra}, Course: {Course}";
        }
    }
}
