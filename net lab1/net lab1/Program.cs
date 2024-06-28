using net_lab1.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace net_lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>
            {
                new Student(1, "Joe", "FICT", "IPI", 1,"Male", 2006),
                new Student(2, "Nadiya", "FICT", "IPI", 1, "Female", 2006),
                new Student(3, "Alexandr", "FICT", "IPI", 2, "Male", 2005),
                new Student(4, "Myhailo", "FICT", "IPI", 2, "Male", 2004),
                new Student(5, "Oksana", "FICT", "OT", 3, "Female", 2002)
            };
            List<Commandant> commandats = new List<Commandant>
            {
                new Commandant(1,"Adriy", 40, 5, "Male"),
                new Commandant(2,"Olena", 45, 1, "Female"),
                new Commandant(3,"Sophia", 60, 23, "Female"),
                new Commandant(4,"Oksana", 70, 4, "Female"),
                new Commandant(5,"Maxik", 43, 14, "Male")
            };
            List<Hostel> hostels = new List<Hostel>
            {
                new Hostel(1,"Boholubova",200,5),
                new Hostel(2,"Retardova",250,4),
                new Hostel(3,"Politehnichna",140,3),
                new Hostel(4,"Knushna",600,2),
                new Hostel(5,"Simonova",800,1)
            };
            List<Settlement> settlements = new List<Settlement>
            {
                new Settlement(1,2,3,new DateTime(2015,12,13),new DateTime(2016,1,13)),
                new Settlement(2,3,1,new DateTime(2015,11,12),new DateTime(2015,11,12)),
                new Settlement(3,1,2,new DateTime(2015,1,1),new DateTime(2015,2,1)),
                new Settlement(2,4,3,new DateTime(2015,3,13),new DateTime(2016,4,13)),
                new Settlement(3,5,1,new DateTime(2015,5,13),new DateTime(2016,7,13))
            };

            while (true)
            {
                int choice = ConsoleUI.userChoice();

                switch (choice)
                {
                    case 0:
                        System.Environment.Exit(1);
                        break;
                    case 1:
                        {
                            var joeStudents = students.Where(s => s.Name.Contains("Joe"));

                            Console.Clear();
                            foreach (var item in joeStudents)
                            {
                                Console.WriteLine(item.ToString());
                            }
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                    case 2:
                        {
                            var elderCommandants = commandats.Where(c => c.Age > 50);

                            Console.Clear();
                            foreach (var item in elderCommandants)
                            {
                                Console.WriteLine(item.ToString());
                            }
                            Console.ReadKey();
                            Console.Clear();
                            break;

                        }
                    case 3:
                        {
                            var highCapacityHostels = hostels.Where(h => h.AmountOfRooms > 300);

                            Console.Clear();
                            foreach (var item in highCapacityHostels)
                            {
                                Console.WriteLine(item.ToString());
                            }
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                    case 4:
                        {
                            var recentSettlements = settlements.Where(s => s.CheсkOutTime > new DateTime(2016, 1, 1));

                            Console.Clear();
                            foreach (var item in recentSettlements)
                            {
                                Console.WriteLine(item.ToString());
                            }
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                    case 5:
                        {
                            var fictStudents = students.Where(s => s.Faculty == "FICT");

                            Console.Clear();
                            foreach (var item in fictStudents)
                            {
                                Console.WriteLine(item.ToString());
                            }
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                    case 6:
                        {
                            //
                            var lowCapacityCommandants = commandats.Where(c => hostels.Any(h => h.CommandantId == c.Id && h.AmountOfRooms < 300));

                            Console.Clear();
                            foreach (var item in lowCapacityCommandants)
                            {
                                Console.WriteLine(item.ToString());
                            }
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                    case 7:
                        {
                            var commandantsWithHostels = commandats.Join(hostels, c => c.Id, h => h.CommandantId, (c, h) => new { Commandant = c, Hostel = h });

                            Console.Clear();
                            foreach (var item in commandantsWithHostels)
                            {
                                Console.WriteLine($"Commandant: {item.Commandant.Name}, Hostel: {item.Hostel.Address}, Capacity: {item.Hostel.AmountOfRooms}");
                            }
                            Console.ReadKey();
                            Console.Clear();
                            break;

                        }
                    case 8:
                        {
                            var shortTermSettlements = settlements.Where(s => (s.CheсkOutTime - s.CheсkInTime).TotalDays < 30);

                            Console.Clear();
                            foreach (var item in shortTermSettlements)
                            {
                                Console.WriteLine(item.ToString());
                            }
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                    case 9:
                        {
                            var recentStudents = students.Where(s => settlements.Any(set => set.StudentId == s.Id && set.CheсkInTime > new DateTime(2015, 1, 1)));

                            Console.Clear();
                            foreach (var item in recentStudents)
                            {
                                Console.WriteLine(item.ToString());
                            }
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                    case 10:
                        {
                            var commandantsWithA = commandats.Where(c => c.Name.ToLower().Contains("a"));

                            Console.Clear();
                            foreach (var item in commandantsWithA)
                            {
                                Console.WriteLine(item.ToString());
                            }
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                    case 11:
                        {
                            var maleDominatedHostels = hostels.Where(h =>
                                settlements.Count(settlement =>
                                    settlement.HostelId == h.Id &&
                                    students.Any(student =>
                                        student.Id == settlement.StudentId &&
                                        student.Gender == "Male"
                                    )
                                ) >
                                settlements.Count(settlement =>
                                    settlement.HostelId == h.Id &&
                                    students.Any(student =>
                                        student.Id == settlement.StudentId &&
                                        student.Gender == "Female"
                                    )
                                )
                            );

                            Console.Clear();
                            foreach (var item in maleDominatedHostels)
                            {
                                Console.WriteLine(item.ToString());
                            }
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                    case 12:
                        {
                            var overlappingSettlements = settlements.Where(s => s.CheсkInTime < new DateTime(2015, 12, 1) && s.CheсkOutTime > new DateTime(2016, 1, 1));

                            Console.Clear();
                            foreach (var item in overlappingSettlements)
                            {
                                Console.WriteLine(item.ToString());
                            }
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                    case 13:
                        {
                            var evenHostelStudents = students
                                .Where(s => settlements
                                .Any(settlement => settlement.StudentId == s.Id && hostels
                                .Any(hostel => hostel.Id % 2 == 0 && hostel.Id == settlement.HostelId)));


                            Console.Clear();
                            foreach (var item in evenHostelStudents)
                            {
                                Console.WriteLine(item.ToString());
                            }
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                    case 14:
                        {
                            var experiencedCommandants = commandats.Where(c => c.Experience > 10);

                            Console.Clear();
                            foreach (var item in experiencedCommandants)
                            {
                                Console.WriteLine(item.ToString());
                            }
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                    case 15:
                        {
                            var hostelsWithO = hostels.Where(h => h.Address.ToLower().Contains("o"));

                            Console.Clear();
                            foreach (var item in hostelsWithO)
                            {
                                Console.WriteLine(item.ToString());
                            }
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                    case 16:
                        {
                            var thirtyDaysSettlements = settlements.Where(s => (s.CheсkOutTime - s.CheсkInTime).TotalDays >= 30);

                            Console.Clear();
                            foreach (var item in thirtyDaysSettlements)
                            {
                                Console.WriteLine(item.ToString());
                            }
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                    case 17:
                        {
                            var studentCommandantNames = students
                                .Join(settlements, s => s.Id, se => se.StudentId, (s, se) => new { Student = s, Settlement = se })
                                .Join(hostels, ss => ss.Settlement.HostelId, h => h.Id, (ss, h) => new { Student = ss.Student, Hostel = h })
                                .Join(commandats, sh => sh.Hostel.CommandantId, c => c.Id, (sh, c) => new { StudentName = sh.Student.Name, CommandantName = c.Name });

                            Console.Clear();
                            foreach (var item in studentCommandantNames)
                            {
                                Console.WriteLine(item.ToString());
                            }
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                    case 18:
                        {
                            var averageStudentAgeByHostel = students
                                .Join(settlements, s => s.Id, se => se.StudentId, (s, se) => new { Student = s, Settlement = se })
                                .GroupBy(ss => ss.Settlement.HostelId)
                                .Select(g => new
                                {
                                    HostelId = g.Key,
                                    AverageAge = g.Average(ss => DateTime.Now.Year - ss.Student.DateOfBirth)
                                })
                                .Join(hostels, a => a.HostelId, h => h.Id, (a, h) => new { HostelName = h.Address, AverageAge = a.AverageAge });


                            Console.Clear();
                            foreach (var item in averageStudentAgeByHostel)
                            {
                                Console.WriteLine(item.ToString());
                            }
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                    case 19:
                        {
                            var studentsInHighCapacityHostels = students
                                .Join(settlements, s => s.Id, se => se.StudentId, (s, se) => new { Student = s, Settlement = se })
                                .Join(hostels, ss => ss.Settlement.HostelId, h => h.Id, (ss, h) => new { StudentName = ss.Student.Name, HostelCapacity = h.AmountOfRooms })
                                .Where(sh => sh.HostelCapacity > 200)
                                .Select(sh => sh.StudentName);

                            Console.Clear();
                            foreach (var item in studentsInHighCapacityHostels)
                            {
                                Console.WriteLine(item.ToString());
                            }
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                    default:
                        var commandantsAndHostels = commandats
                            .Join(hostels, c => c.Id, h => h.CommandantId, (c, h) => new { Commandant = c, Hostel = h })
                            .GroupJoin(settlements, ch => ch.Hostel.Id, se => se.HostelId, (ch, se) => new { Commandant = ch.Commandant, Hostel = ch.Hostel, StudentCount = se.Count() })
                            .OrderByDescending(chs => chs.StudentCount)
                            .Select(chs => new { CommandantName = chs.Commandant.Name, HostelName = chs.Hostel.Address, StudentCount = chs.StudentCount });

                        Console.Clear();
                        foreach (var item in commandantsAndHostels)
                        {
                            Console.WriteLine(item.ToString());
                        }
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
        }
    }
}
