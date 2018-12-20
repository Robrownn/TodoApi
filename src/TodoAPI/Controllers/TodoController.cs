using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using TodoAPI.Entities;
using TodoAPI.Services;

namespace TodoAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private ITodoService _todoService;

        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet]
        public ActionResult<List<TodoItem>> GetAll() => _todoService.GetAll().ToList();

        [HttpGet("{id}", Name = "GetTodo")]
        public ActionResult<TodoItem> GetById(long id)
        {
            var item = _todoService.GetById(id);
            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        [HttpPost]
        public IActionResult Create(TodoItem item)
        {
            _todoService.Create(item);

            return CreatedAtRoute("GetTodo", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, TodoItem item)
        {
            var todo = _todoService.GetById(id);
            if (todo == null)
            {
                return NotFound();
            }

            todo.IsComplete = item.IsComplete;
            todo.Name = item.Name;

            _todoService.Update(todo);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var todo = _todoService.GetById(id);
            if (todo == null)
            {
                return NotFound();
            }

            _todoService.Delete(todo);
            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(long id, [FromBody] JsonPatchDocument<TodoItem> item)
        {
            var todo = _todoService.GetById(id);
            if (todo == null)
            {
                return NotFound();
            }

            item.ApplyTo(todo);

            _todoService.Update(todo);
            return NoContent();
        }
    }
}