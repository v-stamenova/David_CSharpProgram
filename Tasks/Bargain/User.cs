using System;
using System.Collections.Generic;

namespace Bargain
{
	class User
	{
		private string nickname;
		private string password;
		private List<Advert> wonAdverts;
		private List<Advert> registeredAdverts;

		public string Nickname
		{
			get
			{
				return this.nickname;
			}
			set
			{
				if (string.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentNullException("The nickname cannot be empty");
				}
				else
				{
					this.nickname = value;
				}
			}
		}

		public string Password
		{
			get
			{
				return this.password;
			}
			set
			{
				if (string.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentNullException("The password cannot be empty");
				}
				else
				{
					this.password = value;
				}
			}
		}

		public List<Advert> WonAdverts { get => this.wonAdverts; set => this.wonAdverts = value; }

		public List<Advert> RegisteredAdverts { get => this.registeredAdverts; set => this.registeredAdverts = value; }

		public User(string nickname, string password)
		{
			this.Nickname = nickname;
			this.Password = password;
			this.wonAdverts = new List<Advert>();
		}
	}
}
