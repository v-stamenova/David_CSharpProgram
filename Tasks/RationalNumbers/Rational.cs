using System;

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
			Rational rational = new Rational((a.numerator * b.denumerator + a.denumerator * b.numerator), a.denumerator * b.denumerator);
			rational.Transform();
			return rational;
		}

		public static Rational operator- (Rational a, Rational b)
		{
			Rational rational =  new Rational((a.numerator * b.denumerator - a.denumerator * b.numerator), a.denumerator * b.denumerator);
			rational.Transform();
			return rational;
		}

		public static Rational operator* (Rational a, Rational b)
		{
			Rational rational = new Rational(a.numerator * b.numerator, a.denumerator * b.denumerator);
			rational.Transform();
			return rational;
		}

		public static Rational operator/ (Rational a, Rational b)
		{
			if(b.numerator == 0)
			{
				throw new DivideByZeroException();
			}

			Rational rational = new Rational(a.numerator * b.denumerator, a.denumerator * b.numerator);
			rational.Transform();
			return rational;
		}

		public static implicit operator Rational(int number) => new Rational(number, 1);

		public static implicit operator float(Rational rational) => rational.numerator / rational.denumerator;

		public static implicit operator double(Rational rational) => rational.numerator / rational.denumerator;

		public static implicit operator decimal(Rational rational) => rational.numerator / rational.denumerator;

		public static explicit operator int(Rational rational) => rational.numerator % rational.denumerator;

		public Rational Reciprocal()
		{
			return new Rational(this.denumerator, this.numerator);
		}

		public override string ToString()
		{
			return $"{this.numerator} / {this.denumerator}";
		}

		public override bool Equals(object obj)
		{
			return this.CompareTo(obj) == 0;
		}

		public int CompareTo(object obj)
		{
			return this.CompareTo((Rational)obj);
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
		
		public void Transform()
		{
			int a = this.numerator;
			int b = this.denumerator;

			while(b != 0)
			{
				int old = b;
				b = a % b;
				a = old;
			}

			this.numerator /= a;
			this.denumerator /= a;
		}
	}
}
