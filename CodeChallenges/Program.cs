// See https://aka.ms/new-console-template for more information
using CodeChallenges.Model;
using CodeChallenges.Utils;
using Microsoft.Extensions.Configuration;

//Gets the json file
var configuration = new ConfigurationBuilder()
				 .AddJsonFile($"appsettings.json");
var config = configuration.Build();

var reader = new ConsoleReader();
//builds the menu
var menu=new Menu(config,reader);
menu.ShowMainMenu();

int key = 0;
string? line;
bool keyValidation;
//Reads the user option
while (key!=151)
{
		line = Console.ReadLine();
		keyValidation = int.TryParse(line,out key);
		if (string.IsNullOrWhiteSpace(line)&& !keyValidation)
		{
				Console.WriteLine("please choose a valid option");
		}
		else
		{
				var option=menu.BuildOption(key);
				option?.Execute();
				
		}
		if(key!=151)
				Console.WriteLine("please choose another option");

}

Console.WriteLine("Press any key to finish");
Console.ReadLine();

