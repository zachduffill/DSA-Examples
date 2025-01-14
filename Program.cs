using DSA_Examples.Menu;
using DSA_Examples.Utility;

MainMenu menu = new MainMenu();

while (true) // Menu display + input handling loop
{
    menu.Display();
    (bool shouldExit, MenuItem? selectedItem) = menu.HandleInput(); 
    
    if (shouldExit) return 0;
    
    if (selectedItem != null) // If an example is selected, try to create an instance of it, then run it's tests
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

        if (example.Tests != null) Test<object?>.RunTests(example.Tests);
    }
}