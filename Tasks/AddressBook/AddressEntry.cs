using System;
using System.Linq;

namespace AddressBook
{
	class AddressEntry
	{
		private string name;
		private string address;
		private string number;

		public string Name
		{
			get
			{
				return this.name;
			}
			set
			{
				if (string.IsNullOrWhiteSpace(value))
				{
					throw new Exception("The name cannot be empty");
				}
				else
				{
					this.name = value;
				}
			}
		}

		public string Address
		{
			get
			{
				return this.address;
			}
			set
			{
				if (string.IsNullOrWhiteSpace(value))
				{
					throw new Exception("The address cannot be empty");
				}
				else
				{
					this.address = value;
				}
			}
		}

		public string Number
		{
			get
			{
				return this.number;
			}
			set
			{
				if (value.All(char.IsDigit))
				{
					this.number = value;
				}
				else
				{
					throw new Exception("The phone number cannot contain other symbols except digits");
				}
			}
		}

		public AddressEntry(string name, string address, string number)
		{
			this.Name = name;
			this.Address = address;
			this.Number = number;
		}

		public override string ToString()
		{
			return $"{this.name} - {this.address} - {this.number}";
		}
	}
}
