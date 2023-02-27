using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class StudentClass
    {
        public string Id { get;  set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Age { get; set; }   
        public string ContactNo { get; set; }
        public string Standard { get; set; }
        public string City { get; set; }

        public StudentClass(string firstName = "Not Set yet", string lastName = "Not Set yet", string age = "Not Set yet", string contactNo = "Not Set yet", string standard = "Not Set yet", string city = "Not Set yet")
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
}
