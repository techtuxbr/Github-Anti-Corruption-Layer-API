using System.Net;
using ACLGithub.Entities;

namespace ACLGithub.DTOS;

public class WebhookResponseDTO
{
    public HttpStatusCode StatusCode { get; set; }
    public List<Webhook> Data { get; set; }
    public string Message { get; set; }

    public WebhookResponseDTO(HttpStatusCode statusCode, List<Webhook> data, string message)
    {
        StatusCode = statusCode;
        Data = data;
        Message = message;
    }
}