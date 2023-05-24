using RestSharp;

namespace ACLGithub.Mediators;

public interface IGithubMediator
{
    Task<RestResponse> RequestEndpoint(string endpoint, GithubAPIMethod method, dynamic requestBody = null);
}