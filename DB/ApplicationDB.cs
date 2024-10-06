using Microsoft.EntityFrameworkCore;

class ApplicationDB: DbContext {
    public ApplicationDB(DbContextOptions applicationDB): base(applicationDB)
    {
        
    }

    public DbSet<Stock> Stocks {get; set;}
    public DbSet<Comment> Comments {get; set;}
}