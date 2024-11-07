using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NorthwindWebApp.Models;

namespace NorthwindWebApp.Pages.Orders
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
        ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerId");
        ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "FirstName");
        ViewData["ShipVia"] = new SelectList(_context.Shippers, "ShipperId", "CompanyName");
            return Page();
        }

        [BindProperty]
        public Order Order { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Orders.Add(Order);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
