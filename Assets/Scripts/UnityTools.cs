using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = System.Random;

public static class UnityTools
{ 
	/// <summary>
	/// A class that will return one of the given items with a specified possibility.
	/// </summary>
	public class RandomOfType<T>
	{
		private List<Tuple<double, T>> _items = new List<Tuple<double, T>>();
		private Random _random = new Random();

		/// <summary>
		/// All items possibilities sum.
		/// </summary>
		private double _totalPossibility = 0;

		/// <summary>
		/// Adds a new item to return.
		/// </summary>
		public void Add(double possibility, T item)
		{
			_items.Add(new Tuple<double, T>(possibility, item));
			_totalPossibility += possibility;
		}

		/// <summary>
		/// Returns a random item from the list with the specified relative possibility.
		/// </summary>
		public T NextItem()
		{
			var rand = _random.NextDouble() * _totalPossibility;
			double value = 0;
			foreach (var item in _items)
			{
				value += item.Item1;
				if (rand <= value)
					return item.Item2;
			}
			return _items.Last().Item2; // Should never happen
		}
	}
}


