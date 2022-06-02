using System;
using System.Linq;
using System.Threading.Tasks;

namespace Question1
{
	class Program
	{
		static void Main(string[] args)
		{
			var maxNumber = (int)Math.Pow(10, 8);
			var degreeOfParallelism = Environment.ProcessorCount;
			Console.WriteLine("ProcessorCount: " + degreeOfParallelism);

			var tasks = new Task<int>[degreeOfParallelism];

			for (int taskNumber = 0; taskNumber < degreeOfParallelism; taskNumber++)
			{
				int taskNumberCopy = taskNumber;

				tasks[taskNumber] = Task<int>.Factory.StartNew(
						() =>
						{
							var reversibleNumberCount = 0;

							var min = maxNumber * taskNumberCopy / degreeOfParallelism;
							var max = maxNumber * (taskNumberCopy + 1) / degreeOfParallelism;

							Console.WriteLine("[Task {0}] - Min: {1}", taskNumberCopy, min);
							Console.WriteLine("[Task {0}] - Max: {1}", taskNumberCopy, max);

							for (int i = min; i < max; i++)
							{
								if (i % 10 == 0)
								{
									continue;
								}

								var reversed = Reverse(i);
								var result = i + reversed;
								
								if (IsCompletelyOdd(result))
								{
									reversibleNumberCount++;
									//Console.WriteLine("{0,3} + {1,3} = {2,3}", i, reversed, result);
								}
							}

							return reversibleNumberCount;
						});
			}
			Task.WaitAll(tasks);
			Console.WriteLine(tasks.Sum(x => x.Result));
			Console.ReadKey();
		}

		/// <summary>
		/// Determine if the provided value is an even number
		/// </summary>
		/// <param name="value"></param>
		/// <returns>True, if the value is even</returns>
		private static bool IsEven(double value)
		{
			return value % 2 == 0;
		}
	
		/// <summary>
		/// Determine if every single number in the provided value is odd
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		private static bool IsCompletelyOdd(int value)
		{
			while (value > 0)
			{
				if (IsEven(value % 10))
				{
					return false;
				}
				value /= 10;
			}
			return true;
		}
		
		/// <summary>
		/// Reverse the numbers in the provided value
		/// </summary>
		/// <param name="value">Value to reverse</param>
		/// <returns>Reversed value</returns>
		private static int Reverse(int value)
		{
			int result = 0;
			while (value > 0)
			{
				result = result * 10 + value % 10;
				value /= 10;
			}
			return result;
		}
	}
}