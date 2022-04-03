#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using R1.Core;
using R1.Data;

namespace R1.Pages
{
    public class CreateModel : PageModel
    {
        private readonly R1.Data.R1DbContext _context;
        private readonly IHtmlHelper htmlHelper;
       

        public IEnumerable<SelectListItem> Cuisines { get; set; }

        public CreateModel(R1.Data.R1DbContext context, IHtmlHelper htmlHelper)
        {
            _context = context;
            this.htmlHelper = htmlHelper;
        }

        public IActionResult OnGet()
        {
            Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
            return Page();
        }

        [BindProperty]
        public Restaurant Restaurant { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();


            _context.Restaurants.Add(Restaurant);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Index");
        }
    }
}
