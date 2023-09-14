using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Routing;

namespace Advanced_Csharp_Lab2_Blazor.Data
{
    public class MenuService
    {

        private List<MenuItem> menuOptions = new List<MenuItem>();
        private NavigationManager navigationManager;

        //oncreate 
        public MenuService(NavigationManager navigationManager)
        {
            //add options to menu
            menuOptions.Add(new MenuItem { Name = "Home", Url = "/" });
            menuOptions.Add(new MenuItem { Name = "Relational Database", Url = "/reldb" });
            menuOptions.Add(new MenuItem { Name = "Document Database", Url = "/docdb" });
            menuOptions.Add(new MenuItem { Name = "About", Url = "/about" });

            //assign navmanager
            this.navigationManager = navigationManager;
        }

        public List<MenuItem> GetMenu()
        {
            return menuOptions;
        }

        public MenuItem GetCurrentItem()
        {
            //get current route by replacing baseurl with empty string
            string route = navigationManager.Uri.Replace(navigationManager.BaseUri, "");
            //add leading slash
            route = "/" + route;
            //find item with mathing route
            return menuOptions.Where(option => option.Url.Contains(route)).FirstOrDefault();
        }

        //util
        public class MenuItem
        {
            public string Name { get; set; }
            public string Url { get; set; }
        }
    }
}
