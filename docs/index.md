# Project 3 Preserve Your Kingdom
The idea of this project is to create a game where the user defend their castle from enemies by being able to pick them up and throw them as well as use tools and weaponry to help. This game was originally inspired by the flash game *Defend Your Kingdom* which is available to play on [Kongregate](https://www.kongregate.com/games/zack6723/random-flash-game).

All developmental note below refers to the 11/30/2019 edition of the project.

## What can you do in this game?
As of beta, the game has 3 stages that takes place immediately one after another. The user can throw tanks to destroy them as well as the balloon variant, grab missiles to bust them, and yeet saucers back to their home planet. Once the user reach the space stage, the game will go on endlessly at that stage.

## Difficulty
The game has three difficulty as well as a secret dev mode difficulty that can be found to the left of the easy box if the user walks through the wall. Each difficulty applies a different modifier to the damage the enemy deals to the castle, making it so that the castle will fall faster at higher difficulty. This thus leave the user with less room for errors in their decision making and skills.

## User Interface
The castle has a health and a round counter above it so that the user can observe the state of the castle. These counter are dynamic and will change accordingly. A count down will also appear in front of the user whenever a round is about to begin. The user can also summon a wand by using the left touch pad to open a spawner or the spacebar if using the simulated model. When grabbing the spawner, a wand will spawn in front of them.

### The wand
The wand is a weapon of magic wielded by wizards of all of fantasy, and in D&D campaigns. The wand was coded so that upon grabbing it, the wand will shoot a bolt of kinetic energy that pushes the vehicle it touches back. The bolt is a ball that has a particle trail on it that lingers a little while before dissapearing. Since it activate on grab, the user has to do cool tricks to utilize it to its full potential.

## Stages
The first stage is a ground level where the player can walk around as well as use VRTK's teleport function to move further than their room space. The second stage is when the castle will begin to fly using the power of the hot air balloon. Here, the user is larger and should be able to comfortably walk around the castle to grab enemies. Since tank can't fly, we've attached balloon to the tank in order to keep the tank relevant. After the user beat this stage, the castle's hot air balloon will deflate and it's rocket booster hidden in its tower will reveal itself and we have lift off! In the space stage, the user will still find missiles, but also two different UFO's. These alien have no intention of letting you preserve your kingdom. The stage remains in this space level for the rest of the game. Each of these stages has a different sky box to reflect their enviroment.

--- 

## Type of enemies
As of this writing, there are five different enemies: tank, flying tank, missile, saucer, and red saucers.

### Tank
The tank is a ground vehicle that's job is to turn the castle into rubble. The tank model is made by James Trinh on Blender and is actually compose of two seperate model: the turret and the body. The tank is program to constantly move towards the modular targeting object that we choose, in which case is an invisible cube inside the castle. Upon arriving a certain distant from the castle, the tank will stop and damage the castle's health. The tank also has a turret that constantly face the targeting object as well. While programming this function, the tank wasn't always facing the right direction since it considered forward on its side so we had to manually correct it by doing some vector arithmetic.

### Flying Tank
What happens when you add a balloon to a 50 ton siege machine? You get a flying machine! This tank can be popped by grabbing and tossing it aside. The flying tank is pretty much the tank but with a balloon. Upon releasing the tank, the balloon will pop and emmit a sound that's audible to the player.

### Missile
The missile model was originally going to be an airplane but it felt inappropriate to have kamikaziing airplanes so we made it a large rocket instead. It has 

### Saucer
Aliens from another planet are not happy with your kingdom! They came light years away to end your reign! These ships ram your castle and are quite durable! To defeat them, you must toss them back to their home planet from wence they came!

### Red Saucer
Similarly to the regular saucer, these saucer has a gun that shoots lasers at your castle. They can damage your castle from a further distance so be on guard!

---

## Potential Improvements Planned
With the timespan we had, we felt we finish a rough skeleton of how the game will be, but we didn't get to implement everything to consider it a complete game as there's a lot of thing left to be implemented. Some of the things we wanted to add are listed below.

* A homerun bat from *Super Smash Bros.* or a gravity hammer from *Halo* equivalent. This would send the enemy flying on contact.
* Other planets that the user can fly their kingdom to to colonise.
* More enemy variety
* Shopping menu to buy upgrade between rounds.

---

## Credit:
Starting below here, will be a list of all assets we used in this project.

### Coding Guide & Sources
https://assetstore.unity.com/detail/2d/textures-materials/sky/earth-planets-skyboxes-53752
VRTK - (TODO)
Particle - https://www.youtube.com/watch?v=agr-QEsYwD0

### Models, Textures, & Effects
| Number | Item | Credit |
| ------ | ---- | ------ |
| We     | are  | cool   |

Missile Trail Particle - James
Tank - James
Castle - James
Pine Tree - James
Missile - James
Low Poly Mountain - https://free3d.com/3d-model/mountain-low-poly-mount1-41534.html
flag - https://www.turbosquid.com/3d-models/free-max-model-flags-games/756168
farm - https://sketchfab.com/3d-models/low-poly-farm-4ee929f6f461470f9e97f8f0e5c004e1
Snow Tree - https://free3d.com/3d-model/low-poly-snowy-tree-134146.html
Big Foot Model - https://free3d.com/3d-model/bigfoot-v1--814637.html

### Sounds
Intro Fanfare - https://freesound.org/people/CGEffex/sounds/99961/
Tank idle - https://freesound.org/people/ibirdfilm/sounds/128160/


#codes
rigid body volocity - https://docs.unity3d.com/ScriptReference/Rigidbody-velocity.html
Instantiate - https://docs.unity3d.com/ScriptReference/Object.Instantiate.html
