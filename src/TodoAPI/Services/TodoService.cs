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

            if (_context.TodoItems.Count() == 0)
            {
                _context.TodoItems.Add(entity: new TodoItem { Name = "Item1" });
                _context.SaveChanges();
            }
        }

        public IEnumerable<TodoItem> GetAll() => _context.TodoItems.OrderBy(x => x.Id).ToList();

        public TodoItem GetById(long id) => _context.TodoItems.Find(id);

        public TodoItem Create(TodoItem item)
        {
            _context.TodoItems.Add(item);
            _context.SaveChanges();

            return item;
        }

        public void Update(TodoItem item)
        {
            _context.TodoItems.Update(item);
            _context.SaveChanges();
        }

        public void Delete(TodoItem item)
        {
            _context.TodoItems.Remove(item);
            _context.SaveChanges();
        }
        
    }
}
