using Application.GCRepositories;

namespace Application.IGCUnitOfWork;

public interface IGCUnitOfWork
{
    IEmployeeCertificateRepository EmployeeCertificate { get; }
    void Commit();
    void Rollback();
}
