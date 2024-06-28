using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_lab1
{
    internal class Commandant
    {
        public int Id;
        public string Name;
        public int Age;
        public int Experience;
        public string Gender;

        public Commandant(int id, string name, int age, int experience,string gender)
        {
            Id = id;
            Name = name;
            Age = age;
            Experience = experience;
            Gender = gender;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Age: {Age}, Experience: {Experience} years";
        }
    }
}
