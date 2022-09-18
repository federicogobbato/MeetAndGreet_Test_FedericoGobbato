# MeetAndGreet_Test_FedericoGobbato
 
I created few tests on top of the "2D Platformer Microgame" template provided by Unity. 
The Unity version used is 2021.3.8
Under "Assets\Tests" you can find 2 folders that contain all the test scripts.

Running the test runner in EditMode a test checks the distance between the tokens. 
Running the test runner in PlayMode the tests check:
- the health of the player when the game start
- the health of the player when hit by an enemy
- when the player jump, if collect any token

All the tests can be run outside Unity using a batch file called "RunTests.bat".
Running the batch file, the test logs will be saved on a xml file.
