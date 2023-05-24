using ACLGithub.DTOS;
using ACLGithub.Entities;

namespace ACLGithub.Services;

public interface IGithubService
{
    Task<BranchResponseDTO> GetBranchesFromRepository(string user, string repository);

    Task<RepositoryCreationResponseDTO> CreateRepository(string name, string description, bool isPrivate = false);
    
    Task<WebhookResponseDTO> GetWebhooksFromRepository(string user, string repository);

    Task<WebhookResponseDTO> CreateWebhookOnRepository(string owner, string repository, string webhookUrl);
    
    Task<WebhookResponseDTO> UpdateWebhookUrlOnRepository(string owner, string repository, string webhookId, string newWebhookUrl);
}