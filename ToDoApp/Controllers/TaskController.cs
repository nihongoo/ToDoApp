using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.Models;

namespace ToDoApp.Controllers
{
    public class TaskController : Controller
    {
        AppDbContext _dbContext;
        public TaskController()
        {
            _dbContext = new AppDbContext();
        }
        // GET: TaskController
        public ActionResult Index()
        {
            var listTasks = _dbContext.tasks.OrderByDescending(t=>t.CreateAt).ToList();
            return View(listTasks);
        }

        // GET: TaskController/Details/5
        public ActionResult Details(Guid id)
        {
            var task = _dbContext.tasks.Find(id);
            return View(task);
        }

        // POST: TaskController/Create
        [HttpPost]
        public ActionResult Create(Tasks item)
        {
            try
            {
                item.Id = Guid.NewGuid();
                item.IsCompleted = false;
                item.CreateAt = DateTime.Now;
                _dbContext.tasks.Add(item);
                _dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TaskController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var task = _dbContext.tasks.Find(id);
            return View(task);
        }

        // POST: TaskController/Edit/5
        [HttpPost]
        public ActionResult Edit(Tasks item)
        {
            try
            {
                var task = _dbContext.tasks.Find(item.Id);
                task.Id = item.Id;
                task.Title = item.Title;
                task.Description = item.Description;
                task.IsCompleted = item.IsCompleted;
                task.CreateAt = task.CreateAt;
                _dbContext.tasks.Update(task);
                _dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
		[HttpPost]
		public ActionResult EditTask(Guid Id)
		{
			try
			{
				var task = _dbContext.tasks.Find(Id);
                task.IsCompleted = true;
				_dbContext.tasks.Update(task);
				_dbContext.SaveChanges();
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: TaskController/Delete/5
		public ActionResult Delete(Guid id)
        {
            var task = _dbContext.tasks.Find(id);
            _dbContext.Remove(task);
            _dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

    }
}
