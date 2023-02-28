using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.IO;


namespace studentportal
{
    internal class Program
    {
        class Global
        {
            public static  string fileName = "students.json";
            public static  string path = Path.Combine(Directory.GetCurrentDirectory(), fileName);
  
        }
  
        static void Main(string[] args)
        {
            Console.WriteLine(Global.path);
            bool menu = true;
            Console.WriteLine(Messages.lineBreak);
            Console.WriteLine("Hello welcome to the Students Portal");
            Console.WriteLine(Messages.lineBreak);
            Console.WriteLine("Here you can do the following things:");


            do
            {

                
                Console.Write("1.Add new student\n2.Display all students\n3.Update existing student\n4.Exit\n Select one : ");
                string userSelection = Console.ReadLine();
                switch (userSelection)
                {
                    case "1":
                        Add();
                        break;
                    case "2":
                        DisplayAllStudents();
                        break;
                    case "3":
                        Console.Write("Enter the user id: ");
                        var id = Console.ReadLine();
                        Modify(id);
                        break;
                    case "4":
                        Environment.Exit(0);
                        menu = false;
                        break;
                    default:
                        Console.WriteLine(Messages.InvalidInput);
                        break;
                }
            } while (menu == true);

        }


        public static void DisplayAllStudents()
        {
            if (!File.Exists(Global.path))
            {
                Console.WriteLine(Messages.NoRecordFound);
                return;
            }
            string json = File.ReadAllText(Global.path);
            List<StudentClass> students = JsonConvert.DeserializeObject<List<StudentClass>>(json);
            Console.WriteLine(Messages.lineBreak);
            foreach (StudentClass student in students)
            {
                Console.WriteLine($"\tID: {student.Id}");
                Console.WriteLine($"\tFirst Name: {student.FirstName}");
                Console.WriteLine($"\tLast Name: {student.LastName}");
                Console.WriteLine($"\tAge: {student.Age}");
                Console.WriteLine($"\tContact #: {student.ContactNo}");
                Console.WriteLine($"\tCity: {student.City}");
                Console.WriteLine($"\tClass: {student.Standard}");
                Console.WriteLine(Messages.lineBreak);
            }
        }


        public static void Add()
        {

            Console.WriteLine("Enter the following info");
            Console.Write("First name: ");
            string fname = Console.ReadLine();
            Console.Write("Last name: ");
            string lname = Console.ReadLine();
            Console.Write("Age : ");
            string age = Console.ReadLine();
            Console.Write("Contact No: ");
            string ContactNo = Console.ReadLine();
            Console.Write("Class: ");
            string standard = Console.ReadLine();
            Console.Write("City: ");
            string city = Console.ReadLine();

            StudentClass student = new StudentClass(fname, lname, age, ContactNo, standard, city);

            if (!File.Exists(Global.path))
            {
                FileStream fs = File.Create(Global.path);
                fs.Close();
            }
            string array = File.ReadAllText(Global.path);

            List<StudentClass> students = JsonConvert.DeserializeObject<List<StudentClass>>(array) ?? new List<StudentClass>();

            students.Add(student);

            string updatedJson = JsonConvert.SerializeObject(students);

            File.WriteAllText(Global.path, updatedJson);
            Console.WriteLine(Messages.lineBreak);
            Console.WriteLine(Messages.studentAdded);
            Console.WriteLine(Messages.lineBreak);


        }

        public static void Modify(string id)
        {
            string json = File.ReadAllText(Global.path);
            List<StudentClass> students = JsonConvert.DeserializeObject<List<StudentClass>>(json);
            StudentClass student = students.FirstOrDefault(s => s.Id == $"{id}");
            if (student != null)
            {
                Console.WriteLine("Enter the following info");
                Console.Write("First name: ");
                string fname = Console.ReadLine();
                Console.Write("Last name: ");
                string lname = Console.ReadLine();
                Console.Write("Age : ");
                string age = Console.ReadLine();
                Console.Write("Contact No: ");
                string ContactNo = Console.ReadLine();
                Console.Write("Class: ");
                string standard = Console.ReadLine();
                Console.Write("City: ");
                string city = Console.ReadLine();

                student.FirstName = fname;
                student.LastName = lname;
                student.Age = age;
                student.ContactNo = ContactNo;
                student.Standard = standard;
                student.City = city;

                string updatedJson = JsonConvert.SerializeObject(students);
                File.WriteAllText(Global.path, updatedJson);
                Console.WriteLine(Messages.lineBreak);
                Console.WriteLine(Messages.RecordUpdated);
                Console.WriteLine(Messages.lineBreak);

            }
            else
            {
                Console.WriteLine(Messages.NoRecordFound);
            }
        }
    }
}
