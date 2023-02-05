using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DotNet_API_MVC.Context;
using DotNet_API_MVC.Models;

namespace DotNet_API_MVC.Controllers
{
    public class AssignmentController : Controller
    {
        private readonly ContextOrganizer _context;

        public AssignmentController(ContextOrganizer context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var assignments = from a in _context.Assignments
                            select a;
            return View(assignments);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Assignment assignment)
        {
            if(ModelState.IsValid)
            {
                _context.Assignments.Add(assignment);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(assignment);
        }

        public IActionResult Edit(int id)
        {
            var assignment = _context.Assignments.Find(id);

            if(assignment == null)
                return RedirectToAction(nameof(Index));

            return View(assignment);
        }        

        [HttpPost]
        public IActionResult Edit(Assignment assignment)
        {
            var assignmentDatabase = _context.Assignments.Find(assignment.Id);

            assignmentDatabase.Title = assignment.Title;
            assignmentDatabase.Description = assignment.Description;
            assignmentDatabase.Date = assignment.Date;
            assignmentDatabase.Status = assignment.Status;

            _context.Assignments.Update(assignmentDatabase);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            var assignment = _context.Assignments.Find(id);

            if(assignment == null)
                return RedirectToAction(nameof(Index));

            return View(assignment);
        }

        public IActionResult Delete(int id)
        {
            var assignment = _context.Assignments.Find(id);

            if(assignment == null)
                return RedirectToAction(nameof(Index));

            return View(assignment);
        }

        [HttpPost]
        public IActionResult Delete(Assignment assignment)
        {
            var assignmentDatabase = _context.Assignments.Find(assignment.Id);

            _context.Assignments.Remove(assignmentDatabase);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
