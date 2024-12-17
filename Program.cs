using DSA_Examples;
using DSA_Examples.Utility;
using static DSA_Examples.MainMenu;

MainMenu menu = new MainMenu();
while (true)
{
    menu.Display();
    (bool shouldExit, MenuItem? selectedItem) = menu.HandleInput(); 
    
    if (shouldExit) return 0;
    
    if (selectedItem != null)
    {
        Example? example;

        try
        {
            example = (Example?)Activator.CreateInstance(selectedItem.Type);
            if (example == null) throw new ApplicationException($"Instance of {selectedItem.Name} is null");
        }
        catch
        {
            throw new ApplicationException($"Could not create instance of {selectedItem.Name}");
        }

        Test<object?>.RunTests(example.Tests);
    }
}