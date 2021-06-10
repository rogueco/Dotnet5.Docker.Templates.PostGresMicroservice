// -----------------------------------------------------------------------
// <copyright company="N/A." file="DataContext.cs">
// </copyright>
// <author>
// Thomas Fletcher, Average Developer
// tom@tomfletcher.tech
// </author>
// -----------------------------------------------------------------------

#region usings
using Microsoft.EntityFrameworkCore;
#endregion

namespace Dotnet5.Docker.Templates.PostGresMicroservice.Persistence.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<TodoItem> TodoItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TodoItem>();

            // You can do it this way to create seed data. I've done it the other way so that the
            // Database is automatically created for us
            // By doing it this way, as you add you add a migration, the data will be added in there.
            // modelBuilder.Entity<TodoItem>().HasData(
            //     new List<TodoItem>
            //     {
            //         new TodoItem
            //         {
            //             Id = Guid.NewGuid(),
            //             Name = "Test",
            //             IsCompleted = false
            //         }
            //     });
        }
    }
}