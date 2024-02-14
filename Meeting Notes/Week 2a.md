# 8th Feb 24 - Job Roles & Week 2 Tasks Delegation

Meeting Time:
Mon 11-12 &
Wed 5-6

### <b>What is everyone's job roles?</b>

Co-ordinator - Bruce <br>
Shaper - Lucas Hsing<br>
Implementer - Rodion, Bruce<br>
Team Worker - Sanyukta, Lucas <br>
Monitor - Lucas Hsing<br>
Finisher - Sanyukta<br>

| Functional Requirements                                                                                         | Non-functional Requirements                                                                                          |
| --------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------- |
| The game must recognise and accept the correct keyboard inputs to control the rocket.                           | The game must consider accessibility needs by using adjustable text sizes or high constrast text.                    |
| The game must award points for correct matches within the specified time given for that level.                  | The game should be well documented, to help a non-team member understand design and coding decisions.                |
| The user must be able to see scoreboard after each level.                                                       | The game must have undergone unit tests and acceptance testing to ensure all requirements are met.                   |
| The game must have local leaderboard of all scores shown in descending order.                                   | The game must support at least 4 languages.                                                                          |
| The game must track how long it takes for the student to complete each level or session.                        | The game must be created in Unity using C# script.                                                                   |
| The game must contain a local 2-player option, where user one uses (left,right) and 2nd player uses (keys A,D). | The game can utilise a database to obtain the word banks and provide options for user to select from during a level. |
| The game must contain menu's for options, quitting the game, accessing help, and adjusting the settings.        | The game should run smoothly on target hardware with no signifcant graphic issues.                                   |
| The game must contain and tutorial/practice level to understand the game machanics.                             | The codebase should have code following defined coding conventions                                                                                                                     |
| The game must have clear level progressions, with each new level having shorter time or more complex words.     |                                                                                                                      |

| Acceptance Criteria                                                                                           |
| ------------------------------------------------------------------------------------------------------------- |
| Given user completes game, when inputting username under 3 characters, then score is recorded on leaderboard. |
| Given on homepage, when pressing play button, then the game starts.                                           |
| Given user is on any scene(menu,playing game etc) , when pressing down arrow, then the tutorial pop-up shows.                     |
| Given user is playing the game, when pressing left or right, then the selection will move accordingly.        |
| Given user is playing the game, when they press the shoot button, then the spaceship should shoot             |
| Given user is playing the game, when they press button to go back to menu, the game stops                     |
| Given user is playing the game, when they are playing a level, then they should have point awarded for correct matches |
| Given user is playing the game, when they are playing a level, then there should be a timelimit before the level stops |
| Given user completes game, when they finish a level, then they should have the score appear on the screen     |
| Given user is in the menu, when they press the scoreboard button, then they should see a list of scores in descending order with corresponding user names |
| Given user is playing the game, when they are playing a level, then the system should track fast(2-3seconds) planet shootdowns for bonus points|
| Given there are 2 users, when they play a level, they take turns to shoot each planet and have individual scores |
| Given there are 2 users, when they play a level, they can control the spaceship using A,D and left,right arrow keys for left and right user |
| Given user is in the menu, when they press options, they are brought to options page where they can change some settings like music included or not|
| Given user is in the menu, when they press help button, they are brought to help page which details controls to play the game|
| Given user is in the menu, when they press button to quit game, the game quits |
| Given user is playing the game, when they choose different levels, then there is a level of progression e.g. time on harder level is shorter |
| Given user is in the options menu, when they change the font size, then the global font size for text should be changed |
| Given user is in the options menu, when they choose the high contrast text option, then the global text should correspondingly be high contrast |
| Given user is in the menu, when they choose their language of choice, the words in game should be from that language |
