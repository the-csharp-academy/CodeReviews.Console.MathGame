using MathGame;

string name = Helpers.GetName();
var date = DateTime.UtcNow;
var menu = new Menu();

menu.ShowMenu(name, date);