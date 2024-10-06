using Microsoft.EntityFrameworkCore;

public class ApplicationDB: DbContext {
    public ApplicationDB(DbContextOptions<ApplicationDB> applicationDB): base(applicationDB)
    {
        
    }

    public DbSet<Stock> Stocks {get; set;}
    public DbSet<Comment> Comments {get; set;}
}