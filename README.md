# Garage Management Application

## Overview
The Garage Management Application is a C# project designed to manage various types of vehicles in a garage. It utilizes advanced object-oriented programming concepts, including inheritance, interfaces, and exception handling. The application provides a user-friendly menu for interaction and employs JSON serialization for data persistence.

## Features
- **Vehicle Management**: Add, display, and manage different types of vehicles (Cars, Motorcycles, Trucks).
- **User Interaction**: A menu-driven interface for easy navigation and operations.
- **Data Persistence**: Save and load garage data using JSON serialization.
- **Exception Handling**: Custom exceptions for managing specific error scenarios (e.g., garage full, vehicle not found).

## Project Structure
```
GarageManagementApp
├── src
│   ├── Program.cs
│   ├── Models
│   │   ├── Vehicle.cs
│   │   ├── Car.cs
│   │   ├── Motorcycle.cs
│   │   ├── Truck.cs
│   │   └── IVehicle.cs
│   ├── Services
│   │   ├── GarageService.cs
│   │   ├── IStorageService.cs
│   │   └── JsonStorageService.cs
│   ├── Core
│   │   ├── Garage.cs
│   │   └── Menu.cs
│   ├── Exceptions
│   │   ├── GarageFullException.cs
│   │   └── VehicleNotFoundException.cs
│   └── Utils
│       └── InputValidator.cs
├── data
│   └── .gitkeep
├── GarageManagementApp.csproj
└── README.md
```

## Setup Instructions
1. Clone the repository to your local machine.
2. Open the project in your preferred C# development environment.
3. Restore the project dependencies.
4. Run the application using the command line or your IDE.

## Usage
- Launch the application to access the main menu.
- Follow the prompts to add vehicles, view the garage inventory, and perform other operations.
- Data will be saved automatically in JSON format, allowing for persistent storage across sessions.

## Contributing
Contributions are welcome! Please feel free to submit a pull request or open an issue for any enhancements or bug fixes.

## License
This project is licensed under the MIT License. See the LICENSE file for more details.