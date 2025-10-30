using PatientPortal.Models;
using PatientPortal.Repository;

namespace PatientPortal.Service
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public Patient? GetPatientDatabyId(int id)
        {
            var patient = _patientRepository.GetPatientRecord(id);

            if (patient != null)
            {
                if (string.IsNullOrWhiteSpace(patient.NHSNumber))
                    throw new ArgumentException("NHS Number is required.");

                if (string.IsNullOrWhiteSpace(patient.Name))
                    throw new ArgumentException("Patient name is required.");

                if (patient.DateOfBirth > DateTime.Today)
                    throw new ArgumentException("Date of birth cannot be in the future.");
            }

            return patient;
        }

    }
}
