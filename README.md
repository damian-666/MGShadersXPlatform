The main point of this sample is to show how to organize code that uses netcore6 and targets both mobile and desktops.  "Write Once deploy Anywhere"   Its for a game or sim that could work on both a pc and a tablet or phone with keyboard, virtual gamepad, or simple touch, and custom UI..  There are no dependencies besides Monongame and NetCore.

UPDATE:  Tried the bait and switch method with the Compute fork from NuGet  , there are issues:


  MonoGame.Framework.Android.Compute.Bulder.Task 3.8.2

    <PackageReference Include="MonoGame.Framework.Compute.DesktopGL" Version="3.8.2" />
    <PackageReference Include="MonoGame.Framework.DesktopGL" Version="3.8.1.303">  -> ="MonoGame.Framework.Compute.DesktopGL"   mabye leavng is at 
    "MonoGame.Framework.DesktopGL" Version="3.8.1.303"> on the shraed dlls will work...   it was working but some chnages happened.. I think that fork needs to public a symbol proxy for hte dll. 

 it basically an updated but more complex verson of https://github.com/MonoGame/MonoGame.Samples that target netcore3.1 and netstandard 2.

 now its all net6.. but took over a week  to update t, just for the simple thing im doing.   Those original samples would be ideal to have more canonical and minimal structures.   mine demos a render target, a clip shader, transforms, and mutliple platfroms with one core game and one place for assets, also touching assets marketed embedded resource ( a workaroudn that might cause bloating if trimming is OFF, whihcc it is for now.. triggers immediate changes on build. 
 
 Should deploy on all platfroms except consoles, that MONOGAME supports.  I would like to try the ComputeShader branch for physics stuff like fluids
 
 TESTED vs 2022 preview latest.   Net7.    android release / debug/  samsung arm64.. 
 
 the clip shader takes an image an a mask , it  allows holes.. basically if the mask is  not white, it wont draw that part of the testure to be clipped.  Alpha Blendning works but has regressing, differences in GL and im dont care for now it will get sorted out later.   the regression is related to multisampling i think, in Gl on desktop.
 
 NOTES:  if you plug in you phone via USB choose the LOWEST device (samsung bllah blah ) in the drop down... or it wll go to the emulator in vs 2022.. now u can tweak a fx file  ( if marked as embedded resource, just to get it to cause a rebuild of the core and make the content builder rebuid) , hit cntr f5 and see a new result. on dx , GL and droid.    debug and release.
 the emulators even on a 2500 surface rpo win 11, HAXM, etc that runs HOT,  are so slow i recommend a touch device like a surface, and or debuging  via usb or wifi.    I IOS is in there and havent tested it.
 
all the game code and assets are in a libary tht is linked to GL as a proxy., buts its the target EXE that chooses the graphics pipeline as DX or GL.

Most of the other shaders were collected from various samples years old. But none of the projects built in both Gl and DX and worked without tons of extra adjustment.  The are old XNA samples everywhere that either use netstandard that is not supported with net6 /7 exes, a shahed code folder  which muyst build with each target..

Basic Effect or stencils can probably do clipping but i couldn get it to work so i just made a shader cause i needed 
to learn how to write shaders that transpiles anyways.  


it basically ths tutorial https://gmjosack.github.io/posts/my-first-2d-pixel-shaders-part-1/ but with code u can run anything with no repeat or special mods.


