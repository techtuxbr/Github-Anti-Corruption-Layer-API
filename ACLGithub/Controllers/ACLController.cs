using ACLGithub.Adapters.Implementations;
using ACLGithub.DTOS;
using ACLGithub.Entities;
using ACLGithub.Mediators;
using ACLGithub.Mediators.Implementations;
using ACLGithub.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ACLGithub.Controllers;


[ApiController]
[Route("/")]
public class ACLController : Controller
{
    private readonly IGithubService githubService;

    public ACLController(IGithubService githubService)
    {
        this.githubService = githubService;
    }
    
    [HttpGet]
    [Route("repository/branches")]
    public async Task<BranchResponseDTO> GetBranches(string owner, string repository)
    {
        BranchResponseDTO apiResponse = await githubService.GetBranchesFromRepository(owner,repository);
        Response.StatusCode = (int)apiResponse.StatusCode;
        return apiResponse;
    }
    
    [HttpPost]
    [Route("repository")]
    public async Task<RepositoryCreationResponseDTO> CreateRepository(string name, string description, bool isPrivate = false)
    { 
        RepositoryCreationResponseDTO apiResponse = await githubService.CreateRepository(name, description, isPrivate);
        Response.StatusCode = (int)apiResponse.StatusCode;
        return apiResponse;
    }
    
    [HttpGet]
    [Route("repository/webhooks")]
    public async Task<WebhookResponseDTO> GetWebhooks(string owner, string repository)
    {
        WebhookResponseDTO apiResponse =  await githubService.GetWebhooksFromRepository(owner,repository);
        Response.StatusCode = (int)apiResponse.StatusCode;
        return apiResponse;
    }
    
    [HttpPost]
    [Route("repository/webhooks")]
    public async Task<WebhookResponseDTO> CreateWebhookOnRepository(string owner, string repository, string webhookUrl)
    {
        WebhookResponseDTO apiResponse =  await githubService.GetWebhooksFromRepository(owner,repository);
        Response.StatusCode = (int)apiResponse.StatusCode;
        return apiResponse;
    }
    
    [HttpPatch]
    [Route("repository/webhooks")]
    public async Task<WebhookResponseDTO> UpdateWebhookOnRepository(string owner, string repository, string webhookId ,string newWebhookUrl)
    {
        WebhookResponseDTO apiResponse =  await githubService.UpdateWebhookUrlOnRepository(owner,repository,webhookId,newWebhookUrl);
        Response.StatusCode = (int)apiResponse.StatusCode;
        return apiResponse;
    }
    
}