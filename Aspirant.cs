using System;

namespace JambApp
{
    public class Aspirant
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string NIN { get; set; }
        public string Gender { get; set; } 
        public string State { get; set; }
        public string RegistrationNumber { get; set; }
        public string Institution { get; set; }
        public string Course { get; set; }

        public string TestName { get; set; }
        
        public Aspirant(string firstName, string lastName, DateTime dateOfBirth, string address, string email, string nIN, string gender, string state, string registrationNumber, string institution, string course, string middleName = "")
        {
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
            DateOfBirth = dateOfBirth;
            Address = address;
            Email = email;
            NIN = nIN;
            Gender = gender;
            State = state;
            RegistrationNumber = registrationNumber;
            Institution = institution;
            Course = course;
        }        
    }
}