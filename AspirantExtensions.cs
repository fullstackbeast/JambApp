using System;

namespace JambApp
{
    public static class AspirantExtensions
    {

        public static string ToAspirantString(this Aspirant aspirant)
        {
            string aspirantString = $"{aspirant.FirstName} - {aspirant.LastName} - {aspirant.DateOfBirth.ToString()} - {aspirant.Address} - {aspirant.Email} - {aspirant.NIN} - {aspirant.Gender} - {aspirant.State} - {aspirant.RegistrationNumber} - {aspirant.Institution} - {aspirant.Course} - {aspirant.MiddleName}";
            return aspirantString;
        }

        public static Aspirant Parse(this string aspirantString)
        {
            string[] aspirantDetails = aspirantString.Split("-");

            string firstName = aspirantDetails[0];
            string lastName = aspirantDetails[1];
            DateTime dateOfBirth = DateTime.Parse(aspirantDetails[2]);
            string address = aspirantDetails[3];
            string email = aspirantDetails[4];
            string nin = aspirantDetails[5];
            string gender = aspirantDetails[6];
            string state = aspirantDetails[7];
            string registrationNumber = aspirantDetails[8];
            string institution = aspirantDetails[9];
            string course = aspirantDetails[10];
            string middleName = aspirantDetails[11];

            Aspirant aspirant = new Aspirant(firstName, lastName, dateOfBirth, address, email, nin, gender, state, registrationNumber, institution, course, middleName);

            return aspirant;
        }

    }
}