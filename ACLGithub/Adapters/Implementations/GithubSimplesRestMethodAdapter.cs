using ACLGithub.Mediators;
using RestSharp;

namespace ACLGithub.Adapters.Implementations;

public class GithubSimplesRestMethodAdapter: IGithubRestMethodAdapter
{
    public Method GetRESTMethod(GithubAPIMethod method)
    {
        switch (method)
        {
            case GithubAPIMethod.GET:
                return Method.Get;
            case GithubAPIMethod.POST:
                return Method.Post;
            case GithubAPIMethod.PATCH:
                return Method.Patch;
            case GithubAPIMethod.DELETE:
                return Method.Delete;
            default:
                throw new Exception("Not Supported Method");
                break;
        }
    }
}