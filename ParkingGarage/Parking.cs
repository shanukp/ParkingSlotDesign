using System;
using System.Collections;
using System.Collections.Generic;

namespace ParkingGarage
{
	public class Parking
	{
		SortedList<int,Car> parkingGarageData = new SortedList<int,Car>();
		bool initialized = false;
		private SortedList<int,Object> vacantSlots;
		private ArrayList regNumbers;

		int maxAvailableParkingSlots;

		bool closeApp = false;

		public Parking ()
		{
			
		}

		public bool shouldExitApp()
		{
			return closeApp;
		}

		public string ExitApp()
		{
			closeApp = true;
            return "Exiting..";
		}

		public int GetMaxParkingSize()
		{
			return maxAvailableParkingSlots;
		}

		public string CreateParkingGarage(int parkingSlotsCount)
		{
			if (parkingSlotsCount > 0) 
			{
				vacantSlots = new SortedList<int,Object> ();
				for (int i = 1; i <= parkingSlotsCount; ++i) 
				{
					vacantSlots.Add (i,null);
				}
				regNumbers = new ArrayList ();

				initialized = true;
				maxAvailableParkingSlots = parkingSlotsCount;
				return "Created a parking lot with " + maxAvailableParkingSlots + " slots";

			} else 
			{
				return  "Enter a positive number greater than zero for number of parking slots!";
			}
		}

		public bool isInitialized()
		{
			return initialized;
		}


		public string GetParkingStatus() {
			
			string output = "Slot No.	Registration No.	Colour \n";

			foreach (int key in parkingGarageData.Keys)
			{
				Car car = parkingGarageData[key];
				output += key + "       " + car.GetRegistrationNumber () + "         " + car.GetColour ();
			}

            return output;
		}

		public string AddCarToParking(string registrationNumber , string color)
		{
			if (parkingGarageData.Count == maxAvailableParkingSlots) 
			{
				return "Sorry, parking lot is full";	

			} else 
			{
				int firstAvailableSlot = GetFirstAvailableSlot ();
				Car car = new Car (registrationNumber, color);
				parkingGarageData.Add (firstAvailableSlot, car);

				vacantSlots.Remove (firstAvailableSlot);
				regNumbers.Add(registrationNumber);

				return "Allocated slot number: " + firstAvailableSlot;
			}
		}

		public string RemoveCarFromParking(int parkingSlotId)
		{
			if (parkingGarageData.ContainsKey (parkingSlotId)) {
				regNumbers.Remove (parkingGarageData [parkingSlotId]);
				parkingGarageData.Remove (parkingSlotId);
				vacantSlots.Add (parkingSlotId,null);
				return "Slot number " + parkingSlotId + " is free ";

			} else 
			{
				if (parkingSlotId > maxAvailableParkingSlots) {
					return " Invalid Input ! ";
				} else {
					return "Slot number " + parkingSlotId + " is already free ";
				}
			}
		}

		public int GetFirstAvailableSlot()
		{
			return vacantSlots.Keys [0];
		}

		public string GetRegNumberOfCarsWithColor(String color) {

			string details = "";
			foreach (int key in parkingGarageData.Keys)
			{
				Car car = parkingGarageData[key];
				if(car.GetColour() == color)
				{
					if(details != "")
					{
						details += " ," + car.GetRegistrationNumber ();
					}else
					{
						details = car.GetRegistrationNumber ();
					}
				}
			}

			return details;

		}

		public string slotNosOfCarsWithColor(String color) 
		{
			string details = "";
			foreach (int key in parkingGarageData.Keys)
			{
				Car car = parkingGarageData[key];
				if(car.GetColour() == color)
				{
					if(details != "")
					{
						details += " ," + key;
					}else
					{
						details = key.ToString();
					}
				}
			}

			return details;

		}

		public string slotNoBasedOnRegistrationNo(String registrationNumber) {
			string details = "";
			foreach (int key in parkingGarageData.Keys)
			{
				Car car = parkingGarageData[key];
				if(car.GetRegistrationNumber() == registrationNumber)
				{
					details = key.ToString();
				}
			}
			if (details == "") 
			{
				return "Not found";
			} else 
			{
				return details;
			}
		}
	}
}

