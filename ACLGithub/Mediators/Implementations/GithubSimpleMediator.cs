using ACLGithub.Adapters;
using Newtonsoft.Json;
using RestSharp;

namespace ACLGithub.Mediators.Implementations;

public class GithubSimpleMediator: IGithubMediator
{
    private string token;
    private string baseUrl;
    private readonly IGithubRestMethodAdapter restMethodAdapter;

    public GithubSimpleMediator(IGithubRestMethodAdapter restMethodAdapter)
    {
        
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        var githubToken = configuration["GithubToken"];
        
        this.token = githubToken;
        baseUrl = "https://api.github.com/";
        this.restMethodAdapter = restMethodAdapter;
    }
    
    public async Task<RestResponse> RequestEndpoint(string endpoint, GithubAPIMethod method, object requestBody = null)
    {
        string apiUrl = baseUrl;

        RestClient client = new RestClient(apiUrl);
        RestRequest request = new RestRequest(endpoint,restMethodAdapter.GetRESTMethod(method));
        request.AddHeader("Content-Type", "application/json");
        request.AddHeader("Authorization", $"Bearer {token}");

        if (requestBody != null)
        {
            request.AddJsonBody(requestBody);
        }

        RestResponse response = await client.ExecuteAsync(request);
        return response;
    }
}