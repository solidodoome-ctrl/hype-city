
# HYPE CITY - Unity Scene Setup Guide

## 1. Create the Unity project
- Use Unity 6 LTS.
- Select the Universal 3D (URP) template.
- Name the project HYPE CITY.
- Set the target platform to Android first.

## 2. Create the player
1. Create a Capsule GameObject named Player.
2. Add a CharacterController component.
3. Add the HypeCityPlayerController script.
4. Set the player's position to (0, 1, 0).

## 3. Set up the camera
1. Select Main Camera.
2. Add HypeCityCameraFollow.
3. Assign the Player Transform to Target.
4. Adjust the offset if needed.

## 4. Set up the mobile joystick
1. Create a Canvas.
2. Add a GraphicRaycaster if one is not present.
3. Create an EventSystem if one is not present.
4. Create a joystick background using a UI Image.
5. Create a handle using another UI Image.
6. Add HypeCityVirtualJoystick to the background.
7. Assign the background, handle, and Player references.
8. Adjust the handle range to match the joystick size.

## 5. Set up hair customization
1. Add HypeCityHairCustomizer to the character.
2. Add hairstyle GameObjects as children of the character.
3. Assign the hairstyle objects to Hair Styles.
4. Assign the hair mesh Renderers to Hair Renderers.
5. Test SelectHairStyle and SelectHairColor.

## 6. Create a test environment
- Add a Plane for the ground.
- Add a few buildings and obstacles.
- Add directional lighting.
- Test movement and camera following.

## 7. Mobile testing
- Test touch controls on Android.
- Check performance on a real phone.
- Test different screen sizes.
- Optimize graphics before adding more city content.

## Important
These steps are for the first prototype. Multiplayer, character animations, vehicles, and the full city will be added in later stages.
