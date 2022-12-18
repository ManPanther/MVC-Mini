using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace WatchShop.MVC.Views.Watch
{
    public class CreateVM
    {
        [Required(ErrorMessage = "Make is required")]
        public string Make { get; set; }

        [Required(ErrorMessage = "Price is required")]
        public decimal Price { get; set; }

        [Display(Name = "Watch type")]
        public SelectListItem[] WatchTypeItems { get; set; }

        [Range(1,3)]
        public int SelectedWatchTypeValue { get; set; }

    }
}
