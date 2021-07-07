using System;

namespace Bargain
{
	class Program
	{
		static void Main(string[] args)
		{
			Controller controller = new Controller();

			Console.WriteLine("Welcome! Please log in or register");
			while(controller.LoggedUser is null)
			{
				Console.Write("1 - Log in, 2 - Register, 3 - Exit: ");
				string line = Console.ReadLine();
				if(line == "1")
				{
					controller.LoggedUser = controller.LoginUser();
				}
				else if(line == "2")
				{
					controller.LoggedUser = controller.RegisterUser();
				}
				else if(line == "3")
				{
					controller.EndProgram();
				}
				else
				{
					Console.WriteLine("Invalid command, please insert valid number");
				}
			}
			Console.Clear();

			Console.WriteLine($"Hello {controller.LoggedUser.Nickname}");
			//Do the menu from a file because its too long
		}
	}
}
