using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CatalogOfWehicle.Data;
using CatalogOfWehicle.Models;

namespace CatalogOfWehicle.Pages.Wehicles
{
    public class EditModel : PageModel
    {
        private readonly CatalogOfWehicle.Data.CatalogOfWehicleContext _context;

        public EditModel(CatalogOfWehicle.Data.CatalogOfWehicleContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Wehicle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WehicleExists(Wehicle.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool WehicleExists(int id)
        {
            return _context.Wehicle.Any(e => e.ID == id);
        }
    }
}
