# simpleFPS

Unity version: 2021.3.5f1

Simple fps with the ability to use weapons

Used:
- ScritableObjects
- Object pooling
- Events
- Player input

# Control
The game supports both keyboard and gamepad controls

Keyboard and mouse:
- W - move forward
- S - move backward
- A - move left
- D - move right
- Space - jump
- Left shift - sprint
- R - reload/special action
- Right mouse button - attack

Gamepad for example Xbox:
- Left analog - character movement
- Right analog - camera movement/look around
- A - jump
- X - reload/special action
- LB - sprint
- RT - attack
- left arrow - previous item
- right arrow - next item


# Weapons
Weapons have their own characteristics such as damage, reload time, spread, ammo count, and magazine size. Weapons also have a specific type of material they affect. The implementation of weapon positioning is easy to extend to melee weapons, for example.


# Items
Each object on the map reacts to weapon bullets. Objects are divided into those that take damage and those that serve only as background elements without the possibility of being destroyed. Each object with an assigned material will appropriately indicate the point of impact through the particle system. If an object lacks material information, it is treated as if it were made of metal for visualization purposes
![image](https://github.com/Sabekk/simpleFPS/assets/5255050/97dca146-9a5f-4218-80b4-5620b2b7ee8c)

![image](https://github.com/Sabekk/simpleFPS/assets/5255050/451bfeed-6f59-44fc-b1aa-9ded16bcda45)


Items that react to damage at the end of their life trigger actions added to the object.
Currently implemented actions:
- visual effect
- object replacement
- influence on the attached object

Effects can be combined with each other
![image](https://github.com/Sabekk/simpleFPS/assets/5255050/73377536-016b-4e9c-b2a2-7011bb9e5a8b)


# UI

The user is informed about the current status of the weapon and the currently equipped item via an always visible HUD
![image](https://github.com/Sabekk/simpleFPS/assets/5255050/ca720106-d962-49f0-a8d0-5716992a87c2)

After hitting an object that reacts to damage, the player is informed about the damage done and the current status of the item
![image](https://github.com/Sabekk/simpleFPS/assets/5255050/74e3b0cf-303e-4ba3-823d-e86a61932e51)

If the weapon held by the player has no effect on the attacked item, the player is also informed about it with a message
![image](https://github.com/Sabekk/simpleFPS/assets/5255050/587cf4e8-0417-4eb7-9670-879b7f8220e7)

