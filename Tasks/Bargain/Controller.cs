using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bargain
{
	class Controller
	{
		private List<User> users = new List<User>();
		private List<Advert> adverts = new List<Advert>();
		private User loggedUser;

		public User LoggedUser { get => this.loggedUser; set => this.loggedUser = value; }

		public User RegisterUser()
		{
			Console.Write("Please insert nickname: ");
			string nickname = Console.ReadLine();
			while(users.Any(x => x.Nickname == nickname))
			{
				Console.WriteLine("Invalid nickname, do you wish to insert them again? Y/N");
				if (Console.ReadLine() == "Y")
				{
					Console.Write("Please insert nickname: ");
					nickname = Console.ReadLine();
				}
				else
				{
					return null;
				}
			}

			Console.Write("Please insert password: ");
			string password = Console.ReadLine();

			User user = new User(nickname, password);
			users.Add(user);
			Console.WriteLine("Successful registration!");
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
				Console.WriteLine("Invalid username or password, do you wish to insert them again? Y/N");
				if(Console.ReadLine() == "Y")
				{
					Console.Write("Please insert nickname: ");
					nickname = Console.ReadLine();
					Console.Write("Please insert password: ");
					password = Console.ReadLine();
				}
				else
				{
					return null;
				}
			}

			return users.Find(x => x.Nickname == nickname && x.Password == password);
		}

		public void ListOfAllActiveAdverts()
		{
			foreach(Advert advert in adverts)
			{
				if(advert.Active && (DateTime.Compare((DateTime)advert.EndDate, DateTime.Now) < 0))
				{
					advert.Active = false;
				}
			}

			 Console.WriteLine(string.Join(Environment.NewLine, adverts.Where(x => x.Active).ToList()));
		}

		public void ListOfRegisteredAdvertsFromUser(User user) => Console.WriteLine(string.Join(Environment.NewLine, user.RegisteredAdverts));
		
		public void ListOfWonAdvertsFromUser(User user) => Console.WriteLine(string.Join(Environment.NewLine, user.WonAdverts));

		public void BidOnAuction(User user, AuctionAdvert advert, decimal bid)
		{
			advert.Bid(bid, user);
		}

		public void BidOnAuction(User user)
		{
			Console.WriteLine("Please insert the description of the item");
			string itemDescription = Console.ReadLine();
			if (string.IsNullOrWhiteSpace(itemDescription))
			{
				throw new ArgumentException("The description cannot be empty");
			}

			Console.WriteLine("Please insert the bid price");
			
			if(!adverts.Any(x => x.ItemDescription == itemDescription))
			{
				throw new ArgumentException("There isn't a match");
			}
			if(!(adverts.Find(x => x.ItemDescription == itemDescription) is AuctionAdvert))
			{
				throw new Exception("The advert is not auction");
			}

			AuctionAdvert advert = (AuctionAdvert)adverts.Find(x => x.ItemDescription == itemDescription);
			Console.WriteLine($"The current bid is: {advert.StartingPrice}");
			Console.Write("$Your bid is: ");


			BidOnAuction(user, advert, decimal.Parse(Console.ReadLine()));
		}

		public void BuyDirectly(User user, DirectAdvert advert)
		{
			advert.EndAdvert(user);
		}

		public void BuyDirectly(User user, string itemDescription)
		{
			if (!adverts.Any(x => x.ItemDescription == itemDescription))
			{
				throw new ArgumentException("There isn't a match");
			}
			if (!(adverts.Find(x => x.ItemDescription == itemDescription) is DirectAdvert))
			{
				throw new Exception("The advert is not direct");
			}

			DirectAdvert advert = (DirectAdvert)adverts.Find(x => x.ItemDescription == itemDescription);

			BuyDirectly(user, advert);
		}

		public void LogOut()
		{
			loggedUser = null;
		}

		public void EndProgram()
		{
			Environment.Exit(0);
		}

		public void RegisterAuctionAdvert(User user)
		{
			Console.Write("Insert item description: ");
			string desc = Console.ReadLine();

			Console.Write("Insert starting price: ");
			decimal price = decimal.Parse(Console.ReadLine());

			Console.Write("Insert ending date (format: MM/DD/YYYY HH:MM:SS): ");
			DateTime time = DateTime.Parse(Console.ReadLine());

			adverts.Add(new AuctionAdvert(desc, user, price, time));
		}

		public void RegisterDirectAdvert(User user)
		{
			Console.Write("Insert item description: ");
			string desc = Console.ReadLine();

			Console.Write("Insert price: ");
			decimal price = decimal.Parse(Console.ReadLine());

			adverts.Add(new DirectAdvert(desc, user, price));
		}
	}
}
