using System.Reflection;

namespace DSA_Examples
{
    internal class MainMenu
    {
        private MenuItem[] MenuItems { get; init; }

        private class MenuItem
        {
            public string Name { get; init; }

            public MenuItem(string name)
            {
                Name = name;
            }
        }

        public MainMenu()
        {
            MenuItems = LoadExamples();
            Console.WriteLine(MenuItems);
        }

        static private MenuItem[] LoadExamples()
        {
            var types = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.Namespace == "DSA_Examples.Examples")
                .ToList();

            MenuItem[] menuItems = new MenuItem[types.Count()];

            for (int i = 0; i < menuItems.Count(); i++)
            {
                menuItems[i] = new MenuItem(types[i].Name);
            }

            return menuItems;
        }

        public void Display()
        {

        }
    }
}
