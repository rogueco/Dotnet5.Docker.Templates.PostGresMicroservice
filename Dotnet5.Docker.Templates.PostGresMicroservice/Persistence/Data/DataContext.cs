using Microsoft.EntityFrameworkCore;

namespace Dotnet5.Docker.Templates.PostGresMicroservice.DataContext
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

        public DbSet<TodoItem> TodoItems { get; set; }
    }
}