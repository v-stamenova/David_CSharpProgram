using System;
using System.Collections.Generic;
using System.Text;

namespace RationalNumbers
{
	struct Rational
	{
		private int numerator;
		private int denumerator;

		public int Numerator { get => this.numerator; }

		public int Denumerator { get => this.denumerator; }

		public Rational(int numerator, int denumerator)
		{
			this.numerator = numerator;

			if (denumerator == 0)
			{
				throw new Exception("The denumerator cannot be zero");
			}
			else
			{
				this.denumerator = denumerator;
			}
		}

		public static Rational operator+ (Rational a, Rational b)
		{
			return new Rational((a.numerator * b.denumerator + a.denumerator * b.numerator), a.denumerator * b.denumerator);
		}

		public static Rational operator- (Rational a, Rational b)
		{
			return new Rational((a.numerator * b.denumerator - a.denumerator * b.numerator), a.denumerator * b.denumerator);
		}

		public static Rational operator* (Rational a, Rational b)
		{
			return new Rational(a.numerator * b.numerator, a.denumerator * b.denumerator);
		}

		public static Rational operator/ (Rational a, Rational b)
		{
			if(b.numerator == 0)
			{
				throw new DivideByZeroException();
			}

			return new Rational(a.numerator * b.denumerator, a.denumerator * b.numerator);
		}

		//public static implicit operator Rational(int number)
		//{

		//}
	}
}
