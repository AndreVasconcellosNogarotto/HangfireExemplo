namespace HangFireExemplo.Interfaces;

public class EmailService : IEmailService
{
    public string SendEmail(string jobType, string startTime)
    {
        Console.WriteLine(jobType + " " + startTime + "- Email enviado com sucesso - " + DateTime.Now.ToLongTimeString());
        var id = Guid.NewGuid();
        return id.ToString();
    }
}
