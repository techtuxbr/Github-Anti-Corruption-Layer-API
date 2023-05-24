using System.Diagnostics;
using System.Net;
using ACLGithub.Adapters;
using ACLGithub.Adapters.Implementations;
using ACLGithub.DTOS;
using ACLGithub.Entities;
using ACLGithub.Mediators;
using ACLGithub.Mediators.Implementations;
using Newtonsoft.Json;
using RestSharp;

namespace ACLGithub.Services.Implementations;

public class GithubService: IGithubService
{
    private readonly IGithubMediator mediator;

    public GithubService(IGithubMediator mediator)
    {
        this.mediator = mediator;
    }

    public async Task<WebhookResponseDTO> GetWebhooksFromRepository(string user, string repository)
    {
        try
        {
            RestResponse response = await mediator.RequestEndpoint($"repos/{user}/{repository}/branches", GithubAPIMethod.GET);
            List<Webhook> webhooks = JsonConvert.DeserializeObject<List<Webhook>>(response.Content);
            return new WebhookResponseDTO(response.StatusCode,webhooks, response.StatusDescription);
        }
        catch (Exception e)
        {
            // Se eu estivesse trabalhando em um sistema em produção real, nesse momento iria salvar qualquer stack de erro em um Log na nuvem. LogService.Store(e)
            return new WebhookResponseDTO(HttpStatusCode.InternalServerError,null, "Não foi possível obter os weebhooks deste repositório neste momento!");
        }
    }

    public async Task<BranchResponseDTO> GetBranchesFromRepository(string user, string repository)
    {
        try
        {
            RestResponse response = await mediator.RequestEndpoint($"repos/{user}/{repository}/branches", GithubAPIMethod.GET);
            List<Branch> branches = JsonConvert.DeserializeObject<List<Branch>>(response.Content);
            BranchResponseDTO aclResponse = new BranchResponseDTO(response.StatusCode,branches,response.StatusDescription);
            return aclResponse;
        }
        catch (Exception e)
        {
            // Se eu estivesse trabalhando em um sistema em produção real, nesse momento iria salvar qualquer stack de erro em um Log na nuvem. LogService.Store(e)
            return new BranchResponseDTO(HttpStatusCode.InternalServerError,null, "Não foi possível obter os branches deste repositório neste momento!");
        }
    }

    public async Task<RepositoryCreationResponseDTO> CreateRepository(string name, string description, bool isPrivate = false)
    {
        try
        {
            RestResponse response = await mediator.RequestEndpoint($"/user/repos", GithubAPIMethod.POST, new {name, description, @private = isPrivate});

            if (response.StatusCode  == HttpStatusCode.OK)
            {
                return new RepositoryCreationResponseDTO(response.StatusCode,"Repositório Criado com Sucesso!");
            }
            else
            {
                return new RepositoryCreationResponseDTO(response.StatusCode, "Ocorreu um problema durante a criação do repositório!");
            
            }
        }
        catch (Exception e)
        {
            // Se eu estivesse trabalhando em um sistema em produção real, nesse momento iria salvar qualquer stack de erro em um Log na nuvem. LogService.Store(e)
            return new RepositoryCreationResponseDTO(HttpStatusCode.InternalServerError, "Ocorreu um problema durante a criação do repositório!");
        }
    }

    public async Task<WebhookResponseDTO> CreateWebhookOnRepository(string owner, string repository ,string webhookUrl)
    {
        
        var body = new
        {
            name = "web",
            active = true,
            events = new[] { "push", "pull_request" },
            config = new
            {
                url = webhookUrl,
                content_type = "json"
            }
        };

        try
        {
            RestResponse response = await mediator.RequestEndpoint($"repos/{owner}/{repository}/hooks", GithubAPIMethod.POST, body);
            WebhookResponseDTO webhookResponse = new WebhookResponseDTO(response.StatusCode, null, response.StatusDescription);
            return webhookResponse;
        }
        catch (Exception e)
        {
            // Se eu estivesse trabalhando em um sistema em produção real, nesse momento iria salvar qualquer stack de erro em um Log na nuvem. LogService.Store(e)
            return new WebhookResponseDTO(HttpStatusCode.InternalServerError, null, "Ocorreu um problema durante a criação do webhook!");
        }
        
    }

    public async Task<WebhookResponseDTO> UpdateWebhookUrlOnRepository(string owner, string repository, string webhookId, string newWebhookUrl)
    {
        
        var requestBody = new
        {
            config = new
            {
                url = newWebhookUrl,
                content_type = "json"
            }
        };
        
        try
        {
            RestResponse response = await mediator.RequestEndpoint($"repos/{owner}/{repository}/hooks/{webhookId}", GithubAPIMethod.PATCH, requestBody);
            WebhookResponseDTO webhookResponse = new WebhookResponseDTO(response.StatusCode, null, response.StatusDescription);
            return webhookResponse;
        }
        catch (Exception e)
        {
            // Se eu estivesse trabalhando em um sistema em produção real, nesse momento iria salvar qualquer stack de erro em um Log na nuvem. LogService.Store(e)
            return new WebhookResponseDTO(HttpStatusCode.InternalServerError, null, "Ocorreu um problema durante a atualização do webhook!");
        }
        
    }
}