using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MyTodoList.Models;
using MyTodoList.Models.Entities;

namespace MyTodoList.Controllers
{
    public class TodoController : Controller
    {
        private readonly IRepository _repository;
        public TodoController(IRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View(_repository.GetTodos());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Todo todo)
        {
            if (ModelState.IsValid)
            {
                _repository.Create(todo);
                return RedirectToAction("Index","Todo");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
       
                var todo = _repository.GetById(id);
                if (todo != null)
                {
                    return View(todo);
                }
                return NotFound();
        }

        [HttpPost]
        public IActionResult Edit(Todo todo)
        {
            if (ModelState.IsValid)
            {
                _repository.Update(todo);
                return RedirectToAction("Index", "Todo");
            }
            return View(todo);
        }
        public ViewResult Show(int id)
        {
            var todo = _repository.GetById(id);
            return View(todo);
        }
        public IActionResult Delete(int id)
        {
            _repository.Delete(id);
            return RedirectToAction("Index" , "Todo");
        }
         
    }
}