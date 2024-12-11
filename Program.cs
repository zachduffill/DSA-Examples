using DSA_Examples;
using static DSA_Examples.MainMenu;

MainMenu menu = new MainMenu();
while (true)
{
    menu.Display();
    (bool shouldExit, MenuItem? selectedItem) = menu.HandleInput(); // if user presses exit key, null item is returned,
    
    if (shouldExit) return 0;
    
    if (selectedItem != null)
    {
        Example? example = (Example?)Activator.CreateInstance(selectedItem.Type);
        if (example == null) throw new ApplicationException($"Could not create instance of {selectedItem.Name}");

        Test<object?>[] tests = example.tests;

        for (int i = 0; i < tests.Length; i++)
        {
            if (tests[i].Run())
            {
                Console.WriteLine($"Test {i + 1}: Success");
            }
            else
            {
                Console.WriteLine($"Test {i + 1}: Failure");
            }
            Console.WriteLine();
        }
        Console.WriteLine("Press enter to return to menu");
        Console.ReadLine();
    }
}