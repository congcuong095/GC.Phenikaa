using Application.GCRepositories;

namespace Application.GCUnitOfWork;

public interface IGCUnitOfWork
{
    IEmployeeCertificateRepository EmployeeCertificate { get; }
    IAgentMessageRepository AgentMessage { get; }
    void Commit();
    void Rollback();
}
