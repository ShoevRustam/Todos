using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTodoList.Models.Entities
{
    public class Repository : IRepository
    {
        private readonly TodoContext _context;

        public Repository(TodoContext context)
        {
             _context = context;
        }

        public void Create(Todo todo)
        {
            _context.Todos.Add(todo);
            Save();
        }

        public void Delete(int id)
        {
            var model = _context.Todos.Find(id);
            if(model!=null)
             _context.Todos.Remove(model);
            Save(); 
        }

        public Todo GetById(int id)
        {
            var todo = _context.Todos.Find(id);
            return todo;
        }

        public List<Todo> GetTodos()
        {
            return _context.Todos.ToList();
        }

        public void Update(Todo todo)
        {
            var upTodo = _context.Todos.Find(todo.Id);
            upTodo.Title = todo.Title;
            _context.Update(upTodo);
            Save();
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
