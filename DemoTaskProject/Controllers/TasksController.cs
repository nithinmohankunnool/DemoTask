using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using DemoTaskProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace DemoTaskProject.Controllers
{
    public class TasksController : Controller
    {
        private readonly AppDbContext _db;
        public TasksController(AppDbContext db)
        {
            _db = db;
        }

        // GET: Tasks
        public ActionResult Index()
        {

            List<TaskItem> tasklist = _db.TaskItems.ToList();
           
            return View(tasklist);
        
        }

        // GET: Tasks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
                return NotFound();
            var singletask = _db.TaskItems
                                .Where(x => x.TaskId == id);

            return View(singletask);
        }

        // GET: Tasks/Create
        
        public ActionResult Create( int id)
        {
           

            //tasks.TaskName=;

            
            return View();
        }

        // POST: Tasks/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TaskItem task)
        {
            try
            {

                if (!ModelState.IsValid)
                    return View();

                _db.TaskItems.Add(task);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Tasks/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Tasks/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Tasks/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Tasks/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
