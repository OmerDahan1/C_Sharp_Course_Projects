# C-Sharp-Course-Projects

Welcome to my C# course projects repository! This README file provides an overview of the five projects I completed as part of my university C# course. Each project showcases different aspects of C# programming, from basic syntax and console applications to more complex object-oriented programming and game development.

## Picture of the "Bulls & Cows" Game Created During the Course:

![Game](https://github.com/OmerDahan1/C_Sharp_Course_Projects/blob/main/Game%20Screenshots/Game.png)

## Table of Contents
  - [Project 1: Basic Programming](#project-1-basic-programming)
  - [Project 2: Bulls & Cows Console Game](#project-2-bulls--cows-console-game)
  - [Project 3: Garage Management System](#project-3-garage-management-system)
  - [Project 4: Interfaces, Delegations, Events, and Menus](#project-4-interfaces-delegations-events-and-menus)
  - [Project 5: Windows Application for "Bulls and Cows" Game](#project-5-windows-application-for-bulls-and-cows-game)

## Project 1: Basic Programming
### Goals
  - Develop .NET applications using Visual Studio
  - Practice writing programs in C# syntax
  - Work with I/O in the Console environment
  - Familiarize with classes like string, int, float, char, math, and StringBuilder
### Exercise
Create a new solution and add separate projects for each section:
  1. **Binary Series:** Convert binary numbers to decimal and provide statistics.
  2. **Hourglass for Beginners:** Print an hourglass pattern using recursion.
  3. **Hourglass for Advanced:** Extend the hourglass pattern to accept user input.
  4. **String Parsing:** Analyze strings for palindrome, number divisibility, and letter cases.
  5. **Statistics Tell:** Provide various statistics for a given 6-digit number.
     
## Project 2: Bulls & Cows Console Game
### Goals
  - Implement classes and object-oriented programming
  - Work with arrays and collection classes
  - Use an external DLL
### Exercise
Develop the classic "Bulls & Cows" game:

- The computer chooses a sequence of 4 unique letters (A-H).
- The player guesses the sequence, receiving feedback in terms of "Bulls" (correct position) and "Cows" (correct letter, wrong position).
- The game continues until the player guesses correctly or runs out of attempts.
### Features
- Validate user input
- Provide feedback and game state after each guess
- Allow the player to quit the game at any time by simply press the 'q' button.
  
## Project 3: Garage Management System
### Goals
- Implement classes, inheritance, and polymorphism
- Use collections and enums
- Develop and use external DLLs
- Work with multiple projects
- Handle exceptions
### Exercise
Develop a system to manage a garage with various types of vehicles:

- Regular Motorcycle: Octan98 fuel, 6.2L tank
- Electric Motorcycle: 2.4-hour battery
- Regular Car: Octan95 fuel, 44L tank
- Electric Car: 5.2-hour battery
- Truck: Soler fuel, 130L tank
### Features
- Add new vehicles to the garage
- Display vehicle information and status
- Update vehicle status
- Inflate tires, refuel, and charge batteries
### Solution Structure
- Ex03.GarageLogic: Contains the object model and logical layer.
- Ex03.ConsoleUI: Provides a console-based user interface.
  
## Project 4: Interfaces, Delegations, Events and Menus
### Goals
- Implement object-oriented programming and polymorphism
- Work with interfaces and delegates
- Manage hierarchical menus for Console applications
### Exercise
Develop a **MainMenu** class to create and manage hierarchical menus for console applications. Each menu can contain sub-menus, and selecting an item can either trigger an action or display another menu.
### Features
- Define menu items and sub-items
- Handle user input to navigate through menus
- Trigger actions based on menu selection
  
## Project 5: Windows Application for "Bulls and Cows" Game
### Description:
In this project, we have built an extension to Project 2, the "Bulls and Cows" game, by creating a Windows application version of the game. This project utilizes C# and Windows Forms to provide a graphical user interface for the "Bulls and Cows" game, enhancing the user experience with visual elements and interactive gameplay. Users can now choose from color buttons to make their guesses, adding a new dimension to the game.
### Goals
- Develop a complex but basic Windows application using C# and Windows Forms.
- Practice working with controls, events, and designing forms.
### Exercise
- Extend Project 2, the "Bulls and Cows" game, into a graphical Windows application.
- Implement interactive gameplay through color button selection for guessing.
### Features
- Graphical user interface (GUI) using Windows Forms.
- Interactive gameplay with color buttons for user input.
- Enhanced user experience with visual elements.
### Screenshots 
First, choose the number of guesses:

![Game](https://github.com/OmerDahan1/C_Sharp_Course_Projects/blob/main/Game%20Screenshots/Number%20Of%20Guesses%20Window.png)

Next, this window will open, allowing you to start guessing:

![Game](https://github.com/OmerDahan1/C_Sharp_Course_Projects/blob/main/Game%20Screenshots/Start%20Game%20Window.png)

At the end of the game, a window will appear, giving you the option to start a new game:

![Game](https://github.com/OmerDahan1/C_Sharp_Course_Projects/blob/main/Game%20Screenshots/End%20Game.png)

## How to Run the Projects:

**1. Open the Project in Visual Studio:**

- Launch Visual Studio.
- Open the solution file (.sln) for the project.
  
**2. Build the Solution:**
- Go to the Build menu and select Build Solution to compile the project.
  
**3. Run the Application:**
- For Console Applications:
  * Press F5 or click on the Start button in Visual Studio to run the application.
  * Follow the instructions in the console window to interact with the application.
    
- For the Windows Application (Project 5):
  * Press F5 or click on the Start button in Visual Studio to run the application.
  * The Windows Forms application will launch, and you can interact with the graphical user interface to play the game.
