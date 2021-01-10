using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CatalogOfWehicle.Data;
using CatalogOfWehicle.Models;

namespace CatalogOfWehicle.Pages.Wehicles
{
    public class CreateModel : PageModel
    {
        private readonly CatalogOfWehicle.Data.CatalogOfWehicleContext _context;

        public CreateModel(CatalogOfWehicle.Data.CatalogOfWehicleContext context)
        {
            _context = context;
        }

        public IActionResult OnGet() // так как никаких состояний не содержится, то просто вызывваем Page()
        {
            return Page(); //  этот метод создает PageResult, который формирует страницу Create.cshtml
        }

        [BindProperty] // используем этот атрибут для указания согласия на привязку модели
        public Wehicle Wehicle { get; set; }

        // если тип Task<IActionResult> то нужен return
        public async Task<IActionResult> OnPostAsync() //выполняется, когда страница публикует данные формы
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Wehicle.Add(Wehicle);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
