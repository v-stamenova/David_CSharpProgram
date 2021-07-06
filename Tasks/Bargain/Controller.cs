using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bargain
{
	class Controller
	{
		List<User> users = new List<User>();
		List<Advert> adverts = new List<Advert>();

		public User RegisterUser()
		{
			Console.Write("Please insert nickname: ");
			string nickname = Console.ReadLine();
			while(users.Any(x => x.Nickname == nickname))
			{
				Console.Write("This nickname is already used. Please insert another: ");
				nickname = Console.ReadLine();
			}

			Console.Write("Please insert password: ");
			string password = Console.ReadLine();

			Console.WriteLine("Successful registration!");
			User user = new User(nickname, password);
			users.Add(user);
			return user;
		}

		public User LoginUser()
		{
			Console.Write("Please insert nickname: ");
			string nickname = Console.ReadLine();
			Console.Write("Please insert password: ");
			string password = Console.ReadLine();

			while(!users.Any(x => x.Nickname == nickname && x.Password == password))
			{
				Console.WriteLine("Invalid username or password, please insert them again");
				Console.Write("Please insert nickname: ");
				nickname = Console.ReadLine();
				Console.Write("Please insert password: ");
				password = Console.ReadLine();
			}

			return users.Find(x => x.Nickname == nickname && x.Password == password);
		}

		public void ListOfAllActiveAdverts()
		{
			Console.WriteLine(string.Join(Environment.NewLine, adverts.Where(x => x.Active).ToList()));
		}

		public void ListOfRegisteredAdvertsFromUser(User user)
		{
			Console.WriteLine(string.Join(Environment.NewLine, user.RegisteredAdverts));
		}

		public void ListOfWonAdvertsFromUser(User user)
		{
			Console.WriteLine(string.Join(Environment.NewLine, user.WonAdverts));
		}
	}
}
