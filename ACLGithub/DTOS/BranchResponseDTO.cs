using System.Net;
using ACLGithub.Entities;

namespace ACLGithub.DTOS;

public class BranchResponseDTO
{
    public HttpStatusCode StatusCode { get; set; }
    public List<Branch> Data { get; set; }
    public string Message { get; set; }

    public BranchResponseDTO(HttpStatusCode statusCode, List<Branch> data, string message)
    {
        StatusCode = statusCode;
        Data = data;
        Message = message;
    }
}