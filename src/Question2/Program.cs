using System;
using System.Linq;

namespace Question2
{
	class Program
	{
		public class Numbers
		{
			public decimal A { get; private set; }
			public decimal B { get; private set; }

			public Numbers()
			{
				A = 0;
				B = 1;
			}

			public void SetNumber(decimal value)
			{
				A = B;
				B = value;
			}
		}

		static void Main(string[] args)
		{
			// Get all the Fibonacci numbers
			Console.WriteLine(Fibonacci(new Numbers(), (decimal)Math.Pow(10, 18) + 1));
			Console.ReadKey();
		}

		private static bool IsNatural(decimal value)
		{
			return Math.Abs(value - (int)value) == 0;
		}

		private static int CountTogether(decimal number) {
			return number.ToString().Select(x => int.Parse(x.ToString())).Sum();
		}

		private static decimal Fibonacci(Numbers numbers, decimal maxValue)
		{
			var counter = 0m;

			var result = numbers.A + numbers.B;
			Console.WriteLine("Fibonacci = {0} + {1} = {2}", numbers.A, numbers.B, result);

			var together = CountTogether(result);
			Console.Write("Together = " + together);

			var sqrt = (decimal)Math.Sqrt(together);
			Console.Write(" | Sqrt = " + sqrt);

			if (IsNatural(sqrt)) {
				Console.Write(" | Natural");
				counter++;
			}

			Console.WriteLine("");

			numbers.SetNumber(result);

			if (result < maxValue)
			{
				counter += Fibonacci(numbers, maxValue);
			}
			return counter;
		}
	}
}
