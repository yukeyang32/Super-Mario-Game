Controls: Press w/up key to set Mario to idle state if he was in a crouching state and a jumping state if he was not
Press s/down key to set Mario to idle state if he was jumping state and a crouching state if he was not. Additionally, set small left or right walking Mario to an idle state since small Mario doesn't have crouching state.
Press left/a and right/d keys should change mario between left running, left idle, right idle, and right running.
Press y key to change mario to a small state.
Press u key to change mario to a big state.
Press i key to change mario to a fire state.
Press o key to change mario to a dead state.
(Default states for small, big and fire Marios are left facing idle state.)
Press z key to trun Question block into used block
Press x key to make Brick block disappears
Press c key to turn Hidden block into used block

On level 2 (the hard level):
Some jumps may seem impossible. Make sure to check for hidden blocks that you can activate/jump onto.
If you can't find the hidden blocks the easiest way to find them is to copy the csv to your computer and open the file in excel to see the format.

On code analysis warnings:
A lot of the code analysis warnings are about class members that do not get used. Many of these are because the classes are not fully implemented for all functionality, and we figured that those members may be used later in the project. This is why some of them may appear to be unused but we may use them to change features of the game in the future.
For example while the 'Goomba' in IdleGoombaState.cs is not used, it will be used later when changing states for the Goomba itself (stomped, direction change, etc)