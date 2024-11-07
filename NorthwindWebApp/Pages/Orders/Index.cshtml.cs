using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NorthwindWebApp.Models;

namespace NorthwindWebApp.Pages.Orders
{
    public class IndexModel : PageModel
    {
        private readonly NorthwindWebApp.Models.NorthwindDbContext _context;

        public IndexModel(NorthwindWebApp.Models.NorthwindDbContext context)
        {
            _context = context;
        }

        public IList<Order> Order { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Order = await _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.Employee)
                .Include(o => o.ShipViaNavigation).ToListAsync();
        }
    }
}
