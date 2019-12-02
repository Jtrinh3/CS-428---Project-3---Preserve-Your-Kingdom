# Project 3 Preserve Your Kingdom
<p float="center">
<img src="https://raw.githubusercontent.com/Jtrinh3/CS-428---Project-3---Preserve-Your-Kingdom/master/docs/Proj%203%20Annotations/Cover%20Photo.jpg" width="100%">
</p>

Weblink: [https://jtrinh3.github.io/CS-428---Project-3---Preserve-Your-Kingdom/](https://jtrinh3.github.io/CS-428---Project-3---Preserve-Your-Kingdom/)
Project Link: [https://github.com/Jtrinh3/CS-428---Project-3---Preserve-Your-Kingdom/](https://github.com/Jtrinh3/CS-428---Project-3---Preserve-Your-Kingdom/)

The idea of this project is to create a game where the user defend their castle from enemies by being able to pick them up and throw them as well as use tools and weaponry to help. This game was originally inspired by the flash game *Defend Your Kingdom* which is available to play on [Kongregate](https://www.kongregate.com/games/zack6723/random-flash-game).

All developmental note below refers to the 11/30/2019 edition of the project.

## What can you do in this game?
As of beta, the game has 3 stages that takes place immediately one after another. The user can throw tanks to destroy them as well as the balloon variant, grab missiles to bust them, and yeet saucers back to their home planet. Once the user reach the space stage, the game will go on endlessly at that stage. The user can also spawn a wand to aid them in battle.

## Difficulty
<p float="center">
  <img src="https://raw.githubusercontent.com/Jtrinh3/CS-428---Project-3---Preserve-Your-Kingdom/master/docs/Proj%203%20Annotations/difficulty.jpg" height="40%">
</p>
The game has three difficulty as well as a secret dev mode difficulty that can be found to the left of the easy box if the user walks through the wall. Each difficulty applies a different modifier to the damage the enemy deals to the castle, making it so that the castle will fall faster at higher difficulty. This thus leave the user with less room for errors in their decision making and skills.

## The Castle
<p float="center">
  <img src="https://raw.githubusercontent.com/Jtrinh3/CS-428---Project-3---Preserve-Your-Kingdom/master/docs/Proj%203%20Annotations/Castle%20Interface.jpg" height="40%">
</p>
The castle has a health and a round counter above it so that the user can observe the state of the castle. These counter are dynamic and will change accordingly. The castle will also catch on fire when it is at 0 health.

## User Interface
A count down will also appear in front of the user whenever a round is about to begin. If the user loses, a game over message is displayed.
<p float="center">
  <img src="https://raw.githubusercontent.com/Jtrinh3/CS-428---Project-3---Preserve-Your-Kingdom/master/docs/Proj%203%20Annotations/Wand%20Spawner.jpg" height="30%">
</p>
The user can also summon a wand by using the left touch pad to open a spawner menu or the spacebar if using the simulated model. When grabbing the spawner, a wand will spawn in front of them. This UI style is inspired by 3D modeling program and painting program that we saw during the student choice presentation.

### The wand
<p float="center">
  <img src="https://raw.githubusercontent.com/Jtrinh3/CS-428---Project-3---Preserve-Your-Kingdom/master/docs/Proj%203%20Annotations/Wand.jpg" width="50%">
</p>
The wand is a weapon of magic wielded by wizards of all of fantasy, and in D&D campaigns. The wand was coded so that upon grabbing it, the wand will shoot a bolt of kinetic energy that pushes the vehicle it touches back. The bolt is a ball that has a particle trail on it that lingers a little while before dissapearing. Since it activate on grab, the user has to do cool hand tricks to utilize it to its full potential. Originally, we spent a number of hours looking for how to change the grab button or add an additional toggle grab button with VRTK to no avail. Other games with objects of similar nature utilize the side grab as a toggle grab with orientation hold and then has the trigger button to activate or use the object. Since we were using the trigger button to grab, there didn't seem to be an immediate method to optimally allow the user to shoot while holding the wand.

## Stages
<p float="center">
  <img src="https://raw.githubusercontent.com/Jtrinh3/CS-428---Project-3---Preserve-Your-Kingdom/master/docs/Proj%203%20Annotations/Stages.png" height="66%">
</p>
The first stage is a ground level where the player can walk around as well as use VRTK's teleport function to move further than their room space. The second stage is when the castle will begin to fly using the power of the hot air balloon. Here, the user is larger and should be able to comfortably walk around the castle to grab enemies. Since tank can't fly, we've attached balloon to the tank in order to keep the tank relevant. After the user beat this stage, the castle's hot air balloon will deflate and it's rocket booster hidden in its tower will reveal itself and we have lift off! In the space stage, the user will still find missiles, but also two different UFO's. These alien have no intention of letting you preserve your kingdom. The stage remains in this space level for the rest of the game. Each of these stages has a different sky box to reflect their enviroment.

--- 

## Type of enemies
As of this writing, there are five different enemies: tank, flying tank, missile, saucer, and red saucers which are all explained below.

### Tank
<p float="center">
  <img src="https://raw.githubusercontent.com/Jtrinh3/CS-428---Project-3---Preserve-Your-Kingdom/master/docs/Proj%203%20Annotations/e1.jpg" width="50%">
</p>
The tank is a ground vehicle that's job is to turn the castle into rubble. The tank model is made by James Trinh on Blender and is actually compose of two seperate model: the turret and the body. The tank is program to constantly move towards the modular targeting object that we choose, in which case is an invisible cube inside the castle. Upon arriving a certain distant from the castle, the tank will stop and damage the castle's health. The tank also has a turret that constantly face the targeting object as well. While programming this function, the tank wasn't always facing the right direction since it considered forward on its side so we had to manually correct it by doing some vector arithmetic.

### Flying Tank
<p float="center">
  <img src="https://raw.githubusercontent.com/Jtrinh3/CS-428---Project-3---Preserve-Your-Kingdom/master/docs/Proj%203%20Annotations/e2.jpg" width="50%">
</p>
What happens when you add a balloon to a 50 ton siege machine? You get a flying machine! This tank can be popped by grabbing and tossing it aside. The flying tank is pretty much the tank but with a balloon. Upon releasing the tank, the balloon will pop and emmit a sound that's audible to the player. Balloon model created by Helene H. from the sketchup 3d warehouse.

### Missile
<p float="center">
  <img src="https://raw.githubusercontent.com/Jtrinh3/CS-428---Project-3---Preserve-Your-Kingdom/master/docs/Proj%203%20Annotations/e3.jpg" width="50%">
</p>
The missile model was originally going to be an airplane but it felt inappropriate to have kamikaziing airplanes so we made it a large rocket instead. Similarly to the tank, the missile fly towards the castle facing it all the time. The missile emit a sound that is clearly audiable as well as an explosion upon impact or getting stopped by the player. The particle trail was created by modifying unity's default particle system so that it has different color base on it's time life and spread to only behind it. We kept the particle count low to reduce potential performance impact. The model was created using blender by James.

### Saucer
<p float="center">
  <img src="https://raw.githubusercontent.com/Jtrinh3/CS-428---Project-3---Preserve-Your-Kingdom/master/docs/Proj%203%20Annotations/e4.jpg" width="50%">
</p>
Aliens from another planet are not happy with your kingdom! They came light years away to end your reign! These ships ram your castle and are quite durable! To defeat them, you must toss them back to their home planet from wence they came! The model is created by James using Blender.

### Red Saucer
<p float="center">
  <img src="https://raw.githubusercontent.com/Jtrinh3/CS-428---Project-3---Preserve-Your-Kingdom/master/docs/Proj%203%20Annotations/e5.jpg" width="50%">
</p>
Similarly to the regular saucer, these saucer has a gun that shoots lasers at your castle. They can damage your castle from a further distance so be on guard! The model was created by P.Handover from the sketchup 3d warehouse

---

## What we learned
Project two was our main goal that drove us to start this project since Unity didn't seem that bad to work with. We wanted to work on a more coding focus project than project 2 also. During this project, we learned about public declarations for classes so that we can make modules or our own "prefabs" rather than repeat code too often. This greatly sped up developement time and also optimize the program in the sense that it does not need to do a search for the object by name every time. Enemies incorporated this by having a target object to home in on. The item spawner also use this to clone a wand by instantiating whatever object we set it to. Modulating codes definitely takes some effort but saves so much time in the long run.

## Potential Improvements Planned
With the timespan we had, we felt we finish a rough skeleton of how the game will be, but we didn't get to implement everything to consider it a complete game as there's a lot of thing room for improvements. Some of the things we wanted to add are listed below.

* A homerun bat from *Super Smash Bros.* or a gravity hammer from *Halo* equivalent. This would send the enemy flying on contact.
* Other planets that the user can fly their kingdom to to colonise.
* More enemy variety
* Shopping menu to buy upgrade between rounds. The idea was to have the castle upgrade be a surprise option.

---

## Credit:
Starting below here, will be a list of all assets we used in this project.

### Guide & Resources used

| Name | Resource Link |
| ----- | ------------- |
| VRTK v3 | https://github.com/ExtendRealityLtd/VRTK |
| Particle Guide | https://www.youtube.com/watch?v=agr-QEsYwD0 |
| Rigid body velocity | https://docs.unity3d.com/ScriptReference/Rigidbody-velocity.html |
| Instantiate | https://docs.unity3d.com/ScriptReference/Object.Instantiate.html |

### Models, Textures, & Particles TODO

<p float="center">
  <img src="https://raw.githubusercontent.com/Jtrinh3/CS-428---Project-3---Preserve-Your-Kingdom/master/docs/Proj%203%20Annotations/annotation%201.jpg" width="80%">
</p>

| Number | Item | Source |
| --- | ------------------- | --------------- |
| 1   | Initial Walls & Ceiling - Used for the difficulty setting room | [Unity Asset Store](https://assetstore.unity.com/packages/2d/textures-materials/stone/dungeon-stone-textures-66487) |
| 2   | Initial Floor - Used for the difficulty setting room | [Unity Asset Store](https://assetstore.unity.com/packages/2d/textures-materials/stone/dungeon-stone-textures-66487) |
| 3   | Grass - The grass on the Castle's home planet | [Unity Asset Store](https://assetstore.unity.com/packages/2d/textures-materials/glass/stylized-grass-texture-153153) |
| 4   | Pine Tree - Scattered throughout the enviroment | Created by James Trinh |
| 5   | Snowy Tree - Scatter further out towards the mountains | [free3d.com](https://free3d.com/3d-model/low-poly-snowy-tree-134146.html) |

<p float="center">
  <img src="https://raw.githubusercontent.com/Jtrinh3/CS-428---Project-3---Preserve-Your-Kingdom/master/docs/Proj%203%20Annotations/annotation%202.jpg" width="80%">
</p>

| Number | Item | Credit |
| --- | ------------------- | --------------- |
| 6   | Castle - The castle that the player defend  | Created by James Trinh |
| 7   | Flags - The 4 flags above the castle  | [turbosquid.com](https://www.turbosquid.com/3d-models/free-max-model-flags-games/756168) |

<p float="center">
  <img src="https://raw.githubusercontent.com/Jtrinh3/CS-428---Project-3---Preserve-Your-Kingdom/master/docs/Proj%203%20Annotations/annotation%203.jpg" width="80%">
</p>

| Number | Item | Credit |
| --- | ------------------- | --------------- |
| 8   | Farm - Use to add to scenary in the distance  | [sketchfab.com](https://sketchfab.com/3d-models/low-poly-farm-4ee929f6f461470f9e97f8f0e5c004e1) |
| 9   | Mountain - Use to add to scenary in the distance  | [free3d.com](https://free3d.com/3d-model/mountain-low-poly-mount1-41534.html) |

<p float="center">
  <img src="https://raw.githubusercontent.com/Jtrinh3/CS-428---Project-3---Preserve-Your-Kingdom/master/docs/Proj%203%20Annotations/annotation%204.jpg" width="80%">
</p>

| Number | Item | Credit |
| --- | ------------------- | --------------- |
| 10  | Wand - Can be spawned by the wand spawner. It's particle is also made by the same creator. | Created by James Trinh |
| 11  | HTC Vive Controller - Came with VRTK  | [VRTK](https://github.com/ExtendRealityLtd/VRTK) |

<p float="center">
  <img src="https://raw.githubusercontent.com/Jtrinh3/CS-428---Project-3---Preserve-Your-Kingdom/master/docs/Proj%203%20Annotations/annotation%205.jpg" height="50%">
</p>

| Number | Item | Credit |
| --- | ------------------- | --------------- |
| 12  | Sasquach - A little easter egg hidden in the distant mountain  | [free3d.com](https://free3d.com/3d-model/bigfoot-v1--814637.html) |

<p float="center">
  <img src="https://raw.githubusercontent.com/Jtrinh3/CS-428---Project-3---Preserve-Your-Kingdom/master/docs/Proj%203%20Annotations/annotation%206.jpg" width="80%">
</p>

| Number | Item | Credit |
| --- | ------------------- | --------------- |
| 13  | Tank - A tank body & turret  | Created by James Trinh |

<p float="center">
  <img src="https://raw.githubusercontent.com/Jtrinh3/CS-428---Project-3---Preserve-Your-Kingdom/master/docs/Proj%203%20Annotations/annotation%207.jpg" width="80%">
</p>

| Number | Item | Credit |
| --- | ------------------- | --------------- |
| 14  | Missile Trail - Particle for the missile  | Created by James using Unity's default sprite |
| 15  | Missile - Missile model for the enemy missile  | Created by James Trinh |
| 16  | Balloon - The visual to explain how the castle flies into the sky | [Sketchup 3d Warehouse](https://3dwarehouse.sketchup.com/model/7cfb4b02ff474646a3b49659a35d89f9/Hot-air-baloon-15-min) |

<p float="center">
  <img src="https://raw.githubusercontent.com/Jtrinh3/CS-428---Project-3---Preserve-Your-Kingdom/master/docs/Proj%203%20Annotations/annotation%208.jpg" width="80%">
</p>

| Number | Item | Credit |
| --- | ------------------- | --------------- |
| 17  | Flying Tank - A tank attatched to a balloon  | Tank created by James Trinh - [Sketchup 3d Warehouse](https://3dwarehouse.sketchup.com/model/488c8c47-d380-4dfc-87ec-83ccd6b05339/Balloon) |

<p float="center">
  <img src="https://raw.githubusercontent.com/Jtrinh3/CS-428---Project-3---Preserve-Your-Kingdom/master/docs/Proj%203%20Annotations/annotation%209.jpg" width="80%">
</p>

| Number | Item | Credit |
| --- | ------------------- | --------------- |
| 18  | Rocket Booster & Particles - The Rockets that propel the castle to space with unity particles acting as fire | [Sketchup 3d Warehouse](https://3dwarehouse.sketchup.com/model/c3ac9865b1a2199097bdb856e43e27d3/Saturn-V-Rocket-Engine-UPDATEv2) |
| 19  | UFO Saucer - The basic UFO  | Created by James Trinh |
| 20  | Red Saucer - The UFO that shoots at the castle | [Sketchup 3d Warehouse](https://3dwarehouse.sketchup.com/model/22fe5c33fe2b8b408b700cf351204203/UFO) |

<p float="center">
  <img src="https://raw.githubusercontent.com/Jtrinh3/CS-428---Project-3---Preserve-Your-Kingdom/master/docs/Proj%203%20Annotations/Annotation%2010.png" width="80%">
</p>

| Number | Item | Credit |
| --- | ------------------- | --------------- |
| 21  | Sky Skybox - The skybox for when the castle is in the planet's atmosphere | [Unity Asset Store](https://assetstore.unity.com/packages/2d/textures-materials/sky/colorskies-91541) |
| 22  | Space Skybox - A beautiful view of the planet earth for the castle to see in space  | [Unity Asset Store](https://assetstore.unity.com/detail/2d/textures-materials/sky/earth-planets-skyboxes-53752) |

### Sounds TODO

| Number | Item | Credit |
| --- | ------------------- | --------------- |
| 1  | Intro Fanfare | [freesound.org](https://freesound.org/people/CGEffex/sounds/99961/) |
| 2  | Tank Idle  | [freesound.org](https://freesound.org/people/ibirdfilm/sounds/128160/) |
| 3  | Wand Noise  | Created by James Trinh |
| 4  | Balloon Inflate | [SoundDogs](https://retired.sounddogs.com/sound-effects/balloon-inflating-blowing-air-598601) |
| 5  | Missile and Castle Rocket Noise  | [SoundDogs](https://retired.sounddogs.com/sound-effects/rocket-launch-long-away-430071) |
| 6  | Missile Explosion | [Zedge](https://www.zedge.net/ringtone/49e70902-e4fc-3544-8dc5-7dfd45228ddc) |
| 7  | Tank Balloon Pop | [Zedge](https://www.zedge.net/ringtone/a7703113-1f86-3123-a69b-e6ea7f95e363) |
| 8  | Castle Balloon Deflate | [Zedge](https://www.zedge.net/ringtone/bf690909-1e45-3710-8066-e92fb5ae0398) |
| 9  | UFO Sound | [Zedge](https://www.zedge.net/ringtone/44f6c701-335a-3fc6-936e-5225d3201f02) |
| 10 | UFO Laser | [Zedge](https://www.zedge.net/ringtone/eb1aded2-276e-3050-9ded-f8f5a753f54a) |
| 11 | Engine Moving | [Zedge](https://www.zedge.net/ringtone/b65c58f7-4ae0-37ba-9775-03d2c13ee6dd) |
| 12 | Fire | [Zedge](https://www.zedge.net/ringtone/9541c810-57ce-31cb-92aa-b30af7414625) |

