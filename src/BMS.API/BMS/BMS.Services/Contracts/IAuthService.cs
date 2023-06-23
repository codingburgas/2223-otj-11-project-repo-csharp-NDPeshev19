using BMS.Services.Models.Auth;

namespace BMS.Services.Contracts;

public interface IAuthService
{
    Task<bool> CheckIfUserExistsAsync(string username);

    Task<bool> CheckIsPasswordCorrectAsync(string username, string password);

    Task<Tuple<bool, string?>> CreateWorkerAsync(WorkerIM workerIM, bool isAdmin = false);

    Task<Tuple<bool, string?>> CreatePatientAsync(PatientIM patientIM);

    Task<bool> CheckIsAdminAsync(string username);
}
