// -----------------------------------------------------------------------
// <copyright company="N/A." file="ITodoRepository.cs">
// </copyright>
// <author>
// Thomas Fletcher, Average Developer
// tom@tom-fletcher.co.uk
// </author>
// -----------------------------------------------------------------------

#region usings
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dotnet5.Docker.Templates.PostGresMicroservice.Persistence.Data;
using Microsoft.AspNetCore.Mvc;
#endregion

namespace Dotnet5.Docker.Templates.PostGresMicroservice.Repositories
{
    public interface ITodoRepository
    {
        /// <summary>
        /// Simple call to return all Todo items
        /// </summary>
        /// <returns>An IEnumerable of TodoItem</returns>
        Task<IEnumerable<TodoItem>> GetAllTodos();


        /// <summary>
        /// Simple method to return a single Todo item
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns a single TodoItem</returns>
        Task<TodoItem> GetTodoById(Guid id);
        
        /// <summary>
        /// Simple create method
        /// </summary>
        /// <param name="todoItem"></param>
        /// <returns>Returns created TodoItem</returns>
        Task<bool> CreateTodo(TodoItem todoItem);
 
        /// <summary>
        /// Simple update method that takes in a TodoItem to update
        /// </summary>
        /// <param name="todoItem"></param>
        /// <returns>Returns updated TodoItem</returns>
        Task<TodoItem> UpdateTodo(TodoItem todoItem);
        
        /// <summary>
        /// Simple Delete Method that expects an a TodoItem's id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns True/False based on the success of the deletion</returns>
        Task<bool> DeleteTodo(Guid id);
    }
}