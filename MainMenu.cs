using System.Reflection;

namespace DSA_Examples
{
    internal class MainMenu
    {
        private MenuItem[] MenuItems { get; init; }
        private int MenuOffset { get; set; } 

        public class MenuItem
        {
            public string Name { get; init; }
            public Type Type { get; init; }

            public MenuItem(string name, Type type)
            {
                Name = name;
                Type = type;
            }

            public override string ToString()
            {
                return Name;
            }
        }

        public MainMenu()
        {
            MenuItems = LoadExamples();
            MenuOffset = 0;
        }

        static private MenuItem[] LoadExamples()
        {
            var types = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.Namespace == "DSA_Examples.Examples")
                .ToList();

            MenuItem[] menuItems = new MenuItem[types.Count()];

            for (int i = 0; i < menuItems.Count(); i++)
            {
                menuItems[i] = new MenuItem(types[i].Name, types[i]);
            }

            return menuItems;
        }

        public void Display()
        {
            Console.Clear();
            Console.WriteLine("DSA-Examples");
            Console.WriteLine("------------");
            Console.WriteLine();
            for (int i = 0; i < MenuItems.Count(); i++)
            {
                Console.WriteLine($"[{i}] {MenuItems[i]}");
            }
            Console.WriteLine();
            Console.WriteLine("[x] Exit");
        }

        public MenuItem? HandleInput()
        {
            ConsoleKeyInfo input = new ConsoleKeyInfo();
            while (!Char.IsDigit(input.KeyChar))
            {
                input = Console.ReadKey(true);
                Console.WriteLine(input);
                if (input.Key == ConsoleKey.UpArrow) Navigate(1);
                else if (input.Key == ConsoleKey.DownArrow) Navigate(-1);
                else if (input.Key == ConsoleKey.X) return null;
            }
            return MenuItems[int.Parse(input.KeyChar.ToString())+MenuOffset];
        }

        private void Navigate(int direction)
        {

        }
    }
}
