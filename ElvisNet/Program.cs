using System;
using System.Collections.Generic;

namespace ElvisNet
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			var name = "powerumc";
			var value = Elvis.Value (() => name);

			Console.WriteLine (value);
		}
	}
}
