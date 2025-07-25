# GraphEG
This software implements a theory on graph representation of Escape Games.

## Installation
No installer is ready yet. To run the application, you have to install :
- Visual Studio (developped using version 2022)
- [GraphViz](https://graphviz.org/download/#windows)
- Git (if you don't know how to get git, what are you doing on github ?)

Once those are installed, compile the code and it can run.

## Usage
There are 2 main interfaces, the Designer and the Game itself.

### The Designer
The designer lets you create a blueprint for an escape game, you can save this blueprint as a .sg file or load a .sg file and continue editing a blue print.

### The Game
A game is a git folder where each move is a commit (managed by the game, you won't see it). To start a new game, you must first select an empty or create a new folder, then select a .sg file which will be the game blueprint. Once done, you need to create players and eventually attribute them some skills.
When the game starts, you can see a list of possible actions for each player. Select an action and execute it, the bottom text box will be the result of the action and the graph will update accordingly.

## Next steps
This application is merely a Proof of Concept for my Escape Game theory and will probably evolve in the future. Here are some of the planned upgrades :
- Save and load graph in .dot file format. While saving is easy, I didn't find anything yet to load from a .dot file (using QuikGraph & GraphViz). For now it is only native C# Binary serialization.
- The Git folder for the game will allow in the future to go back in time and select a different action. That way it would (theoretically) be possible to execute all possible actions and automate solving the game.
- Add description and stories to the game (for now it's only vertices and edges), so that the game could be "told" by the machine by reading the descriptions.
