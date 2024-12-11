using DSA_Examples;
using static DSA_Examples.MainMenu;

MainMenu menu = new MainMenu();
while (true)
{
    menu.Display();
    MenuItem? selectedItem = menu.HandleInput(); // if user presses exit key, null item is returned,
    if (selectedItem == null) return 0; // and program exits


}