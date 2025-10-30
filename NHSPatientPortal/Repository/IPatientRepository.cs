using PatientPortal.Models;

namespace PatientPortal.Repository
{
    public interface IPatientRepository
    {
        Patient? GetPatientRecord(int id);
    }
}
