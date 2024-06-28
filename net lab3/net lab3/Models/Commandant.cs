
namespace net_lab3.Models
{
    public class Commandant
    {
        public int Id;
        public string Name;
        public int Age;
        public int Experience;
        public string Gender;

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Age: {Age}, Experience: {Experience} years";
        }
    }
}
