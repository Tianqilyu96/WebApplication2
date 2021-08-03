using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication4.Models;

namespace WebApplication4.Pages.Admin
{
    public class AddRecipeModel : PageModel
    {
        [FromRoute] //pull id value from route dictionary
        public long? Id { get; set; } //nullable long type

        public bool IsNew { get { return Id == null; } }

        public Recipe Recipe { get; set; }
        public void OnGet()
        {
        }
    }
}
