using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoAPI.Entities;
using TodoAPI.Models;

namespace TodoAPI.Services
{
    public class TodoService : ITodoService
    {
        private TodoContext _context;

        public TodoService(TodoContext context)
        {
            _context = context;
        }

        public TodoItem Create(TodoItem item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TodoItem> GetAll()
        {
            throw new NotImplementedException();
        }

        public TodoItem GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(TodoItem item)
        {
            throw new NotImplementedException();
        }
    }
}
