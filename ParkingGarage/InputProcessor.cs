using System;

namespace ParkingGarage
{
	public class InputProcessor
	{
		public InputProcessor ()
		{
		}

		enum InputTypes
		{
			create_parking_lot,
			park,
			leave,
			status,
			registration_numbers_for_cars_with_colour,
			slot_numbers_for_cars_with_colour,
			slot_number_for_registration_number,
			exit_app
		}

        public static string ValidateAndProcessInput(string command)
        {
            string result = "";
			bool validInput = InputProcessor.ValidateInput(command);

			if (validInput)
			{
				result = InputProcessor.ProcessInput(command);
			}
			else
			{
                if (!ParkingGarage.parking.isInitialized())
				{
					result = "Create parking before trying this command";
				}
			}

            return result;
        }

		public static bool ValidateInput(string input)
		{
			if (string.IsNullOrEmpty (input)) 
			{
				return false ;
			}

			string[] inputsArray;
			inputsArray = input.Split (null);

			if (string.IsNullOrEmpty (inputsArray [0])) 
			{
				return false;
			}

			InputTypes commandType;
			if (!Enum.TryParse (inputsArray [0], out commandType)) 
			{
				return false;
			}


			if (commandType != InputTypes.create_parking_lot && !ParkingGarage.parking.isInitialized()) 
			{
				return false;
			}

			switch (commandType) {
				case InputTypes.create_parking_lot:
					if (inputsArray.Length == 2) {
						int value; 
						if (int.TryParse (inputsArray [1], out value)) {
							return true;
						}
					}
					break;
				case InputTypes.park:
					if (inputsArray.Length == 3) {
						return true;
					}
					break;
				case InputTypes.leave:
					if (inputsArray.Length == 2) {
						int inp;
						if (int.TryParse (inputsArray [1], out inp)) {
							if (!(inp > ParkingGarage.parking.GetMaxParkingSize () || inp < 1)) {
								return true;
							}
						}
					}
					break;
				case InputTypes.status:
						return true;
				case InputTypes.registration_numbers_for_cars_with_colour:
					if (inputsArray.Length == 2) {
						return true;
					}
					break;
				case InputTypes.slot_numbers_for_cars_with_colour:
					if (inputsArray.Length == 2) {
						return true;
					}
					break;
				case InputTypes.slot_number_for_registration_number:
					if (inputsArray.Length == 2) {
						return true;
					}
					break;
				case InputTypes.exit_app:
					return true;
				default :
					return false;

			}

			return false;
		}

		public static string ProcessInput(string input)
		{
			string[] inputsArray;
			inputsArray = input.Split (null);

			string output = "";
			InputTypes commandType;
			if (!Enum.TryParse(inputsArray[0], out commandType))
			{
				return "Invalid command entered!";
			}
			switch (commandType) 
			{
			case InputTypes.create_parking_lot:
				if (inputsArray.Length > 1) {
					int count;
					if(Int32.TryParse(inputsArray [1],out count))
					{
						output = ParkingGarage.parking.CreateParkingGarage (count);
					}
				} else {
					Console.WriteLine ("Insufficient input!");
				}
					break;
				case InputTypes.park:
					output = ParkingGarage.parking.AddCarToParking (inputsArray [1],inputsArray[2]);
					break;
			    case InputTypes.leave:
				int counter;
				if(Int32.TryParse(inputsArray [1],out counter))
				{
					output = ParkingGarage.parking.RemoveCarFromParking (counter);
				}
					break;
				case InputTypes.registration_numbers_for_cars_with_colour:
					output = ParkingGarage.parking.GetRegNumberOfCarsWithColor (inputsArray [1]);
					break;
				case InputTypes.status:
					output = ParkingGarage.parking.GetParkingStatus ();
					break;
				case InputTypes.slot_numbers_for_cars_with_colour:
					output = ParkingGarage.parking.slotNosOfCarsWithColor (inputsArray [1]);
					break;
				case InputTypes.slot_number_for_registration_number:
					output = ParkingGarage.parking.slotNoBasedOnRegistrationNo (inputsArray [1]);
					break;
				
			    case InputTypes.exit_app:
					output = ParkingGarage.parking.ExitApp ();
					break;
				default:
					output = "Invalid command entered!";
					break;
			}

			return output;
		}
	}
}

