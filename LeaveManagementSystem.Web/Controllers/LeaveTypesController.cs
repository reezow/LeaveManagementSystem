using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LeaveManagementSystem.Web.Data;
using LeaveManagementSystem.Web.Models.LeaveTypesVM;
using AutoMapper;
using LeaveManagementSystem.Web.Services;

namespace LeaveManagementSystem.Web.Controllers
{
    public class LeaveTypesController(ILeaveTypeService _leaveTypeService) : Controller
    {
        //private readonly ILeaveTypeService _leaveTypeService = leaveTypeService;

        // GET: LeaveTypes
        public async Task<IActionResult> Index()
        {
            var viewData = await _leaveTypeService.GetAllLeaveTypes();
            return View(viewData);
        }

        // GET: LeaveTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveType = await _leaveTypeService.Get<LeaveTypeReadOnlyViewModel>(id.Value);

            if (leaveType == null)
            {
                return NotFound();
            }
            return View(leaveType);
        }


        // GET: LeaveTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LeaveTypes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( LeaveTypeCreateViewModel leaveTypeCreate)
        {
            // Custome Validation - check if leave type already exists
            if (await _leaveTypeService.CheckIfLeaveTypeNameExistsAsync(leaveTypeCreate.Name))
            {
                ModelState.AddModelError(nameof(leaveTypeCreate.Name), "This leave type already exists" +
                    "in the database");
            };

            if (ModelState.IsValid)
            {
                await _leaveTypeService.Create(leaveTypeCreate);
                return RedirectToAction(nameof(Index));
            }
            return View(leaveTypeCreate);
        }


        // GET: LeaveTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveType = await _leaveTypeService.Get<LeaveTypeEditViewModel>(id.Value);

            if (leaveType == null)
            {
                return NotFound();
            }
            return View(leaveType);
        }

        // POST: LeaveTypes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, LeaveTypeEditViewModel leaveTypeEdit)
        {
            if (id != leaveTypeEdit.Id)
            {
                return NotFound();
            }

            if (await _leaveTypeService.CheckIfLeaveTypeNameExistsForEditAsync(leaveTypeEdit))
            {
                ModelState.AddModelError(nameof(leaveTypeEdit.Name), "This leave type already exists" +
                    "in the database");
            };

            if (ModelState.IsValid)
            {
                try
                {
                    await _leaveTypeService.Edit(leaveTypeEdit);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_leaveTypeService.LeaveTypeExists(leaveTypeEdit.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(leaveTypeEdit);
        }


        // GET: LeaveTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveType = await _leaveTypeService.Get<LeaveTypeReadOnlyViewModel>(id.Value);

            if (leaveType == null)
            {
                return NotFound();
            }

            return View(leaveType);
        }

        // POST: LeaveTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _leaveTypeService.Remove(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
