
namespace net_lab2
{
    public class Hostel
    {
        public int Id;
        public string Address;
        public int AmountOfRooms;
        public int CommandantId;

        public override string ToString()
        {
            return $"Id: {Id}, Address: {Address}, Amount of Rooms: {AmountOfRooms}, Commandant Id: {CommandantId}";
        }
    }
}
