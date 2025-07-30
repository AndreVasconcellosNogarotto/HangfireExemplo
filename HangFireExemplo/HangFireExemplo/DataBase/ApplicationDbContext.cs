using Microsoft.EntityFrameworkCore;

namespace HangFireExemplo.DataBase;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }
}
