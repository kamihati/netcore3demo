using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ThreePage.Services;

namespace ThreePage.Pages.Department
{
    public class AddDepartmentModel : PageModel
    {
        private readonly IDepartmentService departmentService;

        [BindProperty]
        public Models.Department Department { get; set; }
         

        public AddDepartmentModel(IDepartmentService departmentService)
        {
            this.departmentService = departmentService;
        }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            await departmentService.Add(Department);
            return RedirectToPage("/Index");
        }
    }
}
