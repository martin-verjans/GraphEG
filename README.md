# GraphEG
The GraphEG software implements a graph-based representation of Escape Games. It is a companion artifact for the paper "Formalizing Escape Game Mechanics: A Graph-Theoretical Framework for Modeling and Analyzing Puzzle-Based Environments"

## Installation
To run the application, you first have to install :
- Visual Studio (developped using version 2022)
- [GraphViz](https://graphviz.org/download/#windows)
- Git

Once the installation is done, just compile the code and GraphEG will launch.

## Usage
There are 2 main interfaces, the Designer and the Game itself.

### The Designer
The Designer lets you create a blueprint for an escape game, you can save this blueprint as a .sg file or load a .sg file and continue editing a blue print. (.sg holds for Static Graph format)

### The Game
A game is encoded as a Git folder, where each move corresponds to a commit (managed internally by the software). To start a new game, you must first select an empty or create a new folder, then select a .sg file which will be considered to be the game's blueprint. Once this is done, you need to create players and (if applicable) attribute some skills to them.
When the game starts, you can see a list of possible actions for each player. Select an action and execute it, the bottom text box will display the result of the action and the graph will automatically update accordingly.

## Next development steps
This application is merely a Proof of Concept for our Escape Game mechanics formalization and will probably evolve in the future. Here are some of the planned upgrades :
- Save and load graph in .dot file format. While saving is easy, we didn't find anything yet to load directly from a .dot file (using QuikGraph & GraphViz). For now it is restricted to native C# Binary serialization.
- The Git folder for the game will allow in the future to go back in time and select a different action to perform in a given retrieved game state. That way it will be possible to execute all possible actions and automate solving the game.
- Add description and stories to the game (for now only vertices and edges), so that the game's narrative can be displayed or automatically read.
