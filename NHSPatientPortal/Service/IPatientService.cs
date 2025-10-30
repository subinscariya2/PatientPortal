using PatientPortal.Models;

namespace PatientPortal.Service
{
    public interface IPatientService
    {
        Patient? GetPatientDatabyId(int id);
    }
}
