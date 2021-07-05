using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PriorityQueue
{
	class PriorityQueue<T> : IEnumerable<Element<T>>
	{
		private List<Element<T>> queue = new List<Element<T>>();

		public void AddElement(Element<T> element)
		{
			int i = 0;
			i = queue.IndexOf(queue.Find(x => x.Priority < element.Priority));
			if(i == -1)
			{
				queue.Add(element);
			}
			else
			{
				queue.Insert(i, element);
			}
		}

		public string Peek()
		{
			return queue[0].ToString();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable)queue).GetEnumerator();
		}

		public IEnumerator<Element<T>> GetEnumerator()
		{
			return ((IEnumerable<Element<T>>)queue).GetEnumerator();
		}
	}
}
