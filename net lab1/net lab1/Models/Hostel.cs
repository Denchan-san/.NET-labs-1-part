using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace net_lab1
{
    internal class Hostel
    {
        public int Id;
        public string Address;
        public int AmountOfRooms;
        public int CommandantId;

        public Hostel(int id, string address, int amountOfRooms, int commandantId)
        {
            Id = id;
            Address = address;
            AmountOfRooms = amountOfRooms;
            CommandantId = commandantId;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Address: {Address}, Amount of Rooms: {AmountOfRooms}, Commandant Id: {CommandantId}";
        }
    }
}
