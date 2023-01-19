using ContactsCA.services;

var menu = new MenuManager();

menu.FilePath = @$"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\contacts.json";

while (true)
{
    Console.Clear();
    menu.WelcomeMenu();
}