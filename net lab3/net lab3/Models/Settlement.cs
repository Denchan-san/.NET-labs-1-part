using System;

namespace net_lab3.Models
{
    public class Settlement
    {
        public int Id;
        public int StudentId;
        public int HostelId;

        public DateTime CheсkInTime;
        public DateTime CheсkOutTime;

        public override string ToString()
        {
            return $"Id: {Id}, StudentId: {StudentId}, HostelId: {HostelId}, CheckInTime: {CheсkInTime}, CheckOutTime: {CheсkOutTime}";
        }
    }
}
