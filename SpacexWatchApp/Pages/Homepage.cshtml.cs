using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SpacexWatchApp.Data;
using SpacexWatchApp.Models;

namespace SpacexWatchApp.Pages
{
    public class HomepageModel : PageModel
    {
        private readonly SpacexWatchApp.Data.LaunchesContext _context;

        public HomepageModel(SpacexWatchApp.Data.LaunchesContext context)
        {
            _context = context;
        }

        public IList<SavedLaunches> SavedLaunches { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.SavedLaunches != null)
            {
                SavedLaunches = await _context.SavedLaunches.ToListAsync();
            }
        }
    }
}
