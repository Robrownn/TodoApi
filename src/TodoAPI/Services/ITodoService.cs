using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoAPI.Entities;

namespace TodoAPI.Services
{
    public interface ITodoService
    {
        IEnumerable<TodoItem> GetAll();
        TodoItem GetById(int id);
        TodoItem Create(TodoItem item);
        void Update(TodoItem item);
        void Delete(int id);
    }
}
