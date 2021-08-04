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
        private readonly IRecipesService recipesService;
        [FromRoute] //pull id value from route dictionary
        public long? Id { get; set; } //nullable long type

        public bool IsNew { get { return Id == null; } }

        public Recipe Recipe { get; set; }

        public AddRecipeModel(IRecipesService recipesService)
        {
            this.recipesService = recipesService;
        }

        /*whenever this Razor Page is requested through an HTTP Get request, 
         * like when you navigate to the page in the browser, 
         * Razor Pages looks for a method named OnGet and executes it prior to rendering the Razor in the CSHTML page.
         * Likewise, when a Razor Page is requested with an HTTP Post request, as is what happens during a form post, 
         * Razor Pages looks for a method named OnPost and executes it prior to rendering the page's markup.*/
        public async Task OnGetAsync()
        {
            Recipe = await recipesService.FindAsync(Id.GetValueOrDefault()) ?? new Recipe();
        }

        /*Since this is an asynchronous method returning a task already, 
         * that means I'm going to change the type of the task to the generic Task<IActionResult. 
         * An action result is Razor Pages' way of communicating what you want to happen to the request after the method has been run.*/

        //However, if your method returns 'void' or a task without a return value,
        //then Razor Pages treats that as the equivalent as returning a page result
        //there are plenty of other types of action results that allow you to do things
        //such as return a custom HTTP status code, reject the request as unauthenticated,
        //redirect to another URL, or even render some raw content directly into the response
        //that has nothing to do with the markup in the Razor Page.


        public async Task<IActionResult> OnPostAsync()
        {
            return RedirectToPage("/Recipe", new { id = Id }); //redirect to recipe page with route data "id"
        }
    }
}
