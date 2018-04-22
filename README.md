# Project 1 - Simplexity 

## Members

* Francisco Freixo - a21701661
* Nuno Carriço - a21701393

## Who did what?

**Francisco Freixo:**
* Fluxogram, UML Diagram and *README*
* Organization of classes 
* Color and Shape enums
* Initial version of the class Pieces
* Class Board
* Coordinates constructor
* Visualization 
* Method that asks for user shape 
* Initial version of game loop
* Piece counter (Cubes and Cilinders)
* Check for full Column 
* Improve Visualization
* Comments to Shape, Color, Piece and Player classes

**Nuno Carriço:**
* Fluxogram, UML Diagram and *README*
* Change Variables to Properties on classes Coordinates and Piece
* Method GetPiece
* Class Player
* Method that asks for column
* Method SetPiece
* Tie verification
* Method GetShape and GetColor
* Win verification
* Class Game - game loop
* Comments to Program, Coordinates, Board, Game, Renderer and WinChecker classes

## Our solution

### Fluxogram

![Simplexity_Fluxogram_-_Page_1__1_](https://gitlab.com/NunoCarrico98/Project1_Simplexity/uploads/283c999fc0fa3a6c791675c933122de5/Simplexity_Fluxogram_-_Page_1__1_.png)

**Picture 1** - Our Fluxogram represents the flow of the program, in this case, the Game Loop.

### UML Diagram

![UML](https://gitlab.com/NunoCarrico98/Project1_Simplexity/uploads/369eb0b6742e245c3478b903b34a2e19/UML.png)

**Picture 2** - Our UML Diagram shows the structure of our program as well as the relationships between our classes. 

### Data structures

For our board we used an array of pieces. These Pieces are represented by a enumertaion containing five different variants.
|Piece|
|-|
|None|
|RedCube|
|RedCilinder|
|WhiteCube|
|WhiteCilinder|

### Algorithms

 Our game starts by entering the `GameLoop()` method. This contains all the methods necessary for our game to work (by accesing other classes by instances). As such, the `GameLoop()` method continues until a draw or win is verified by the `WinChecker` Class. 
 
The `GameLoop()` starts by asking for the first player (white) to choose a column and a shape. Then, our program checks the column that the player chose for a space. To verify if our column is full, our program use just an `int` variable that goes through the column, always up. If it ends up being outside the board it means the column is full and new column will be asked.

Here is some pseudocode to better understand the column verification:

```c#
    int checkColumn;
    while(there is a piece on wanted position)
        checkColumn--;
        if ( checkColun < 0)
            player.ReaskColumn();
            checkColumn = 6;
```

After the `piece` is on the `board`, the win verification starts. First, we check if there victory by `shape` and then by `color`. 
Our algortihm starts by creating an array of 4 directions and `foreach` direction in that array a counter starts. After, it makes sure to also check the opposite direction to the current verification direction. It sends that direction through a new variable and starts the verification in the `position` of the last piece put on the `board`. It goes through 4 `pieces` for each `direction` and if a equal `piece` is found, it adds to the counter. As such, if the counter is equal or bigger than 4, a win is set and it returns `true` to the `Check()` method, that sends the winner to `RenderResults()`. And the game ends.

Here is some pseudocode to better understand the win verification:
```c#
Creation an array of 4 directions (North, Northeast, East and Southeast)
foreach(direction in array)
    Start counter of matching shape or color at 1;
    Cycle for() to make we also check opposite direction;
        for(check distance = 1 to 5; ++)
            COORDS verify = lastPiecePos + direction * check distance;
            Create coordinates to hold verification coords each cycle;
            Make sure coords are on the board;
            if(shape/color on board == wanted shape/color )
                Increment counter of matching shape or color;
            else break from cycle;
            if(counter of matching shape or color > 4)
                return true;
return false;
```

However, if the verification does not find any 4 pieces in a row, the `GameLoop()` continues and the second player (red) plays. The same cycle repeats: ask for input (Column and `Shape`), check if column is full, `SetPiece()`, Win Verification.

This continues until all players have no more `pieces` - which ends the game in a draw - or a win condition is detected.

## Conclusions

1. Better understanding of Classes;
2. Development of object-oriented programming;
3. Understanding on how to create a new class;
4. Improvement on the use of Microsoft Visual Studio Community;

## References ##

#### Other Colaborators
> **Rui Martins, Diogo Martins, Diogo Maia**
Our group and this one, started working together in the beggining on the logic and organization of our classes and program. However, we ended up splitting into our own ideas and we believe we finished with quite different approaches to this project.
