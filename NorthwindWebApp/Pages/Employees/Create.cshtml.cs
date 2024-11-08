﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NorthwindWebApp.Models;

namespace NorthwindWebApp.Pages.Employees
{
    public class CreateModel : PageModel
    {
        private readonly NorthwindWebApp.Models.NorthwindDbContext _context;

        public CreateModel(NorthwindWebApp.Models.NorthwindDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ReportsTo"] = new SelectList(_context.Employees, "EmployeeId", "FirstName");
            return Page();
        }

        [BindProperty]
        public Employee Employee { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Employees.Add(Employee);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}