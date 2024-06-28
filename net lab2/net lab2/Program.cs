using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using net_lab2.Input;


namespace net_lab2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = "TEST.xml";
            //options to choose the way to input ur data into application

            while (true)
            {
                Console.WriteLine("\nHow would you prefer to act:\n1.Load from \"TEST.xml\"\n2.Insert it by yourself\n3.Serializer example\n4.Display with XDocument\n\n0. Goto requests");
                int choice = int.Parse(Console.ReadLine());
                if (choice == 1)
                {
                    filePath = "TEST.xml";
                }
                if (choice == 2)
                {
                    ConsoleInput.InputWithConsole();
                    filePath = "console.xml";
                }
                if (choice == 3)
                {

                    List<Student> students = new List<Student>
                    {
                         new Student { Id = 1, Name = "John", Faculty = "FIOT", Cathedra ="IPI",Course=2, Gender = "Male" , YearOfBirth = 2005},
                         new Student { Id = 2, Name = "Olya", Faculty = "FIOT", Cathedra ="OT",Course=4, Gender = "Female" , YearOfBirth = 2001}
                    };

                    List<Commandant> commandants = new List<Commandant>
                    {
                         new Commandant { Id = 1, Name = "John", Age = 40, Experience = 5, Gender = "Male" },
                         new Commandant { Id = 2, Name = "Alice", Age = 35, Experience = 8, Gender = "Female" }
                    };

                    List<Hostel> hostels = new List<Hostel>
                    {
                         new Hostel { Id = 1, Address = "123 Main St", AmountOfRooms = 50, CommandantId = 1 },
                         new Hostel { Id = 2, Address = "456 Elm St", AmountOfRooms = 40, CommandantId = 2 }
                    };

                    List<Settlement> settlements = new List<Settlement>
                    {
                         new Settlement { Id = 1, StudentId = 1, HostelId = 1, CheсkInTime=DateTime.Now, CheсkOutTime=DateTime.Now.AddMonths(1)},
                         new Settlement { Id = 2, StudentId = 2, HostelId = 2, CheсkInTime=DateTime.Now, CheсkOutTime=DateTime.Now.AddMonths(2) }
                    };

                    /* List<Student> students = new List<Student>
                     {
                         new Student { Id = 1, Name = "Joe", Faculty = "FICT", Cathedra = "IPI", Course = 1, Gender = "Male", YearOfBirth = 2006 },
                         new Student { Id = 2, Name = "Nadiya", Faculty = "FICT", Cathedra = "IPI", Course = 1, Gender = "Female", YearOfBirth = 2006 },
                         new Student { Id = 3, Name = "Alexandr", Faculty = "FICT", Cathedra = "IPI", Course = 2, Gender = "Male", YearOfBirth = 2005 },
                         new Student { Id = 4, Name = "Myhailo", Faculty = "FICT", Cathedra = "IPI", Course = 2, Gender = "Male", YearOfBirth = 2004 },
                         new Student { Id = 5, Name = "Oksana", Faculty = "FICT", Cathedra = "OT", Course = 3, Gender = "Female", YearOfBirth = 2002 }
                     };

                     List<Commandant> commandants = new List<Commandant>
                     {
                         new Commandant { Id = 1, Name = "Adriy", Age = 40, Experience = 5, Gender = "Male" },
                         new Commandant { Id = 2, Name = "Olena", Age = 45, Experience = 1, Gender = "Female" },
                         new Commandant { Id = 3, Name = "Sophia", Age = 60, Experience = 23, Gender = "Female" },
                         new Commandant { Id = 4, Name = "Oksana", Age = 70, Experience = 4, Gender = "Female" },
                         new Commandant { Id = 5, Name = "Maxik", Age = 43, Experience = 14, Gender = "Male" }
                     };

                     List<Hostel> hostels = new List<Hostel>
                     {
                         new Hostel { Id = 1, Address = "Boholubova", AmountOfRooms = 200, CommandantId = 5 },
                         new Hostel { Id = 2, Address = "Retardova", AmountOfRooms = 250, CommandantId = 4 },
                         new Hostel { Id = 3, Address = "Politehnichna", AmountOfRooms = 140, CommandantId = 3 },
                         new Hostel { Id = 4, Address = "Knushna", AmountOfRooms = 600, CommandantId = 2 },
                         new Hostel { Id = 5, Address = "Simonova", AmountOfRooms = 800, CommandantId = 1 }
                     };

                     List<Settlement> settlements = new List<Settlement>
                     {
                         new Settlement { Id = 1, StudentId = 2, HostelId = 3, CheсkInTime = new DateTime(2015, 12, 13), CheсkOutTime = new DateTime(2016, 1, 13) },
                         new Settlement { Id = 2, StudentId = 3, HostelId = 1, CheсkInTime = new DateTime(2015, 11, 12), CheсkOutTime = new DateTime(2015, 11, 12) },
                         new Settlement { Id = 3, StudentId = 1, HostelId = 2, CheсkInTime = new DateTime(2015, 1, 1), CheсkOutTime = new DateTime(2015, 2, 1) },
                         new Settlement { Id = 4, StudentId = 4, HostelId = 3, CheсkInTime = new DateTime(2015, 3, 13), CheсkOutTime = new DateTime(2016, 4, 13) },
                         new Settlement { Id = 5, StudentId = 5, HostelId = 1, CheсkInTime = new DateTime(2015, 5, 13), CheсkOutTime = new DateTime(2016, 7, 13) }
                     };*/

                    SerializeToXml("Serializer.xml", commandants, hostels, students, settlements);
                    Console.ReadKey();
                    DeserializeAndPrintFromXml("Serializer.xml");

                }
                if (choice == 4)
                {
                   DisplayDoc(filePath);
                }

                if (choice == 0) { break; }
            }
            //requests

            XDocument doc = XDocument.Load("TEST.xml");
            Console.WriteLine("WORK:");
            //here we go

            Console.WriteLine("Get students from the \\\"FICT\\\" faculty.\"");
            var fictStudents = from studentElement in doc.Descendants("Studnets")
                               select new Student
                               {
                                   Id = int.Parse(studentElement.Element("Id").Value),
                                   Name = studentElement.Element("Name").Value,
                                   Faculty = studentElement.Element("Faculty").Value,
                                   Cathedra = studentElement.Element("Cathedra").Value,
                                   Course = int.Parse(studentElement.Element("Course").Value),
                                   Gender = studentElement.Element("Gender").Value,
                                   YearOfBirth = int.Parse(studentElement.Element("YearOfBirth").Value)
                               };

            foreach (var item in fictStudents)
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadKey();

            Console.WriteLine("Get commandants from hostels with less than 300 rooms.");
            var lowCapacityCommandants = from commandantElement in doc.Descendants("Commandants")
                                         where doc.Descendants("Hostels").Any(hostel => (int)hostel.Element("CommandantId") == (int)commandantElement.Element("Id") && (int)hostel.Element("AmountOfRooms") < 300)
                                         select new Commandant
                                         {
                                             Id = int.Parse(commandantElement.Element("Id").Value),
                                             Name = commandantElement.Element("Name").Value,
                                             Age = int.Parse(commandantElement.Element("Age").Value),
                                             Experience = int.Parse(commandantElement.Element("Experience").Value),
                                             Gender = commandantElement.Element("Gender").Value
                                         };

            foreach (var commandant in lowCapacityCommandants)
            {
                Console.WriteLine($"Id: {commandant.Id}, Name: {commandant.Name}, Age: {commandant.Age}, Experience: {commandant.Experience}, Gender: {commandant.Gender}");
            }
            Console.ReadKey();

            Console.WriteLine("Get commandants and hostels.");
            var commandantsWithHostels = from commandantElement in doc.Descendants("Commandants")
                                         join hostelElement in doc.Descendants("Hostels") on (int)commandantElement.Element("Id") equals (int)hostelElement.Element("CommandantId")
                                         select new
                                         {
                                             CommandantName = commandantElement.Element("Name").Value,
                                             HostelAddress = hostelElement.Element("Address").Value,
                                             HostelCapacity = int.Parse(hostelElement.Element("AmountOfRooms").Value)
                                         };

            foreach (var item in commandantsWithHostels)
            {
                Console.WriteLine($"Commandant: {item.CommandantName}, Hostel: {item.HostelAddress}, Capacity: {item.HostelCapacity}");
            }
            Console.ReadKey();

            Console.WriteLine("Get settlements with a duration less than 30 days.");
            var shortTermSettlements = from settlementElement in doc.Descendants("Settlements")
                                       where (DateTime.Parse((string)settlementElement.Element("CheсkOutTime").Value) - DateTime.Parse((string)settlementElement.Element("CheсkInTime").Value)).TotalDays < 30
                                       select new Settlement
                                       {
                                           Id = int.Parse(settlementElement.Element("Id").Value),
                                           StudentId = int.Parse(settlementElement.Element("StudentId").Value),
                                           HostelId = int.Parse(settlementElement.Element("HostelId").Value),
                                           CheсkInTime = DateTime.Parse(settlementElement.Element("CheсkInTime").Value),
                                           CheсkOutTime = DateTime.Parse(settlementElement.Element("CheсkOutTime").Value)
                                       };

            foreach (var item in shortTermSettlements)
            {
                Console.WriteLine($"Id: {item.Id}, StudentId: {item.StudentId}, HostelId: {item.HostelId}, CheckInTime: {item.CheсkInTime}, CheckOutTime: {item.CheсkOutTime}");
            }
            Console.ReadKey();

            Console.WriteLine("Get students who settled after January 1, 2016");
            var recentStudents = from studentElement in doc.Descendants("Studnets")
                                 join settlementElement in doc.Descendants("Settlements") on (int)studentElement.Element("Id") equals (int)settlementElement.Element("StudentId")
                                 where DateTime.Parse((string)settlementElement.Element("CheсkInTime").Value) > new DateTime(2016, 1, 1)
                                 select new Student
                                 {
                                     Id = int.Parse(studentElement.Element("Id").Value),
                                     Name = studentElement.Element("Name").Value,
                                     Faculty = studentElement.Element("Faculty").Value,
                                     Cathedra = studentElement.Element("Cathedra").Value,
                                     Course = int.Parse(studentElement.Element("Course").Value),
                                     Gender = studentElement.Element("Gender").Value,
                                     YearOfBirth = int.Parse(studentElement.Element("YearOfBirth").Value)
                                 };

            foreach (var student in recentStudents)
            {
                Console.WriteLine($"Id: {student.Id}, Name: {student.Name}, Faculty: {student.Faculty}, Cathedra: {student.Cathedra}, Course: {student.Course}, Gender: {student.Gender}, YearOfBirth: {student.YearOfBirth}");
            }
            Console.ReadKey();

            Console.WriteLine("Get commandants with names containing the letter \"a\".");
            var commandantsWithA = from commandantElement in doc.Descendants("Commandants")
                                   where commandantElement.Element("Name").Value.ToLower().Contains("a")
                                   select new Commandant
                                   {
                                       Id = int.Parse(commandantElement.Element("Id").Value),
                                       Name = commandantElement.Element("Name").Value,
                                       Age = int.Parse(commandantElement.Element("Age").Value),
                                       Experience = int.Parse(commandantElement.Element("Experience").Value),
                                       Gender = commandantElement.Element("Gender").Value
                                   };

            foreach (var commandant in commandantsWithA)
            {
                Console.WriteLine($"Id: {commandant.Id}, Name: {commandant.Name}, Age: {commandant.Age}, Experience: {commandant.Experience}, Gender: {commandant.Gender}");
            }
            Console.ReadKey();

            Console.WriteLine("Get hostels with more female students than male students.");
            var femaleDominatedHostels = from hostelElement in doc.Descendants("Hostels")
                                         let hostelId = int.Parse(hostelElement.Element("Id").Value)
                                         let femaleCount = doc.Descendants("Settlements").Count(settlementElement => (int)settlementElement.Element("HostelId") == hostelId &&
                                                            doc.Descendants("Studnets").Any(studentElement => (int)studentElement.Element("Id") == (int)settlementElement.Element("StudentId") &&
                                                            studentElement.Element("Gender").Value == "Female"))
                                         let maleCount = doc.Descendants("Settlements").Count(settlementElement => (int)settlementElement.Element("HostelId") == hostelId &&
                                                            doc.Descendants("Studnets").Any(studentElement => (int)studentElement.Element("Id") == (int)settlementElement.Element("StudentId") &&
                                                            studentElement.Element("Gender").Value == "Male"))
                                         where femaleCount > maleCount
                                         select new Hostel
                                         {
                                             Id = int.Parse(hostelElement.Element("Id").Value),
                                             Address = hostelElement.Element("Address").Value,
                                             AmountOfRooms = int.Parse(hostelElement.Element("AmountOfRooms").Value),
                                             CommandantId = int.Parse(hostelElement.Element("CommandantId").Value)
                                         };

            foreach (var hostel in femaleDominatedHostels)
            {
                Console.WriteLine($"Id: {hostel.Id}, Address: {hostel.Address}, AmountOfRooms: {hostel.AmountOfRooms}, CommandantId: {hostel.CommandantId}");
            }
            Console.ReadKey();

            Console.WriteLine("Get settlements overlapping December 1, 2015, to January 1, 2016.");
            var overlappingSettlements = from settlementElement in doc.Descendants("Settlements")
                                         let checkInTime = DateTime.Parse((string)settlementElement.Element("CheсkInTime").Value)
                                         let checkOutTime = DateTime.Parse((string)settlementElement.Element("CheсkOutTime").Value)
                                         where checkInTime < new DateTime(2016, 1, 1) && checkOutTime > new DateTime(2015, 12, 1)
                                         select new Settlement
                                         {
                                             Id = int.Parse(settlementElement.Element("Id").Value),
                                             StudentId = int.Parse(settlementElement.Element("StudentId").Value),
                                             HostelId = int.Parse(settlementElement.Element("HostelId").Value),
                                             CheсkInTime = checkInTime,
                                             CheсkOutTime = checkOutTime
                                         };

            foreach (var settlement in overlappingSettlements)
            {
                Console.WriteLine($"Id: {settlement.Id}, StudentId: {settlement.StudentId}, HostelId: {settlement.HostelId}, CheckInTime: {settlement.CheсkInTime}, CheckOutTime: {settlement.CheсkOutTime}");
            }
            Console.ReadKey();

            Console.WriteLine("Get students from hostels with even IDs.");
            var studentsInEvenHostels = from studentElement in doc.Descendants("Studnets")
                                        let studentId = int.Parse(studentElement.Element("Id").Value)
                                        where doc.Descendants("Settlements").Any(settlementElement => (int)settlementElement.Element("StudentId") == studentId &&
                                              doc.Descendants("Hostels").Any(hostelElement => (int)hostelElement.Element("Id") % 2 == 0 &&
                                              (int)hostelElement.Element("Id") == (int)settlementElement.Element("HostelId")))
                                        select new Student
                                        {
                                            Id = int.Parse(studentElement.Element("Id").Value),
                                            Name = studentElement.Element("Name").Value,
                                            Faculty = studentElement.Element("Faculty").Value,
                                            Cathedra = studentElement.Element("Cathedra").Value,
                                            Course = int.Parse(studentElement.Element("Course").Value),
                                            Gender = studentElement.Element("Gender").Value,
                                            YearOfBirth = int.Parse(studentElement.Element("YearOfBirth").Value)
                                        };

            foreach (var student in studentsInEvenHostels)
            {
                Console.WriteLine($"Id: {student.Id}, Name: {student.Name}, Faculty: {student.Faculty}, Cathedra: {student.Cathedra}, Course: {student.Course}, Gender: {student.Gender}, YearOfBirth: {student.YearOfBirth}");
            }
            Console.ReadKey();

            Console.WriteLine("Get experienced commandants with more than 10 years of experience.");
            var experiencedCommandants = from commandantElement in doc.Descendants("Commandants")
                                         let experience = int.Parse(commandantElement.Element("Experience").Value)
                                         where experience > 10
                                         select new Commandant
                                         {
                                             Id = int.Parse(commandantElement.Element("Id").Value),
                                             Name = commandantElement.Element("Name").Value,
                                             Age = int.Parse(commandantElement.Element("Age").Value),
                                             Experience = experience,
                                             Gender = commandantElement.Element("Gender").Value
                                         };

            foreach (var commandant in experiencedCommandants)
            {
                Console.WriteLine($"Id: {commandant.Id}, Name: {commandant.Name}, Age: {commandant.Age}, Experience: {commandant.Experience}, Gender: {commandant.Gender}");
            }
            Console.ReadKey();

            Console.WriteLine("Get hostels with the letter \"o\" in their address.");
            var hostelsWithO = from hostelElement in doc.Descendants("Hostels")
                               let address = hostelElement.Element("Address").Value.ToLower()
                               where address.Contains("o")
                               select new Hostel
                               {
                                   Id = int.Parse(hostelElement.Element("Id").Value),
                                   Address = hostelElement.Element("Address").Value,
                                   AmountOfRooms = int.Parse(hostelElement.Element("AmountOfRooms").Value),
                                   CommandantId = int.Parse(hostelElement.Element("CommandantId").Value)
                               };

            foreach (var hostel in hostelsWithO)
            {
                Console.WriteLine($"Id: {hostel.Id}, Address: {hostel.Address}, AmountOfRooms: {hostel.AmountOfRooms}, CommandantId: {hostel.CommandantId}");
            }
            Console.ReadKey();

            Console.WriteLine("Get settlements with a duration of exactly 30 days.");
            var thirtyDaysSettlements = from settlementElement in doc.Descendants("Settlements")
                                        let checkInTime = DateTime.Parse((string)settlementElement.Element("CheсkInTime").Value)
                                        let checkOutTime = DateTime.Parse((string)settlementElement.Element("CheсkOutTime").Value)
                                        where (checkOutTime - checkInTime).TotalDays == 30
                                        select new Settlement
                                        {
                                            Id = int.Parse(settlementElement.Element("Id").Value),
                                            StudentId = int.Parse(settlementElement.Element("StudentId").Value),
                                            HostelId = int.Parse(settlementElement.Element("HostelId").Value),
                                            CheсkInTime = checkInTime,
                                            CheсkOutTime = checkOutTime
                                        };

            foreach (var settlement in thirtyDaysSettlements)
            {
                Console.WriteLine($"Id: {settlement.Id}, StudentId: {settlement.StudentId}, HostelId: {settlement.HostelId}, CheckInTime: {settlement.CheсkInTime}, CheckOutTime: {settlement.CheсkOutTime}");
            }
            Console.ReadKey();

            Console.WriteLine("Get students along with their commandants.");
            var studentCommandantNames = from studentElement in doc.Descendants("Studnets")
                                         join settlementElement in doc.Descendants("Settlements") on int.Parse(studentElement.Element("Id").Value) equals int.Parse(settlementElement.Element("StudentId").Value)
                                         join hostelElement in doc.Descendants("Hostels") on int.Parse(settlementElement.Element("HostelId").Value) equals int.Parse(hostelElement.Element("Id").Value)
                                         join commandantElement in doc.Descendants("Commandants") on int.Parse(hostelElement.Element("CommandantId").Value) equals int.Parse(commandantElement.Element("Id").Value)
                                         select new
                                         {
                                             StudentName = studentElement.Element("Name").Value,
                                             CommandantName = commandantElement.Element("Name").Value
                                         };

            foreach (var item in studentCommandantNames)
            {
                Console.WriteLine($"Student: {item.StudentName}, Commandant: {item.CommandantName}");
            }
            Console.ReadKey();

            Console.WriteLine("Get the average age of students in each hostel.");
            var averageStudentAgeByHostel = from studentElement in doc.Descendants("Studnets")
                                            join settlementElement in doc.Descendants("Settlements") on int.Parse(studentElement.Element("Id").Value) equals int.Parse(settlementElement.Element("StudentId").Value)
                                            group studentElement by int.Parse(settlementElement.Element("HostelId").Value) into g
                                            select new
                                            {
                                                HostelId = g.Key,
                                                AverageAge = g.Average(student => DateTime.Now.Year - int.Parse(student.Element("YearOfBirth").Value))
                                            };

            foreach (var item in averageStudentAgeByHostel)
            {
                Console.WriteLine($"HostelId: {item.HostelId}, AverageAge: {item.AverageAge}");
            }
            Console.ReadKey();

            Console.WriteLine("Get names of students in hostels with capacities greater than 200.");
            var studentsInHighCapacityHostels = from studentElement in doc.Descendants("Studnets")
                                                join settlementElement in doc.Descendants("Settlements") on int.Parse(studentElement.Element("Id").Value) equals int.Parse(settlementElement.Element("StudentId").Value)
                                                join hostelElement in doc.Descendants("Hostels") on int.Parse(settlementElement.Element("HostelId").Value) equals int.Parse(hostelElement.Element("Id").Value)
                                                where int.Parse(hostelElement.Element("AmountOfRooms").Value) > 200
                                                select new
                                                {
                                                    StudentName = studentElement.Element("Name").Value
                                                };

            foreach (var item in studentsInHighCapacityHostels)
            {
                Console.WriteLine($"StudentName: {item.StudentName}");
            }
            Console.ReadKey();

            Console.WriteLine("Get settlements with a duration less than 90 days.");
            var longTermSettlements = from settlementElement in doc.Descendants("Settlements")
                                       where (DateTime.Parse((string)settlementElement.Element("CheсkOutTime").Value) - DateTime.Parse((string)settlementElement.Element("CheсkInTime").Value)).TotalDays < 90
                                       select new Settlement
                                       {
                                           Id = int.Parse(settlementElement.Element("Id").Value),
                                           StudentId = int.Parse(settlementElement.Element("StudentId").Value),
                                           HostelId = int.Parse(settlementElement.Element("HostelId").Value),
                                           CheсkInTime = DateTime.Parse(settlementElement.Element("CheсkInTime").Value),
                                           CheсkOutTime = DateTime.Parse(settlementElement.Element("CheсkOutTime").Value)
                                       };

            foreach (var item in longTermSettlements)
            {
                Console.WriteLine($"Id: {item.Id}, StudentId: {item.StudentId}, HostelId: {item.HostelId}, CheckInTime: {item.CheсkInTime}, CheckOutTime: {item.CheсkOutTime}");
            }
            Console.ReadKey();

        }



        public static void DisplayDoc(string path)
        {
            try
            {
                XmlDocument xmldoc = new XmlDocument();

                xmldoc.Load(path);

                XmlWriterSettings settings = new XmlWriterSettings
                {
                    Indent = true,
                    IndentChars = "\t"
                };

                using (XmlWriter writer = XmlWriter.Create(Console.Out, settings))
                {
                    xmldoc.Save(writer);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        static void SerializeToXml(string filePath, List<Commandant> commandants, List<Hostel> hostels, List<Student> students, List<Settlement> settlements)
        {
            Data data = new Data
            {
                Commandants = commandants,
                Hostels = hostels,
                Students = students,
                Settlements = settlements
            };

            XmlSerializer serializer = new XmlSerializer(typeof(Data));

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, data);
            }

            Console.WriteLine("Data serialized and saved to XML file successfully.");
        }

        static void DeserializeAndPrintFromXml(string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Data));

            using (StreamReader reader = new StreamReader(filePath))
            {
                Data data = (Data)serializer.Deserialize(reader);

                Console.WriteLine("Commandants:");
                foreach (var commandant in data.Commandants)
                {
                    Console.WriteLine($"{commandant.Id}, {commandant.Name}, {commandant.Age}, {commandant.Experience}, {commandant.Gender}");
                }

                Console.WriteLine("\nHostels:");
                foreach (var hostel in data.Hostels)
                {
                    Console.WriteLine($"{hostel.Id}, {hostel.Address}, {hostel.AmountOfRooms}, {hostel.CommandantId}");
                }

                Console.WriteLine("\nStudents:");
                foreach (var student in data.Students)
                {
                    Console.WriteLine($"{student.Id}, {student.Name}, {student.Faculty}, {student.Cathedra}, {student.Course}, {student.Gender}, {student.YearOfBirth}");
                }

                Console.WriteLine("\nSettlements:");
                foreach (var settlement in data.Settlements)
                {
                    Console.WriteLine($"{settlement.Id}, {settlement.StudentId}, {settlement.HostelId}, {settlement.CheсkInTime}, {settlement.CheсkOutTime}");
                }
            }
        }
    }
}

