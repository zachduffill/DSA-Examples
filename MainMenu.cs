using System.Reflection;

namespace DSA_Examples
{
    internal class MainMenu
    {
        private MenuItem[] MenuItems { get; init; }
        private int _menuOffset;
        private int MenuOffset 
        {
            get => _menuOffset;
            set
            {
                if (value >= 0 && value < MenuItems.Length - 9)
                {
                    _menuOffset = value;
                }
            }
        } 

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
            Console.OutputEncoding = System.Text.Encoding.UTF8;
        }

        static private MenuItem[] LoadExamples()
        {
            var types = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.Namespace == "DSA_Examples.Examples" && t.Name != "<>c")
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
            Console.WriteLine(MenuOffset > 0 ? "      ↑" : "");
            for (int i = MenuOffset; i < Math.Min(MenuItems.Length,10) + MenuOffset; i++)
            {
                Console.WriteLine($"[{i-MenuOffset}] {MenuItems[i]}");
            }
            Console.WriteLine(MenuOffset+11 <= MenuItems.Length ? "      ↓\n" : "\n");
            Console.WriteLine("[x] Exit");
        }

        public (bool,MenuItem?) HandleInput()
        {
            ConsoleKeyInfo input = new ConsoleKeyInfo();
            while (!Char.IsDigit(input.KeyChar))
            {
                input = Console.ReadKey(true);
                switch (input.Key)
                {
                    case ConsoleKey.UpArrow:
                        MenuOffset -= 1;
                        return (false, null);
                    case ConsoleKey.DownArrow:
                        MenuOffset += 1;
                        return (false, null);
                    case ConsoleKey.X:
                        return (true, null);
                }
            }
            return (false,MenuItems[int.Parse(input.KeyChar.ToString())+MenuOffset]);
        }
    }
}
