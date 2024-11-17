using System.Net;

namespace GestionInventario.Common.Responses;

public class Response<T>
{
    public bool Success { get; set; }
    public T? Data { get; set; }
    public string Description { get; set; }
    public HttpStatusCode StatusCode { get; set; }

    private Response(string description, T? data, HttpStatusCode statusCode)
    {
        this.Description = description;
        this.Success = true;
        this.Data = data;
        this.StatusCode = statusCode;
    }

    public static Response<T> SuccessCreation(string description, T? data, HttpStatusCode statusCode) =>
        new Response<T>(description, data, HttpStatusCode.Created);

    public static Response<T> SuccessObtain(string description, T? data, HttpStatusCode statusCode) =>
        new Response<T>(description, data, HttpStatusCode.OK);
    
    public static Response<T> SuccessUpdate(string description, T? data, HttpStatusCode statusCode) =>
        new Response<T>(description, data, HttpStatusCode.OK);
}