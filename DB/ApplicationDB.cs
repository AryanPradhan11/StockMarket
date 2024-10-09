using Microsoft.EntityFrameworkCore;

public class ApplicationDB: DbContext {
    public ApplicationDB(DbContextOptions<ApplicationDB> applicationDB): base(applicationDB)
    {
        
    }

    public DbSet<Stock> Stocks {get; set;}
    public DbSet<Comment> Comments {get; set;}
    public DbSet<CustomerModel> Customer {get; set;}
    public DbSet<DoctorModel> Doctor {get; set;} 
}