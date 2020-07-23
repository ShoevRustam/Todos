using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTodoList.Models.Entities
{
    public interface IRepository
    {
        List<Todo> GetTodos();
        void Delete(int id);
        void Update(Todo todo);
        Todo GetById(int id);
        void Create(Todo todo);
    }
}
