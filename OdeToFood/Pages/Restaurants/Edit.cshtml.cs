using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFood.Core;
using OdeToFood.Data.Interfaces;
using System.Collections.Generic;

namespace OdeToFood.Pages.Restaurants
{
    public class EditModel : PageModel
    {
        private readonly IRestaurantData restaurantData;

        private IHtmlHelper htmlHelper { get; }

        [BindProperty]
        public Restaurant Restaurant { get; set; }

        public IEnumerable<SelectListItem> Cuisines { get; set; }


        public EditModel(IRestaurantData restaurantData, IHtmlHelper htmlHelper)
        {
            this.restaurantData = restaurantData;
            this.htmlHelper = htmlHelper;
        }


        public IActionResult OnGet(int? restaurantId)
        {
            Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();

            if (restaurantId.HasValue)
            {
                Restaurant = restaurantData.GetRestaurantById(restaurantId.Value);
            }
            else
            {
                Restaurant = new Restaurant();
            }


            if (Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
                return Page();
            }

            if (Restaurant.Id > 0)
            {
                restaurantData.UpdateRestaurantInfo(Restaurant);
            }
            else
            {
                Restaurant = restaurantData.AddRestaurant(Restaurant);
            }

            restaurantData.Commit();

            TempData["Message"] = "Restaurant saved!";

            return RedirectToPage("./Detail", new { restaurantId = Restaurant.Id });


        }
    }
}
