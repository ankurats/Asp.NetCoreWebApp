using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestApp.Data;

namespace WebApplication9.Pages.Restaurant
{
    public class DetailModel : PageModel
    {
         IRestaurantData restaurantData { get; set; }
        [TempData]
        public string Message { get; set; }
        public DetailModel(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }
        public RestApp.Core.Restaurant Restaurnat { get; set; }
        public IActionResult OnGet(int restaurantId)
        {
            //Restaurnat = new RestApp.Core.Restaurant();
            //Restaurnat.Id = restaurantId;
            Restaurnat = restaurantData.GetById(restaurantId);

            if (Restaurnat == null)
                return RedirectToPage("./NotFound");
            return Page();

        }
    }
}