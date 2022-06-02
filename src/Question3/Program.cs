using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question3
{
	class Program
	{
		class Points
		{
			public double X { get; set; }
			public double Y { get; set; }
			public double Z { get; set; }

			public Points(double x, double y, double z) {
				X = x;
				Y = y;
        Z = z;
			}

			public Points PointDiff(Points other) {
				return new Points(Math.Abs(X - other.X), Math.Abs(Y - other.Y), Math.Abs(Z - other.Z));
			}
		}

		static void Main(string[] args)
		{
			var startPosition = new Points(30, 50, 90);
			var targetPosition = new Points(4000000, 400000000, 9);

			var perSecondMovement = 20;

			// 25 minutes of total movement
			var totalMovement = perSecondMovement * 60 * 25;

			var pointDifference = startPosition.PointDiff(targetPosition);

			// 100%
			var totalDistance = pointDifference.X + pointDifference.Y + pointDifference.Z;

			var percentageX = 100 / totalDistance * pointDifference.X;
			var percentageY = 100 / totalDistance * pointDifference.Y;
			var percentageZ = 100 / totalDistance * pointDifference.Z;

			Console.WriteLine("percentageX = " + percentageX);
			Console.WriteLine("percentageY = " + percentageY);
			Console.WriteLine("percentageZ = " + percentageZ);
			Console.WriteLine("");

			var moveXBy = totalMovement * (percentageX / 100);
			var moveYBy = totalMovement * (percentageY / 100);
			var moveZBy = totalMovement * (percentageZ / 100);

			Console.WriteLine("Total movement: " + (moveXBy + moveYBy + moveZBy));
			Console.WriteLine("x:{0:0.00} y:{1:0.00} z:{2:0.00}", startPosition.X + moveXBy, startPosition.Y + moveYBy, startPosition.Z + (moveZBy * -1));
			


			
			Console.WriteLine(totalMovement);

			Console.ReadKey();

		}
	}
}
