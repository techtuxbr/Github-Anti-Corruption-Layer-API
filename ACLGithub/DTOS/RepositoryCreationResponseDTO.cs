using System.Net;

namespace ACLGithub.DTOS;

public class RepositoryCreationResponseDTO
{
    public HttpStatusCode StatusCode { get; set; }
    public string Data { get; set; }

    public RepositoryCreationResponseDTO(HttpStatusCode statusCode, string data)
    {
        StatusCode = statusCode;
        Data = data;
    }
}