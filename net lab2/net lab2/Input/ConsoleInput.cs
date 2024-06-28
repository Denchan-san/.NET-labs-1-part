using System;
using System.Collections.Generic;
using System.Xml;

namespace net_lab2.Input
{
    class ConsoleInput
    {
        public static void InputWithConsole()
        {
            List<Commandant> commandants = new List<Commandant>();

            while (true)
            {
                int commandantsIdCounter = 1;
                Commandant commandant = InputCommandantDetails(ref commandantsIdCounter);
                commandants.Add(commandant);
                commandantsIdCounter++;

                Console.Write("Do you want to enter another commandant? (y/n): ");
                if (Console.ReadLine().ToLower() != "y")
                    break;
            }

            List<Hostel> hostels = new List<Hostel>();

            while (true)
            {
                int hostelsIdCounter = 1;
                Hostel hostel = InputHostelDetails(ref hostelsIdCounter);
                hostels.Add(hostel);
                hostelsIdCounter++;

                Console.Write("Do you want to enter another hostel? (y/n): ");
                if (Console.ReadLine().ToLower() != "y")
                    break;
            }

            List<Student> students = new List<Student>();

            while (true)
            {
                int studentsIdCounter = 1;
                Student student = InputStudentDetails(ref studentsIdCounter);
                students.Add(student);
                studentsIdCounter++;

                Console.Write("Do you want to enter another student? (y/n): ");
                if (Console.ReadLine().ToLower() != "y")
                    break;
            }

            List<Settlement> settlements = new List<Settlement>();

            while (true)
            {
                int settlementsIdCounter = 1;
                Settlement settlement = InputSettlementDetails(ref settlementsIdCounter);
                settlements.Add(settlement);
                settlementsIdCounter++;

                Console.Write("Do you want to enter another settlement? (y/n): ");
                if (Console.ReadLine().ToLower() != "y")
                    break;
            }

            // Save data to XML
            SaveDataToXml(commandants, hostels, settlements, students);

            Console.WriteLine("Data saved to XML file successfully.");
            Console.ReadKey();
             
        }

        public static Commandant InputCommandantDetails(ref int idCounter)
        {
            Commandant commandant = new Commandant();
            commandant.Id = idCounter;
            Console.WriteLine("Enter commandant details:");
            Console.Write("Name: ");
            commandant.Name = Console.ReadLine();
            Console.Write("Age: ");
            commandant.Age = int.Parse(Console.ReadLine());
            Console.Write("Experience: ");
            commandant.Experience = int.Parse(Console.ReadLine());
            Console.Write("Gender: ");
            commandant.Gender = Console.ReadLine();
            return commandant;
        }

        static public Hostel InputHostelDetails(ref int idCounter)
        {   
            Hostel hostel = new Hostel();
            hostel.Id = idCounter;
            Console.WriteLine("\nEnter hostel details:");
            Console.Write("Address: ");
            hostel.Address = Console.ReadLine();
            Console.Write("Amount Of Rooms: ");
            hostel.AmountOfRooms = int.Parse(Console.ReadLine());
            Console.Write("Commandant Id: ");
            hostel.CommandantId = int.Parse(Console.ReadLine());
            return hostel;
        }

        static Settlement InputSettlementDetails(ref int idCounter)
        {
            Settlement settlement = new Settlement();
            settlement.Id = idCounter;
            Console.WriteLine("\nEnter settlement details:");
            Console.Write("Student Id: ");
            settlement.StudentId = int.Parse(Console.ReadLine());
            Console.Write("Hostel Id: ");
            settlement.HostelId = int.Parse(Console.ReadLine());
            settlement.CheсkInTime = DateTime.Now;
            Console.Write("How much time would you be there?(Months): ");
            uint amountOfMonths = uint.Parse(Console.ReadLine());
            settlement.CheсkOutTime = DateTime.Now.AddMonths(int.Parse(amountOfMonths.ToString()));
            return settlement;
        }

        static Student InputStudentDetails(ref int idCounter)
        {
            Student student = new Student();
            student.Id = idCounter;
            Console.WriteLine("\nEnter student details:");
            Console.Write("Name: ");
            student.Name = Console.ReadLine();
            Console.Write("Faculty: ");
            student.Faculty = Console.ReadLine();
            Console.Write("Cathedra: ");
            student.Cathedra = Console.ReadLine();
            Console.Write("Course: ");
            student.Course = int.Parse(Console.ReadLine());
            Console.Write("Gender: ");
            student.Gender = Console.ReadLine();
            Console.Write("Year Of Birth: ");
            student.YearOfBirth = int.Parse(Console.ReadLine());
            return student;
        }

        static void SaveDataToXml(List<Commandant> commandants, List<Hostel> hostels, List<Settlement> settlements, List<Student> students)
        {
            string filePath = "console.xml";

            XmlWriterSettings settings = new XmlWriterSettings
            {
                Indent = true,
                IndentChars = "\t",
                NewLineChars = "\n",
                NewLineHandling = NewLineHandling.Replace
            };

            using (XmlWriter writer = XmlWriter.Create(filePath, settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Data");

                // Save commandants
                writer.WriteStartElement("Commandants");
                foreach (var commandant in commandants)
                {
                    writer.WriteStartElement("Commandant");
                    writer.WriteElementString("Id", commandant.Id.ToString());
                    writer.WriteElementString("Name", commandant.Name);
                    writer.WriteElementString("Age", commandant.Age.ToString());
                    writer.WriteElementString("Experience", commandant.Age.ToString());
                    writer.WriteElementString("Gender", commandant.Gender);
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();

                // Save hostels
                writer.WriteStartElement("Hostels");
                foreach (var hostel in hostels)
                {
                    writer.WriteStartElement("Hostel");
                    writer.WriteElementString("Id", hostel.Id.ToString());
                    writer.WriteElementString("Address", hostel.Address);
                    writer.WriteElementString("AmountOfRooms", hostel.AmountOfRooms.ToString());
                    writer.WriteElementString("CommandantId", hostel.CommandantId.ToString());
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();

                // Save settlements
                writer.WriteStartElement("Settlements");
                foreach (var settlement in settlements)
                {
                    writer.WriteStartElement("Settlement");
                    writer.WriteElementString("Id", settlement.Id.ToString());
                    writer.WriteElementString("StudentId", settlement.StudentId.ToString());
                    writer.WriteElementString("HostelId", settlement.HostelId.ToString());
                    writer.WriteElementString("CheсkInTime", settlement.CheсkInTime.ToString());
                    writer.WriteElementString("CheсkOutTime", settlement.CheсkOutTime.ToString());
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();

                // Save students
                writer.WriteStartElement("Students");
                foreach (var student in students)
                {
                    writer.WriteStartElement("Student");
                    writer.WriteElementString("Id", student.Id.ToString());
                    writer.WriteElementString("Name", student.Name);
                    writer.WriteElementString("Faculty", student.Faculty);
                    writer.WriteElementString("Cathedra", student.Cathedra);
                    writer.WriteElementString("Course", student.Course.ToString());
                    writer.WriteElementString("Gender", student.Gender);
                    writer.WriteElementString("YearOfBirth", student.YearOfBirth.ToString());

                    writer.WriteEndElement();
                }
                writer.WriteEndElement();

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }
    }
}