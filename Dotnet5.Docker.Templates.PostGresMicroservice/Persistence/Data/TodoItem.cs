// -----------------------------------------------------------------------
// <copyright company="N/A." file="TodoItem.cs">
// </copyright>
// <author>
// Thomas Fletcher, Average Developer
// tom@tomfletcher.tech
// </author>
// -----------------------------------------------------------------------

#region usings
using System;
#endregion

namespace Dotnet5.Docker.Templates.PostGresMicroservice.Persistence.Data
{
    public class TodoItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsCompleted { get; set; }
    }
}