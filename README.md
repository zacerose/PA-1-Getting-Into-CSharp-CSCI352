# PA-1-Getting-Into-CSharp-CSCI352
Name: Zachary Rose  
Date: 1/24/2023  

Abstract animal class in C#, demonstrates inheritence and function overriding

## Required Files
* PA-1-Abstract-Animal --> directory containing the C# project
* PA-1-Abstract-Animal.sln --> Visual Studio solution file

## Program usage

To launch the program, clone the repository in Visual Studio and compile/run by pressing "Start".
Follow the instructions that pop up in the console and enter 'q' when done.

## Design Decisions

* I placed every class in one file since they were all relatively short, and they were very similar to each other. 
* I created the print instructions helper function to make reprinting during usage easier. The console will inevitably flush them off the screen, so it's
vital to be able to easily reprint them.
* I created the get animal index helper function because I knew several menu options could make good use out of it, so it saved room in the switch statement.
* In order to keep every data member private in the abstract Animal class, I had to make accessors for name and age in order to retrieve them from inside the subclasses.  
* I made a somewhat arbitrary addition to the printInfo and ageUp functions to meet with the requirement to override them, but I left makeNoise alone to show an abstract
class's capability of fully defining a function for use in subclasses.
* I didn't add parse protection when requesting animal information from the user because it seemed outside the scope of this project, so it will indeed crash if a string
is inputted where a number is required. 
