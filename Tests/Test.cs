using NUnit.Framework;
using System;
using ParkingGarage;

namespace Tests
{
	[TestFixture ()]
	public class Test
	{
        string[] testCommands = new string[] {"create_parking_lot 2","park car1 white","park car2 black","park car3 blue","leave 1","leave 2","status"};
		string[] expectedResults = new string[] { "Created a parking lot with 2 slots", "Allocated slot number: 1", "Allocated slot number: 2", "Sorry, parking lot is full", "Slot number 1 is free ", "Slot number 2 is free ", "Slot No.\tRegistration No.\tColour \n" };



		[Test ()]
		public void InputProcessingTestCases ()
		{
			for (int i = 0; i < testCommands.Length;++i)
            {
                string output = InputProcessor.ValidateAndProcessInput(testCommands[i]);
                Console.WriteLine(output);
                Assert.AreEqual(output, expectedResults[i]);
            }
        }

		
	}
}

