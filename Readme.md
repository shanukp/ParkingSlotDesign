#ReadMe
#Problem is solved in c#

XBUILD command line tools are used to build the project.
Test cases are written using NUnit framework.
BuildScript.proj in ParkingGarage/ takes care of pipelining the build in to three phases.
  #clean
  #Build
  #Test


Running the Project
1)Make sure mono is installed and necessary file permissions are given.
2) ./parking_lot will trigger the input driven format
3) ./parking_lot file_inputs.txt will read from the file and do necessary processing.
