using System;
using System.IO;

namespace ParkingGarage
{
	class ParkingGarage
	{
		public static Parking parking = new Parking ();

		public static void Main (string[] args)
		{
			
			StreamReader reader = null;
			string command;

			if (args.Length > 0) 
			{
				 reader = new System.IO.StreamReader(args[0]); 

			} 

			while (parking.shouldExitApp() == false) 
			{
				if (args.Length == 0) 
				{
					Console.WriteLine ("Please enter a command ...");
					command = Console.ReadLine ().Trim (); 
				} 
				else 
				{	
					command = reader.ReadLine ();
					if (!string.IsNullOrEmpty (command)) {
						command = command.Trim ();	
					} else 
					{
						command = "exit_app";
					}
				}
                
               string output =  InputProcessor.ValidateAndProcessInput(command);
               Console.WriteLine(output);
			}
		}
	}
}
