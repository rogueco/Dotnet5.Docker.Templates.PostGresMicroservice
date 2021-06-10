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
using System.ComponentModel.DataAnnotations;
#endregion

namespace Dotnet5.Docker.Templates.PostGresMicroservice.Persistence.Data
{
    public class TodoItem
    {
        /// <summary>
        /// Get or Sets the Id. 
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Get or Sets the Name. 
        /// </summary>
        /// <value>Sets the Name on TodoItem</value>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Get or Sets the Name. 
        /// </summary>
        /// <value>Sets the status on TodoItem</value>
        [Required]
        public bool IsCompleted { get; set; }
    }
}