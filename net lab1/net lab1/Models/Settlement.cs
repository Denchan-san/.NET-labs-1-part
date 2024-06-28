using System;

namespace net_lab1.Models
{
    internal class Settlement
    {
        public int Id;
        public int StudentId;
        public int HostelId;

        public DateTime CheсkInTime;
        public DateTime CheсkOutTime;

        public Settlement(int id, int studentId, int hostelId, DateTime checkin, DateTime checkout)
        {
            Id = id;   
            StudentId = studentId;
            HostelId = hostelId;
            CheсkInTime = checkin;
            CheсkOutTime = checkout;
        }

        public override string ToString()
        {
            return $"Id: {Id}, StudentId: {StudentId}, HostelId: {HostelId}, CheckInTime: {CheсkInTime}, CheckOutTime: {CheсkOutTime}";
        }
    }
}
