using System.Security.Cryptography.X509Certificates;

class Request
{
    public required string Title { get; set; }
    public Guid ID { get; set; }

}