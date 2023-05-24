using ACLGithub.Mediators;
using RestSharp;

namespace ACLGithub.Adapters;

public interface IGithubRestMethodAdapter
{
    Method GetRESTMethod(GithubAPIMethod method);
}