using System;
using System.Collections.Generic;

namespace JambApp
{
    public class Menu
    {

        public static AspirantManager aspirantManager = new AspirantManager();

        public static void ShowMainMenu()
        {
            Console.Clear();
            Console.WriteLine("You are welcome to Jamb Online Registration app. ");
            Console.WriteLine("Press any of the options:");
            Console.WriteLine("0. Exit. ");
            Console.WriteLine("1. Register Aspirant. ");
            Console.WriteLine("2. List all Aspirant. ");
            Console.WriteLine("3. Enter Registration to print out information. ");
            Console.WriteLine("4. Update Candidate`s Info. ");
            Console.WriteLine("5. Delete Candidate`s Info. ");
            Console.WriteLine("6. List of Applicants with the same school.");
        }

        public static void ShowUpdateMenu()
        {
            Console.WriteLine("0. Back ");
            Console.WriteLine("1. Update First Name: ");
            Console.WriteLine("2. Update Last Name: ");
            Console.WriteLine("3. Update Middle Name: ");
        }

        public static void MainMenu()
        {
            aspirantManager.RefreshList();

            bool continueApp = true;

            do
            {
                ShowMainMenu();

                int options = Convert.ToInt32(Console.ReadLine());

                switch (options)
                {
                    case 0:
                        Console.WriteLine("Exit");
                        continueApp = false;
                        break;
                    case 1:
                        RegisterAspirant();
                        break;

                    case 2:
                        ListAllAspirants();
                        break;

                    case 3:
                        ShowInfo();
                        break;

                    case 4:
                        UpdateAspirant();
                        break;

                    case 5:
                        DeleteInfo();
                        break;

                    case 6:
                        InstitutionList();
                        break;
                }
            } while (continueApp);
        }

        public static void RegisterAspirant()
        {
            bool continueReg = true;

            while (continueReg)
            {
                aspirantManager.RegisterAspirant();

                Console.Write("Do you want to continue(y/n): ");
                string answer = Console.ReadLine().ToLower().Trim();

                if (answer == "n")
                {
                    aspirantManager.RefreshFile();
                    continueReg = false;
                }
            }
        }

        public static void ListAllAspirants()
        {
            List<Aspirant> allAspirants = aspirantManager.GetAllAspirants();
            foreach (var aspirant in allAspirants)
            {
                Console.WriteLine($"First Name: {aspirant.FirstName}, Last Name: {aspirant.LastName}, Registration Number: {aspirant.RegistrationNumber}");
            }
            Console.WriteLine("Press any key to go back to menu. ");
            Console.ReadKey();
        }

        public static void ShowInfo()
        {
            Console.WriteLine("Enter registration Number: ");
            string regNumber = Console.ReadLine().Trim();

            Aspirant aspirant = aspirantManager.GetAspirantByRegNumber(regNumber);

            if (aspirant == null)
            {
                Console.WriteLine("Student with this registration dosen`nt exist");
            }

            else
            {
                Console.WriteLine($"First Name: {aspirant.FirstName}");
                Console.WriteLine($"Last Name: {aspirant.LastName}");
                Console.WriteLine($"Registration Number: {aspirant.RegistrationNumber}");
            }
        }
        
        public static void DeleteInfo()
        {
            Console.WriteLine("Enter registration Number: ");
            string regNumber = Console.ReadLine().Trim();

            Aspirant aspirant = aspirantManager.GetAspirantByRegNumber(regNumber);

            if (aspirant == null)
            {
                Console.WriteLine("Aspirant not found");
                return;
            }

            Console.WriteLine($"Are you sure you wanna delete {aspirant.FirstName}{aspirant.LastName}?");
            Console.WriteLine("Yes/No");
            string answer = Console.ReadLine().ToLower().Trim();

            if (answer == "yes")
            {
                aspirantManager.DeleteAspirant(aspirant);
                Console.WriteLine("Aspirant deleted successfully");
            }

            else
            {
                Console.WriteLine("Operation Cancelled");
            }

        }

        public static void UpdateAspirant()
        {
            Console.WriteLine("Enter registration Number: ");
            string regNumber = Console.ReadLine().Trim();

            Aspirant aspirant = aspirantManager.GetAspirantByRegNumber(regNumber);

            if (aspirant == null)
            {
                Console.WriteLine("Student with this registration dosen`nt exist");
                Console.WriteLine("Press any key to go back to menu. ");
                Console.ReadKey();
            }

            else
            {
                Menu.ShowUpdateMenu();
                Console.Write("Enter option");

                int option = Convert.ToInt32(Console.ReadLine());

                if (option == 0)
                {
                    return;
                }

                else if (option == 1)
                {
                    Console.WriteLine("Enter new first name: ");
                    string updateFirstName = Console.ReadLine();
                    aspirant.FirstName = updateFirstName;
                    aspirantManager.RefreshFile();
                }

                else if (option == 2)
                {
                    Console.WriteLine("Enter new last name: ");
                    string updateLastName = Console.ReadLine();
                    aspirant.LastName = updateLastName;
                    aspirantManager.RefreshFile();
                }

                else if (option == 3)
                {
                    Console.WriteLine("Enter new middle name: ");
                    string updateMiddleName = Console.ReadLine();
                    aspirant.MiddleName = updateMiddleName;
                    aspirantManager.RefreshFile();
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                }
            }
        }

        public static void InstitutionList()
        {

            Console.WriteLine("Enter name of institution: ");
            string input = Console.ReadLine().Trim();

            List<Aspirant> institutionList = aspirantManager.GetAspirantsByInstitution(input);

            if (institutionList.Count == 0)
            {
                Console.WriteLine("No match found for the Institution. ");
                return;
            }

            foreach (var aspirant in institutionList)
            {
                Console.WriteLine($"First Name: {aspirant.FirstName}");
                Console.WriteLine($"Last Name: {aspirant.LastName}");
                Console.WriteLine($"Institution: {aspirant.Institution.Trim()}");
            }


        }
    }
}