using System;

namespace PriorityQueue
{
	class Element<T>
	{
		private T value;
		private int priority;

		public T Value { get => this.value; set => this.value = value; }

		public int Priority { get => this.priority; set => this.priority = value; }

		public Element(T value, int priority)
		{
			this.value = value;
			this.priority = priority;
		}

		public override string ToString()
		{
			return $"{this.value} - {this.priority}";
		}
	}
}
