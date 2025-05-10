namespace Application.GCRepositories;

public interface IAgentMessageRepository
{
    Task UpdateAgentMessage(string id, bool isSent);
}
