using System;

namespace ParkingGarage
{
	public class Car
	{
		public Car ()
		{
		}

		public Car (string regNumber , string color)
		{
			registrationNumber = regNumber;
			colour = color;
		}

		private string registrationNumber ;
		private string colour;


		public string GetRegistrationNumber()
		{
			return registrationNumber;
		}

		public string GetColour()
		{
			return colour;
		}

	}
}

