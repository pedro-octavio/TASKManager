using System;
using Microsoft.AspNetCore.Mvc;
using TASKManager.Domain.Core.Interfaces.Services;
using TASKManager.Domain.Entities;

namespace TASKManager.APP.Controllers
{
    public class TaskManagerController : Controller
    {
        private readonly ITaskService _taskService;

        public TaskManagerController(ITaskService taskService) => _taskService = taskService;

        public ActionResult Index()
        {
            try
            {
                return View(_taskService.GetAll());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult Details(int? id)
        {
            try
            {
                if (id == null) return NotFound();

                var task = _taskService.GetById(id.Value);

                if (task == null) return NotFound();

                return View(task);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Id,Title,Descripton,Importancy,IsActive")] Task task)
        {
            try
            {
                _taskService.Add(task);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult Edit(int? id)
        {
            try
            {
                if (id == null) return NotFound();

                var task = _taskService.GetById(id.Value);

                if (task == null) return NotFound();

                return View(task);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("Id,Title,Descripton,Importancy,IsActive")] Task task)
        {
            try
            {
                _taskService.Update(task);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult Delete(int? id)
        {
            try
            {
                if (id == null) return NotFound();

                var task = _taskService.GetById(id.Value);

                if (task == null) return NotFound();

                return View(task);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                _taskService.Remove(id);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool TaskExists(int id)
        {
            try
            {
                return _taskService.GetById(id) != null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
