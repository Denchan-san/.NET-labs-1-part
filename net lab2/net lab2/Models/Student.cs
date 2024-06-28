
namespace net_lab2
{
    public class Student
    {
        public int Id;
        public string Name;
        public string Faculty;
        public string Cathedra;
        public int Course;
        public string Gender;
        public int YearOfBirth;

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Faculty: {Faculty}, Cathedra: {Cathedra}, Course: {Course}";
        }
    }
}
