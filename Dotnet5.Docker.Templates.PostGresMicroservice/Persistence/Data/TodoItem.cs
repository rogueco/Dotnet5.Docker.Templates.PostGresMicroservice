using System;

namespace Dotnet5.Docker.Templates.PostGresMicroservice.DataContext
{
    public class TodoItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsCompleted { get; set; }
    }
}