# Sideways Swim

Welcome to Sideways Swim, a game where you have to navigate the treachorous seabed and collect coins on your journey!

[Unity Play Link](https://play.unity.com/en/games/cb35fb94-a996-4f19-a8ed-63045090e3f7/sideways-swim)

Instructions:
- To play, simply click on the above link and start a new game.
- Controls:<br>
   To move up, press <kbd>Up</kbd> or <kbd>W</kbd> key<br>
   To move down, press <kbd>Down</kbd> or <kbd>S</kbd> key<br>
- Your fish will move right automatically. Avoid puffers and pick up coins to earn a higher score!<br>
- Enter the bubble portal at the end to win!<br>
- Beware the sand bed or swimming too close to the surface, these could spell doom for your little fish!<br>

## Base Game

**Completion**: All required elements have been added.<br>
**Known Bugs**: None<br>
**Limitations**: Theoretically you could miss the portal at the end, so a back barrier has been added to kill the game if that occurs. A better implementaton would include a final "line" after which players win automatically, without need for a target (and without the possibility of missing). That being said, the final target is a nice challenge.<br>
**Deviations**: This game does not include platforms to land upon — unless you count the bottom sand, which kills the player. However, I made sure to implement the same type of complex interactions and collisions (e.g. Coins + obstacles with colliders).<br>

**Key Features**:
- Obstacles (puffer fish) that need to be avoided! (+ barriers to avoid going off-screen)<br>
Implemented collision detection in the fish swim script to check what the fish was colliding with. If it collided with a barrier or an obstacle (check uses Layers), the fish would explode using a bubble particle system. Additionally, the camera stops and a restart button shows. For efficiency, a puffer fish prefab was created with appropriate colliders for all obstacles.<br>
- Coins that should be picked up!<br>
As part of the above collision detection, I created a layer for coins, so that if the fish collided with a coin and not an obstacle, it would be detected. If this occurs, I increment the score counter and the dynamic UI shows it in the top left corner. Additionally, the coin disappears when collected. Again, this was implemented using a prefab with collider and "Is Trigger" checked.<br>
- Stable camera<br>
Instead of following the fish and giving the user motion sickness from all the jumping, I implemented a steady target for the cinemachine to follow that matches the fish speed. This way, the fish remains in frame, and the frame remains in a stable, horizontal line. When obstacle collisions occur or the game ends, the camera stops moving. I implemented this using a public boolean within the camera script.<br>

## Future Improvements

- Platforms
  Some kind of platform for the player to land on would add an interesting component to the game
- Moving obstacles
  Currently, the puffer fish remain stable. Adding some movement would make the game more challenging in future levels
- Boosts, score multipliers, and other special powerups
  Adding dynamic powerups to change up the playing experience and make scores move faster could add a fun element to the game. One implementation of this could be that picking up some food or a bubble means that all coins are multiplied for the next 10 seconds. Dynamic UI could add a timer beneath the score counter to show when this powerup is depleted.
- Dynamic difficulty
  Increasing the speed in future levels is definitely needed. However, increasing the speed within the same level could add another challenge to the gameplay. It could also mean that new powerups — like time-slowers — could be introduced.
- Different backgrounds/assets
  Playing in a different area of the sea or having to avoid different obstacles could be super fun. Additionally, zooming out and making a larger playing space could also make the game more difficult + novel.

Ultimately, I think there are tons of ways to improve this game for the future. To begin, a few more levels with some of the above could turn a basic game into an incredible adventure!


## Reflection

**Challenges**: I originally was really challenged by what I was going to build the game around. I knew I wanted to continue the fish theme, but I didn't have a lot of ideas that matched the project description. Another challenge, once I had the idea, was ensuring it was actually fulfilling the intent of the assignment. I think by adding the fall/jump mechanism, I was able to do that. When it comes to Unity, I had lots of challenges regarding layers and interactions. For a while I didn't realize that items had to be on the same Z-layer to collide — I thought it was just a visual thing. I also had issues with building and publishing the project. I don't know what I was doing wrong, but it was removing my assets when I built the project.<br> 

**Learning Outcomes**: I learned quite a lot about how to put different components together. Last project was very linear (tutorial --> execution), while this one had a lot more room for creativity. Because of that, I learned how to combine the things we've learned into an original game that contains complex features, no tutorial needed. I'm sure I did a few things inneficiently, but the process of building and iterating was certainly worth it.<br>

**For next time**: If I were to do this project again, I think I'd spend more time planning the initial idea on paper before building. This time I kind of hopped right in, which was both good and bad. While I didn't have time to overthink, I also made it more challenging on myself towards the end, since the ultimate project was imperfect and required improvements to match the assignment criteria. Ultimately, I think more foresight + planning could make the whole process easier.


