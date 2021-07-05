using System;
using System.Collections.Generic;
using System.Linq;

namespace AddressBook
{
	class Program
	{
		static List<AddressEntry> entries = new List<AddressEntry>();

		static void Main(string[] args)
		{
			Console.Write("Do you wish to add entry, remove entry, see all entries or order them? Add/Remove/All/Order: ");
			string input = Console.ReadLine();
			while (!string.IsNullOrWhiteSpace(input))
			{
				switch (input)
				{
					case "Add":
						Console.Write("On given position? Y/N: ");
						if (Console.ReadLine() == "Y")
							AddNewEntryOnPosition();
						else
							AddNewEntry();
						break;
					case "Remove":
						RemoveEntry();
						break;
					case "All":
						OutputAllEntries();
						break;
					case "Order":
						OrderInAlphabeticalOrder();
						break;
				}
				input = Console.ReadLine();
			}
		}

		static AddressEntry NewEntry()
		{
			Console.Write("Please insert a full name: ");
			string name = Console.ReadLine();
			Console.Write("Please insert address: ");
			string address = Console.ReadLine();
			Console.Write("Please insert number: ");
			string number = Console.ReadLine();

			return new AddressEntry(name, address, number);
		}

		static void AddNewEntry()
		{
			entries.Add(NewEntry());
		}

		static void AddNewEntryOnPosition()
		{
			AddressEntry entry = NewEntry();
			Console.Write("Insert a position: ");
			int position = int.Parse(Console.ReadLine());

			entries.Insert(position, entry);
		}

		static void RemoveEntry()
		{
			Console.Write("Please insert the position of the entry to be removed: ");
			int position = int.Parse(Console.ReadLine());

			entries.RemoveAt(position);
		}

		static void OrderInAlphabeticalOrder()
		{
			entries = entries.OrderBy(x => x.Name).ToList();
		}

		static void OutputAllEntries()
		{
			Console.WriteLine(string.Join(Environment.NewLine, entries));
		}
	}
}
