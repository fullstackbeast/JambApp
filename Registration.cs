using System;

namespace JambApp
{
    public class Registration
    {
        public Aspirant Register()
        {
            Console.Write("Enter Your FirstName: ");
            string firstName = Console.ReadLine();

            Console.Write("Enter Your LastName: ");
            string lastName = Console.ReadLine();

            Console.Write("Enter Your MiddleName (optional): ");
            string middleName = Console.ReadLine();

            Console.Write("Enter Your Date of Birth (yyyy/mm/dd): ");
            DateTime dateOfBirth = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Enter Your Address: ");
            string address = Console.ReadLine();

            Console.Write("Enter Your Email: ");
            string email = Console.ReadLine();

            Console.Write("Enter Your NIN: ");
            string nin = Console.ReadLine();

            Console.Write("Enter Your Gender (male/female): ");
            string gender = Console.ReadLine();

            Console.Write("Enter Your State: ");
            string state = Console.ReadLine();

            Console.Write("Enter Your Institution: ");
            string institution = Console.ReadLine();

            Console.Write("Enter Your Course: ");
            string course = Console.ReadLine();

            string registrationNumber = GenerateRegNumber();
            Console.WriteLine($"Your Registration number is: {registrationNumber}");

            Aspirant aspirant = new Aspirant(firstName,lastName, dateOfBirth, address, email, nin, gender, state, registrationNumber, institution, course, middleName);

            return aspirant;
        }

        public static string GenerateRegNumber()
        {

            Random random = new Random();

            string numberInReg = random.Next(0, 1000000).ToString("000000");

            string regNumber = $"{GenerateRandomCharacter()}{GenerateRandomCharacter()}{numberInReg}{GenerateRandomCharacter()}";

            return regNumber;
        }

        private static char GenerateRandomCharacter()
        {
            Random random = new Random();
            int randomCharNum = random.Next(65, 91);
            char letter = (char)randomCharNum;
            return letter;
        }
    }
}