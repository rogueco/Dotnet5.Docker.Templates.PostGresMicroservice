// -----------------------------------------------------------------------
// <copyright company="N/A." file="TodoSeedDataContext.cs">
// </copyright>
// <author>
// Thomas Fletcher, Average Developer
// tom@tomfletcher.tech
// </author>
// -----------------------------------------------------------------------

#region usings
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dotnet5.Docker.Templates.PostGresMicroservice.Persistence.Data;
#endregion

namespace Dotnet5.Docker.Templates.PostGresMicroservice.Persistence.Seed
{
    public static class TodoSeedDataContext
    {
        public static async Task SeedData(DataContext dataContext)
        {
            if (!dataContext.TodoItems.Any())
            {
                List<TodoItem> todos = new()
                {
                    new TodoItem
                    {
                        Id = Guid.NewGuid(),
                        Name = "Re-watch Star Wars Episode 3",
                        IsCompleted = false
                    },
                    new TodoItem
                    {
                        Id = Guid.NewGuid(),
                        Name = "Watch Nobody",
                        IsCompleted = true
                    },
                    new TodoItem
                    {
                        Id = Guid.NewGuid(),
                        Name = "Finish Desk setup",
                        IsCompleted = false
                    },
                    new TodoItem
                    {
                        Id = Guid.NewGuid(),
                        Name = "Create Multiple Docker Microservice Templates",
                        IsCompleted = false
                    },
                };
                
                await dataContext.TodoItems.AddRangeAsync(todos);
                await dataContext.SaveChangesAsync();
            }
        }
        
    }
}