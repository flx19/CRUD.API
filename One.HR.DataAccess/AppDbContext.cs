using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using One.HR.DataAccess.Entities;

namespace One.HR.DataAccess
{
    public class AppDbcontext : IdentityDbContext<AppUser>
    {
        public AppDbcontext(DbContextOptions<AppDbcontext> dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Address> Addresses { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>()
                .Property(e => e.Email)
                .HasDefaultValue("sample@mail.com");
            modelBuilder.Entity<Address>()
                .HasData(
                  new Address
                  {
                      ID= 17,
                      Addressline1 = "Amir Temur , 1",
                      Addressline2 = "Amir temur , 2",
                      PostalCode = "141458",
                      City = "toshkent",
                      Country = "Uzbekiston"
                  }
                );
        }
    }
}