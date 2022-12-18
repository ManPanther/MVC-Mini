using WatchShop.MVC.Views.Watch;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WatchShop.Models
{
    public class DataService
    {
        // Fake DB
        List<Watch> watches = new List<Watch>()
        {
            new Watch { Id = 234, Make = "Tag Heuer Aquaracer", Price = 35000, WatchType = 1},
            new Watch { Id = 1234, Make = "Casio G-Shock", Price = 2500, WatchType = 2},
            new Watch { Id = 15, Make = "Rolex Daytona", Price = 275000, WatchType = 3},
        };

        public IndexVM[] GetAllWatches()
        {
            return watches
                .Select(w => new IndexVM { Make = w.Make, Price = w.Price })
                .ToArray();

        }
        public void AddWatch(CreateVM viewModel)
        {
            Watch watch = new Watch();
            watch.Id = watches.Count == 0 ? 1 : watches.Max(w => w.Id) + 1;
            watch.Make = viewModel.Make;
            watch.Price = viewModel.Price;
            watch.WatchType = viewModel.SelectedWatchTypeValue;

            watches.Add(watch);
        }

        public CreateVM GetCreateVM()
        {
            return new CreateVM()
            {
                WatchTypeItems = new SelectListItem[]
                {
                    new SelectListItem { Value = "1", Text = "Manual"},
                    new SelectListItem { Value = "2", Text = "Automatic", Selected = true },
                    new SelectListItem { Value = "3", Text = "Chronograph"}
                }
            };
        }
    }
}
