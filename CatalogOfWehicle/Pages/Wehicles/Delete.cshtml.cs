using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CatalogOfWehicle.Data;
using CatalogOfWehicle.Models;

namespace CatalogOfWehicle.Pages.Wehicles
{
    public class DeleteModel : PageModel
    {
        private readonly CatalogOfWehicle.Data.CatalogOfWehicleContext _context;

        public DeleteModel(CatalogOfWehicle.Data.CatalogOfWehicleContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Wehicle Wehicle { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Wehicle = await _context.Wehicle.FirstOrDefaultAsync(m => m.ID == id);

            if (Wehicle == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Wehicle = await _context.Wehicle.FindAsync(id);

            if (Wehicle != null)
            {
                _context.Wehicle.Remove(Wehicle);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
