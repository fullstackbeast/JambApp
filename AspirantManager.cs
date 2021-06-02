using System;
using System.Collections.Generic;
using System.IO;

namespace JambApp
{
    public class AspirantManager
    {
        private List<Aspirant> Aspirants = new List<Aspirant>();

        public void RegisterAspirant()
        {
            Registration registration = new Registration();

            Aspirant aspirant = registration.Register();

            Aspirants.Add(aspirant);
        }

        public List<Aspirant> GetAllAspirants()
        {
            return Aspirants;
        }

        public Aspirant GetAspirantByRegNumber(string regNumber)
        {
            foreach (var aspirant in Aspirants)
            {
                if (aspirant.RegistrationNumber.Trim() == regNumber)
                {

                    return aspirant;
                }
            }
            return null;
        }

        public List<Aspirant> GetAspirantsByInstitution(string institution)
        {
            List<Aspirant> institutionList = new List<Aspirant>();

            foreach (var aspirant in Aspirants)
            {
                if (aspirant.Institution.ToLower().Trim() == institution.ToLower())
                {
                    institutionList.Add(aspirant);
                }
            }

            return institutionList;

        }


        public void DeleteAspirant(Aspirant aspirant)
        {
            Aspirants.Remove(aspirant);
            RefreshFile();
        }

        public void RefreshList()
        {
            Aspirants = new List<Aspirant>();

            string[] aspirantsInFile = File.ReadAllLines("files//Aspirants.txt");
            foreach (string aspirant in aspirantsInFile)
            {
                Aspirants.Add(aspirant.Parse());
            }
        }

        public void RefreshFile()
        {
            List<string> aspirantString = new List<string>();

            foreach (var aspirant in Aspirants)
            {
                aspirantString.Add(aspirant.ToAspirantString());
            }
            File.WriteAllLines("files//Aspirants.txt", aspirantString);
        }
    }
}