using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;//для поиска
using Microsoft.EntityFrameworkCore;
using CatalogOfWehicle.Data;
using CatalogOfWehicle.Models;

namespace CatalogOfWehicle.Pages.Wehicles
{
    public class IndexModel : PageModel
    {
        private readonly CatalogOfWehicle.Data.CatalogOfWehicleContext _context;

        //добавляем на стрaницу контекст
        public IndexModel(CatalogOfWehicle.Data.CatalogOfWehicleContext context)
        {
            _context = context;
        }

        public IList<Wehicle> Wehicle { get;set; }

        // добавим для вывода поиска, фильтрации
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList ColorChoice { get; set; }
        [BindProperty(SupportsGet = true)]
        public string WehicleMark { get; set; }
        public string NumOfWehicle { get; set; }

        // Лист Wehicle заполняем асинхронно, OnGetAsync() - выводит список ТС
        public async Task OnGetAsync()
        {
            IQueryable<string> colorQuery = from m in _context.Wehicle
                                            orderby m.Color
                                            select m.Color;

            var wehicles = from m in _context.Wehicle
                           select m;

            var nums = (from n in _context.Wehicle
                       select n).Count();
            //nums = nums.Count();
            if (!string.IsNullOrEmpty(SearchString))
            {
                wehicles = wehicles.Where(s => s.ModelWehicle.Contains(SearchString)); //Contains - выполняется в БД!
            }


            if (!string.IsNullOrEmpty(WehicleMark))
            {
                wehicles = wehicles.Where(x => x.Color == WehicleMark);
            }
            ColorChoice = new SelectList(await colorQuery.Distinct().ToListAsync());

            Wehicle = await wehicles.ToListAsync();
            NumOfWehicle = nums.ToString();



            //Wehicle = await _context.Wehicle.ToListAsync();
        }
        
    }
}
