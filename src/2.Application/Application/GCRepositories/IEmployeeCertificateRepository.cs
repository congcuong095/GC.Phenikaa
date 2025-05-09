namespace Application.GCRepositories;

public interface IEmployeeCertificateRepository
{
    void UpdateEmployeeCertificate(string userId, string certificateId);
}
