# Project 3 Preserve Your Kingdom
<img src="https://raw.githubusercontent.com/Jtrinh3/CS-428---Project-3---Preserve-Your-Kingdom/master/docs/Proj%203%20Annotations/Cover%20Photo.jpg" width="100%">


The idea of this project is to create a game where the user defend their castle from enemies by being able to pick them up and throw them as well as use tools and weaponry to help. This game was originally inspired by the flash game *Defend Your Kingdom* which is available to play on [Kongregate](https://www.kongregate.com/games/zack6723/random-flash-game).

All developmental note below refers to the 11/30/2019 edition of the project.

## What can you do in this game?
As of beta, the game has 3 stages that takes place immediately one after another. The user can throw tanks to destroy them as well as the balloon variant, grab missiles to bust them, and yeet saucers back to their home planet. Once the user reach the space stage, the game will go on endlessly at that stage.

## Difficulty
The game has three difficulty as well as a secret dev mode difficulty that can be found to the left of the easy box if the user walks through the wall. Each difficulty applies a different modifier to the damage the enemy deals to the castle, making it so that the castle will fall faster at higher difficulty. This thus leave the user with less room for errors in their decision making and skills.

## The Castle
The castle has a health and a round counter above it so that the user can observe the state of the castle. These counter are dynamic and will change accordingly. The castle will also catch on fire when it is at 0 health.

## User Interface
A count down will also appear in front of the user whenever a round is about to begin. If the user loses, a game over message is displayed. The user can also summon a wand by using the left touch pad to open a spawner menu or the spacebar if using the simulated model. When grabbing the spawner, a wand will spawn in front of them.

### The wand
The wand is a weapon of magic wielded by wizards of all of fantasy, and in D&D campaigns. The wand was coded so that upon grabbing it, the wand will shoot a bolt of kinetic energy that pushes the vehicle it touches back. The bolt is a ball that has a particle trail on it that lingers a little while before dissapearing. Since it activate on grab, the user has to do cool hand tricks to utilize it to its full potential.


## Stages
The first stage is a ground level where the player can walk around as well as use VRTK's teleport function to move further than their room space. The second stage is when the castle will begin to fly using the power of the hot air balloon. Here, the user is larger and should be able to comfortably walk around the castle to grab enemies. Since tank can't fly, we've attached balloon to the tank in order to keep the tank relevant. After the user beat this stage, the castle's hot air balloon will deflate and it's rocket booster hidden in its tower will reveal itself and we have lift off! In the space stage, the user will still find missiles, but also two different UFO's. These alien have no intention of letting you preserve your kingdom. The stage remains in this space level for the rest of the game. Each of these stages has a different sky box to reflect their enviroment.

--- 

## Type of enemies
As of this writing, there are five different enemies: tank, flying tank, missile, saucer, and red saucers which are all explained below.

### Tank
The tank is a ground vehicle that's job is to turn the castle into rubble. The tank model is made by James Trinh on Blender and is actually compose of two seperate model: the turret and the body. The tank is program to constantly move towards the modular targeting object that we choose, in which case is an invisible cube inside the castle. Upon arriving a certain distant from the castle, the tank will stop and damage the castle's health. The tank also has a turret that constantly face the targeting object as well. While programming this function, the tank wasn't always facing the right direction since it considered forward on its side so we had to manually correct it by doing some vector arithmetic.

### Flying Tank TODO?
What happens when you add a balloon to a 50 ton siege machine? You get a flying machine! This tank can be popped by grabbing and tossing it aside. The flying tank is pretty much the tank but with a balloon. Upon releasing the tank, the balloon will pop and emmit a sound that's audible to the player.

### Missile
The missile model was originally going to be an airplane but it felt inappropriate to have kamikaziing airplanes so we made it a large rocket instead. Similarly to the tank, the missile fly towards the castle facing it all the time. The missile emit a sound that is clearly audiable as well as an explosion upon impact or getting stopped by the player. The particle trail was created by modifying unity's default particle system so that it has different color base on it's time life and spread to only behind it. We kept the particle count low to reduce potential performance impact. The model was created using blender by James.

### Saucer
Aliens from another planet are not happy with your kingdom! They came light years away to end your reign! These ships ram your castle and are quite durable! To defeat them, you must toss them back to their home planet from wence they came! The model is created by James using Blender.

### Red Saucer TODO
Similarly to the regular saucer, these saucer has a gun that shoots lasers at your castle. They can damage your castle from a further distance so be on guard!

---

## Potential Improvements Planned
With the timespan we had, we felt we finish a rough skeleton of how the game will be, but we didn't get to implement everything to consider it a complete game as there's a lot of thing left to be implemented. Some of the things we wanted to add are listed below.

* A homerun bat from *Super Smash Bros.* or a gravity hammer from *Halo* equivalent. This would send the enemy flying on contact.
* Other planets that the user can fly their kingdom to to colonise.
* More enemy variety
* Shopping menu to buy upgrade between rounds. The idea was to have the castle upgrade be a surprise option.

---

## Credit:
Starting below here, will be a list of all assets we used in this project.

### Coding Guide & Sources
| Usage | Resource Link |
| ----- | ------------- |
| VRTK v3 | https://github.com/ExtendRealityLtd/VRTK |
| Particle | https://www.youtube.com/watch?v=agr-QEsYwD0 |
| Rigid body velocity | https://docs.unity3d.com/ScriptReference/Rigidbody-velocity.html |
| Instantiate | https://docs.unity3d.com/ScriptReference/Object.Instantiate.html |

### Models, Textures, & Particles TODO

Annotation 1 photo

| Number | Item | Source |
| --- | ------------------- | --------------- |
| 1   | Initial Walls - Description  | [website](link) |
| 2   | Initial Floor - Description  | [website](link) |
| 3   | Grass - Description  | [website](link) |
| 4   | Pine Tree - Scattered throughout the enviroment | Created by James Trinh |
| 5   | Snowy Tree - Scatter further out towards the mountains | [website](link) |

Annotation 2 photo

| Number | Item | Credit |
| --- | ------------------- | --------------- |
| 6   | Name - Description  | [website](link) |
| 7   | Name - Description  | [website](link) |

Annotation 3 photo

| Number | Item | Credit |
| --- | ------------------- | --------------- |
| 8   | Farm - Description  | [website](link) |
| 9   | Mountain - Description  | [website](link) |

Annotation 4 photo

| Number | Item | Credit |
| --- | ------------------- | --------------- |
| 10  | Wand - Description  | Created by James Trinh |
| 11  | HTC Vive Controller - Description  | [VRTK](https://github.com/ExtendRealityLtd/VRTK) |

Annotation 5 Photo

| Number | Item | Credit |
| --- | ------------------- | --------------- |
| 12  | Sasquach - Description  | [website](link) |

Annotation 6

| Number | Item | Credit |
| --- | ------------------- | --------------- |
| 13  | Name - Description  | [website](link) |

Annotation 7

| Number | Item | Credit |
| --- | ------------------- | --------------- |
| 14  | Missile Trail - Particle for the missile  | Created by James using Unity's default sprite |
| 15  | Missile - Missile model for the enemy missile  | Created by James Trinh |
| 16  | Balloon - Description  | [website](link) |

Annotation 8

| Number | Item | Credit |
| --- | ------------------- | --------------- |
| 17  | Flying Tank - Description  | Tank part created by James Trinh TODO |

Annotation 9

| Number | Item | Credit |
| --- | ------------------- | --------------- |
| 18  | Name - Description  | [website](link) |
| 19  | Name - Description  | [website](link) |
| 20  | Name - Description  | [website](link) |

Annotation 10

| Number | Item | Credit |
| --- | ------------------- | --------------- |
| 21  | Skybox - Description  | [website](link) |
| 22  | Skybox Space - Description  | [website](https://assetstore.unity.com/detail/2d/textures-materials/sky/earth-planets-skyboxes-53752) |

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
Space Skybox - https://assetstore.unity.com/detail/2d/textures-materials/sky/earth-planets-skyboxes-53752

### Sounds
Intro Fanfare - https://freesound.org/people/CGEffex/sounds/99961/
Tank idle - https://freesound.org/people/ibirdfilm/sounds/128160/
Wand Noise - James
Missile Noise
Missile Explosion
Tank Popping

