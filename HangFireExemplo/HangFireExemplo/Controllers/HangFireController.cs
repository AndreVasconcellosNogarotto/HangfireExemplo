using Hangfire;
using HangFireExemplo.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HangFireExemplo.Controllers;
public class HangFireController : ControllerBase
{
    private IEmailService _emailService;
    private IBackgroundJobClient _backgroundJobClient;
    private IRecurringJobManager _recurringJobManager;

    public HangFireController(IEmailService emailService, IBackgroundJobClient backgroundJobClient, IRecurringJobManager recurringJobManager)
    {
        _emailService = emailService;
        _backgroundJobClient = backgroundJobClient;
        _recurringJobManager = recurringJobManager;
    }

    [HttpGet]
    [Route("FireAndForgetJob")]
    public ActionResult CreateFireAndForgetJog()
    {
        var jobId = BackgroundJob.Enqueue(() => _emailService.SendEmail("Fire-And-Forget-Job", DateTime.Now.ToLongTimeString()));
        //RecurringJob.AddOrUpdate(() => _emailService.SendEmail("Fire-And-Forget-Job", DateTime.Now.ToLongTimeString()), Cron.Daily);
        BackgroundJob.Enqueue(jobId, () => Console.WriteLine($"Email enviado com sucesso do id {jobId}"));

        //_backgroundJobClient.Schedule(() => _emailService.SendEmail("Fire-And-Forget-Job", DateTime.Now.ToLongTimeString()),TimeSpan.FromMinutes(2));
        return Ok($"Background Job Executando com o id {jobId}.");
    }

}
