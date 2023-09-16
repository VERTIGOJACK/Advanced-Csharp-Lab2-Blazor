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
            menuOptions.Add(new MenuItem { Name = "Home (API)", Url = "/" });
            menuOptions.Add(new MenuItem { Name = "Teachers (EF)", Url = "/reldb/teacher" });
            menuOptions.Add(new MenuItem { Name = "Courses (EF)", Url = "/reldb/course" });
            menuOptions.Add(new MenuItem { Name = "Students (MongoDB)", Url = "/docdb/student" });
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
            //find item with mathcing route
            MenuItem item = menuOptions.Where(option => option.Url.Contains(route)).FirstOrDefault();

            if (item == null) {
                //fallback for paths with id
                string[] split = route.Split('/');               
                item = menuOptions.Where(option => option.Url.Contains(split[split.Length-2])).FirstOrDefault();
            }

            return item;
        }

        //util
        public class MenuItem
        {
            public string Name { get; set; }
            public string Url { get; set; }
        }
    }
}
