using System;
using System.Security.Cryptography;

// namespace standard
namespace studentportal
{
    public class StudentClass
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Age { get; set; }
        public string ContactNo { get; set; }
        public string Standard { get; set; }
        public string City { get; set; }

        
        public StudentClass(string firstName, string lastName, string age , string contactNo, string standard, string city )
        {
            Id = GenerateRandomId();
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            ContactNo = contactNo;
            Standard = standard;
            City = city;

        }
        public void DisplayStudent()
        {
            Console.WriteLine(String.Format("Id: {6}\nFirst Name: {0}\nLast Name: {1}\nAge: {2}\nContact #: {3}\nClass: {4}\nCity: {5} ", FirstName, LastName, Age, ContactNo, Standard, City, Id));
        }
        private static string GenerateRandomId()
        {
            int idLength = 5;

            byte[] id = new byte[idLength];
           
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(id);
            }

            return BitConverter.ToString(id).Replace("-", "");
        }
    }


    public static class Messages
    {
        public const string NoRecordFound = "The user with the given id does'nt exist!";        
        public const string InvalidInput = "Invalid input!";
        public const string RecordUpdated = "Updated successfully!";
        public const string studentAdded = "New Student Added!";
        public const string lineBreak = "------------------------------------------";
    }
}
