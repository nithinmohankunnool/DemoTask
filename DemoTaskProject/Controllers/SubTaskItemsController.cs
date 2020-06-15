using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DemoTaskProject.Models;

namespace DemoTaskProject.Controllers
{
    public class SubTaskItemsController : Controller
    {
        private readonly AppDbContext _context;

        public SubTaskItemsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: SubTaskItems
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //  var subtasklist =  _context.SubTaskItems
            //   .SelectOrDefault(m => m.TaskId == id);

            var subtasklist = _context.SubTaskItems
                .Where(m => m.TaskId == id)
                .ToList();
                

            //List<SubTaskItem> subtasklist = _context.SubTaskItems.ToList();

            
            if (subtasklist == null)
            {
                return NotFound();
            }

            return View(subtasklist);

        }

        // GET: SubTaskItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subTaskItem = await _context.SubTaskItems
                .FirstOrDefaultAsync(m => m.SubTaskId == id);
            if (subTaskItem == null)
            {
                return NotFound();
            }

            return View(subTaskItem);
        }

        // GET: SubTaskItems/Create
        public IActionResult Create()
        {

            var subTaskItem =  _context.SubTaskItems
               .FirstOrDefault();
            return View(subTaskItem);
        }

        // POST: SubTaskItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SubTaskId,SubTaskName,SubDescription,SubStartDate,SubFinishDate,SubState,TaskId")] SubTaskItem subTaskItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subTaskItem);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", new { id= subTaskItem.TaskId});
            }

            updateTaskItemState(subTaskItem.TaskId);
            return View(subTaskItem);
        }

        // GET: SubTaskItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subTaskItem = await _context.SubTaskItems.FindAsync(id);
            if (subTaskItem == null)
            {
                return NotFound();
            }

            
            return View(subTaskItem);
        }

        // POST: SubTaskItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SubTaskId,SubTaskName,SubDescription,SubStartDate,SubFinishDate,SubState,TaskId")] SubTaskItem subTaskItem)
        {
            if (id != subTaskItem.SubTaskId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subTaskItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubTaskItemExists(subTaskItem.SubTaskId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                updateTaskItemState(subTaskItem.TaskId);
                return RedirectToAction("Index", new { id = subTaskItem.TaskId });
            }
            return View(subTaskItem);
        }

        // GET: SubTaskItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subTaskItem = await _context.SubTaskItems
                .FirstOrDefaultAsync(m => m.SubTaskId == id);
            if (subTaskItem == null)
            {
                return NotFound();
            }

            return View(subTaskItem);
        }

        // POST: SubTaskItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subTaskItem = await _context.SubTaskItems.FindAsync(id);
            _context.SubTaskItems.Remove(subTaskItem);
            await _context.SaveChangesAsync();

            updateTaskItemState(subTaskItem.TaskId);
            return RedirectToAction("Index", new { id = subTaskItem.TaskId });

          

        }

        private bool SubTaskItemExists(int id)
        {
            return _context.SubTaskItems.Any(e => e.SubTaskId == id);
        }
        
        protected void updateTaskItemState(int TaskID)
        {
            int count = 0, count1=0;
            count = _context.SubTaskItems.Count(c => c.SubState != "Finished" && c.TaskId==TaskID);

            if(count !=0)
            {
                var taskexisting = new TaskItem { TaskId = TaskID, State="Finished" };

                
                    _context.TaskItems.Attach(taskexisting);
                    _context.Entry(taskexisting).Property(X => X.State).IsModified = true;
                    _context.SaveChanges();
                

            }

            count1 = _context.SubTaskItems.Count(c => c.SubState == "set" || c.SubState == "InProgress" || c.SubState == "Planned" && c.TaskId == TaskID);

            if (count != 0)
            {
                var taskexisting = new TaskItem { TaskId = TaskID, State = "InProgress" };
                _context.TaskItems.Attach(taskexisting);
                _context.Entry(taskexisting).Property(X => X.State).IsModified = true;
                _context.SaveChanges();
            }
        }


    }
}
