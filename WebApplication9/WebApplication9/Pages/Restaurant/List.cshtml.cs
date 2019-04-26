using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using RestApp.Data;
using RestApp.Core;
namespace WebApplication9.Pages.Restaurant
{
    public class ListModel : PageModel
    {
        readonly IConfiguration config;
        readonly IRestaurantData restaurantData;

        public string Messgae { get; set; }
        public IEnumerable<RestApp.Core.Restaurant> Restaurants { get; set; }

        [BindProperty(SupportsGet =true)]
        public string SearchTerm { get; set; }

        public ListModel(IConfiguration config, IRestaurantData restaurantData)
        {
            this.config = config;
            this.restaurantData = restaurantData;
        }
        public void OnGet()
        {
            //Messgae = "Hello, World";

            Messgae = config["Message"];
            // Restaurants = restaurantData.GetRestaurantsByName(searchTerm);
            Restaurants = restaurantData.GetRestaurantsByName(SearchTerm);

        }
    }
}