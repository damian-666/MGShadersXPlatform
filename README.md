The main point of this sample is to show how to organize code that uses netcore6 and targets both mobile and desktops.


 it basically a simpler verson of https://github.com/MonoGame/MonoGame.Samples that target netcore3.1 and netstandard 2.

 now its all net6.. but took over a week  to update t, just for the simple thing im doing.   Those original samples would be ideal to have more canonical and minimal structures.   mine demos a render target, a clip shader, transforms, and mutliple platfroms with one core game and one place for assets, also touching assets marketed embedded resource ( a workaroudn that might cause bloating if trimming is OFF, whihcc it is for now.. triggers immediate changes on build.  its for development , mabye not final deployment or archiving which i havent done but i can get a releasee build on my phone via usb, have not published to Google Play wiht this as AABB as a open beta but ill wait til things stabilize before trying that
 
 TESTED vs 2022 preview latest.    android release / debug/  samsung arm64.. anycpu might work but i had and issue. 
 
 the clip shader takes an image an a mask , it  allows holes.. basically if the mask is  not white, it wont draw that part of the testure to be clipped.  Alpha Blendning works but has regressing, differences in GL and im dont care for now it will get sorted out later.   the regression is related to multisampling i think, in Gl on desktop.
 
 NOTES:  if you plug in you phone via USB choose the LOWEST device (samsung bllah blah ) in the drop down... or it wll go to the emulator in vs 2022.. now u can tweak a fx file  ( if marked as embedded resource, just to get it to cause a rebuild of the core and make the content builder rebuid) , hit cntr f5 and see a new result. on dx , GL and droid.    debug and release.
 the emulators even on a 2500 surface rpo win 11, HAXM, etc that runs HOT,  are so slow i recommend a touch device like a surface, and or debuging  via usb or wifi.    I have not archived , sideloaded successfully yet and not ready to.   Ideally a cheap ARM surface running native ARM on windows and vs 2022 ARM would be maybe good way to develop your android app, then finishing touches and periodic testing on actual phones and emulators..   IOS is in there and havent tested it.
 
all the game code and assets are in a libary tht is linked to GL as a proxy., buts its the target EXE that chooses the graphics pipeline as DX or GL.

this is a simple sample but includes textures , shaders ,and render targets and does transparancy and masking.

Most of the other shaders were collected from various samples years old. But none of the projects built in both Gl and DX and worked without tons of extra adjustment.  The are old XNA samples everywhere that either use netstandard that is not supported with net6 /7 exes, a shahed code folder  which muyst build with each target..


Basic Effect or stencils can probably do it but i couldn get it to work so i just made a shader cause i need 
to learn how to write shaders that transpiles anyways.  

if you see a yellow hole in the mess is being clipped and has a transparent hole, like a mask.

it basically ths tutorial https://gmjosack.github.io/posts/my-first-2d-pixel-shaders-part-1/ but with code u can run anything with no repeat or special mods.


tested with usb debug, arm64 and emulator on vs2022 preview latest update.. tested wiht net 7 , trivial change all 6 to 7 , works.
