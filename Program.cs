using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.IO;


namespace Project1
{
    internal class Program
    {
        class Global
        {
            public static string path = @"C:\Users\sameer.tanveer\source\repos\Project1\Project1\students.json";

        }
        public static object JsonConvert { get; private set; }
        
        static void Main(string[] args)
        {
            bool menu = true;
            
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Hello welcome to the Student Portal");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Here you can do the following things:");
            do
            {

                Console.Write("1.Add new stuident\n2.Display all students\n3.Update existing student\n4.Exit\n Select one : ");
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
                        var id  = Console.ReadLine() ;
                        Modify(id);
                        break;
                    case "4":
                        Environment.Exit(0);
                        menu = false;
                        break;
                    default:
                        Console.WriteLine("invalid input! try again!");
                        break;
                }
            } while (menu == true);
            
        }


        public static void DisplayAllStudents()
        {
            
            string json = File.ReadAllText(Global.path);
            List<StudentClass> students = Newtonsoft.Json.JsonConvert.DeserializeObject<List<StudentClass>>(json);
            Console.WriteLine("---------------------------------------");
            foreach (StudentClass student in students)
            {
                Console.WriteLine($"\tID: {student.Id}");
                Console.WriteLine($"\tFirst Name: {student.FirstName}");
                Console.WriteLine($"\tLast Name: {student.LastName}");
                Console.WriteLine($"\tAge: {student.Age}");
                Console.WriteLine($"\tContact #: {student.ContactNo}");
                Console.WriteLine($"\tCity: {student.City}");
                Console.WriteLine($"\tClass: {student.Standard}");
                Console.WriteLine("---------------------------------------");
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
            
            string array = File.ReadAllText(Global.path);
            //Convert the array we are getting from the students.json to a LIST object
            List<StudentClass> students = Newtonsoft.Json.JsonConvert.DeserializeObject<List<StudentClass>>(array) ?? new List<StudentClass>();
           
            students.Add(student);
            //take the new LIST object and and returns a JSON string 
            string updatedJson = Newtonsoft.Json.JsonConvert.SerializeObject(students);
    
            File.WriteAllText(Global.path, updatedJson);
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("\tNew Student Added!!");
            Console.WriteLine("--------------------------------------------------------");


        }

        public static void Modify(string id)
        {
            string json = File.ReadAllText(Global.path);
            List<StudentClass> students = Newtonsoft.Json.JsonConvert.DeserializeObject<List<StudentClass>>(json);
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

                string updatedJson = Newtonsoft.Json.JsonConvert.SerializeObject(students);
                File.WriteAllText(Global.path, updatedJson);
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("\tStudent record updated successfully");
                Console.WriteLine("---------------------------------------");

            }
            else
            {
                Console.WriteLine("Student not found");
            }
        }
    }
}
