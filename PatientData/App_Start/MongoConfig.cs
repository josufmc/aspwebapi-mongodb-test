using PatientData.Models;
using System.Linq;
using MongoDB.Driver.Linq;
using MongoDB.Driver;
using System.Collections.Generic;

namespace PatientData
{
    public static class MongoConfig
    {
        public static void Seed()
        {
            var patients = PatientDb.Open();
            if (!patients.Find(p => p.Name == "Scott").Any()) {
                var data = new List<Patient>()
                {
                    new Patient
                    {
                        Name = "Scott",
                        Ailments = new List<Ailment>() { new Ailment { Name= "Crazy"} },
                        Medications = new List<Medication>() { new Medication { Name= "Medication1", Doses=1 } }
                    },
                    new Patient
                    {
                        Name = "Joy",
                        Ailments = new List<Ailment>() { new Ailment { Name= "Crazy"} },
                        Medications = new List<Medication>() { new Medication { Name= "Medication2", Doses=2 } }
                    },
                    new Patient
                    {
                        Name = "Sarah",
                        Ailments = new List<Ailment>() { new Ailment { Name= "Crazy"} },
                        Medications = new List<Medication>() { new Medication { Name= "Medication3", Doses=3 } }
                    }
                };
                patients.InsertMany(data);
            }
        }
    }
}