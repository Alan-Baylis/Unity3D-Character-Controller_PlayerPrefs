**Table of Contents**
- [This Repository and It's Content](#)
- [Important Reminder](#)
- [Using this script bundle as a first-person controller](#)
- [Using this script bundle as a third-person controller](#)

# This Repository and It's Content
Use of these scripts is free (http://unlicense.org). Crediting the author (me! :D) is not required at all, although it is not discouraged or unwelcomed - though I do ask that anyone using these assets contribute to the public domain as well by releasing as many scripts and projects as you feel comfortable with under the Unlicense or similar licenses where you can legally and ethically do so.
These scripts may sometimes serve purposes already covered by standard Unity assets, but mine are generally easier to understand and shorter/ lighter weight, allowing for more customizability. They will, furthermore, generally be made to fit standard/ default PC control schemes where applicable and may not work on other platforms.

# Important Reminder
Whenever you use a script from this repository, make sure to read the documentation comment attached to the top of the script to make sure you are using the script correctly. Also attached are explanatory comments that explain code segments, but these should not be necessary to use unless you are editing the script directly.

# Using this script bundle as a first-person controller


# Using this script bundle as a third-person controller
1. Create a 3D game object with a collider (a capsule is recommended). This will be referred to as the “player.”
2. From the inspector, apply a Rigidbody to the player. I recommend going into constraints and freezing X rotation and Z rotation. (If the character randomly “jumps” to a certain altitude,ensure that the surface it is standing on is not convex. If this does not fix the issue, consider also freezing the Y position.)
3. Create an empty game object and drag it onto the player object, making it a child object of the player. Ensure that the (local) X, Y and Z coordinates are 0 from the transform component. This will be referred to as the “pivot.”
4. Create a camera object and drag it onto the pivot, making it a child object of the pivot. Move  and rotate the camera so that the player can be seen from your desired perspective.
5. Create a C# file and name it “characterMoveController” (without quotes).
6. Open the file and delete all the starter code, then paste in the code from the characterMoveController.cs file in this repository.
7. Save the file and drag it onto the player.
8. Create a C# file and name it “characterLookController” (without quotes).
9. Open the file and delete all the starter code, then paste in the code from the characterLookController.cs file in this repository.
10. Save the file and drag it onto the pivot.
 
**You can skip this step if you have ways in place for configuring controls, although reviewing the “setDefaults.cs” file is still recommended. This script bundle will not work if the controls are not configured.** 
  For testing purposes, and for games in which the controls do not change, I have included a script “setDefaults.cs” to set default controls for player movement according to my personal preferences. To use it, create a C# file and name it “setDefaults” (without quotes); Open the file and delete all the starter code, then paste in the code from the setDefaults.cs file in this repository; save the file and drag it onto the player.
