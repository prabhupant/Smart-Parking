# Smart-Parking

An ASP.NET web-app to automate the transactions in a parking system.

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

### Clone the repository

First, get a local copy of the project on your machine.

```
$ git clone https://github.com/prabhupant/Smart-Parking.git
```

### Prerequisites 

1. .NET Framework
2. Visual Studio 2017
3. Entity Framework
4. Bootstrap (version 3.0.0 or higher)

### Prerequisites 

Change the connection string in ```ParkingManagementSystemController.cs``` located inside ```ParkingSpotForm(userInfo, int)``` function

```
string connectionStringADO = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Final Projects\\ParkingManagementSystem\\ParkingManagementSystem\\App_Data\\DatabasePMS.mdf\";Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework";
```

Modify the address ```"C:\\Final Projects\\ParkingManagementSystem\\ParkingManagementSystem\\App_Data\\DatabasePMS.mdf\"``` according to your local repository.

## Contributing

Feel free to pull and push code. Open to pull requests :)

## Acknowledgments

I blame all of you. Writing this code has been an exercise in sustained suffering. The casual reader may, perhaps, exempt herself from excessive guilt, but for those of you who have played the larger role in prolonging my agonies with your encouragement and support, well…you know who you are, and you owe me.
