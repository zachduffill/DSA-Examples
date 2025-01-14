
namespace DSA_Examples.Menu
{
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
}
