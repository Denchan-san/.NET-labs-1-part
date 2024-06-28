using System;

namespace net_lab2
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
