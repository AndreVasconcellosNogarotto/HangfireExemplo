namespace HangFireExemplo.Interfaces;

public interface IEmailService
{
    string SendEmail(string jobType, string startTime);
}
