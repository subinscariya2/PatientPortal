using PatientPortal.Models;

namespace PatientPortal.Repository
{
    public class PatientRepository : IPatientRepository
    {
        public static List<Patient> Patients = new()
        {
            new Patient { Id = 1, NHSNumber = "1800", Name = "Ben Stokes", DateOfBirth = new DateTime(1995, 5, 20), GPPractice = "Star Health Centre" },
            new Patient { Id = 2, NHSNumber = "1801", Name = "Jos Butler", DateOfBirth = new DateTime(1990, 10, 15), GPPractice = "Hays Surgery" },
            new Patient { Id = 3, NHSNumber = "1802", Name = "Mike Jay", DateOfBirth = new DateTime(1994, 10, 15), GPPractice = "British Surgery" },
            //Duplicate Record
            new Patient { Id = 3, NHSNumber = "1802", Name = "Mike Jay", DateOfBirth = new DateTime(1994, 10, 15), GPPractice = "British Surgery" },
            new Patient { Id = 4, NHSNumber = "1803", Name = "Smith", DateOfBirth = new DateTime(1991, 10, 15), GPPractice = "George Street Surgery" }
        };

        public Patient? GetPatientRecord(int id)
        {
            try
            {
                return Patients.SingleOrDefault(x => x.Id == id);
            }
            catch (Exception)
            {
                throw new ArgumentException("Duplicate Record Found");
            }
        }
    }
}
