using System.Reflection;

namespace DSA_Examples.Menu
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

        public MainMenu()
        {
            MenuItems = LoadExamples();
            MenuOffset = 0;
            Console.OutputEncoding = System.Text.Encoding.UTF8;
        }

        static private MenuItem[] LoadExamples()
        {
            var types = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.Namespace == "DSA_Examples.Examples" && t.Name != "<>c" && !t.IsNested)
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
            for (int i = MenuOffset; i < Math.Min(MenuItems.Length, 10) + MenuOffset; i++)
            {
                Console.WriteLine($"[{i - MenuOffset}] {MenuItems[i]}");
            }
            Console.WriteLine(MenuOffset + 11 <= MenuItems.Length ? "      ↓\n" : "\n");
            Console.WriteLine("[x] Exit");
        }

        public (bool, MenuItem?) HandleInput()
        {
            ConsoleKeyInfo input = new ConsoleKeyInfo();
            while (!char.IsDigit(input.KeyChar))
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
            int digitPressed = int.Parse(input.KeyChar.ToString());
            if (digitPressed + MenuOffset >= MenuItems.Length) return (false, null);
            return (false, MenuItems[digitPressed + MenuOffset]);
        }
    }
}
