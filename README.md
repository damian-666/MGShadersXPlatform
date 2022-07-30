THe main point of this sample is to show how to organize code that uses netcore6 and targets both mobile and desktops.


 it basically a simpler verson of https://github.com/MonoGame/MonoGame.Samples that targetsed netcore3.1 and netstandard 2.

 now mine its all net6.. but took over a day to update t, just for the simple thing im doing.   Those original samples would be ideal.

all the game code and assets are in a libary tht is linked to GL as a proxy., buts its the target EXE that chooses the graphics pipeline as DX or GL.

this is a simple sample but includes textures , shaders ,and render targets and does transparancy and masking.

Most of the other shaders were collected from various samples years old. But none of the projects built in both Gl and DX and worked without tons of extra complexity..  

so i put all the game code in one place, in on sln, with links, no maintainence of duplicates or manual copying or linking
add assets to the code, mgcb , build targets and go.

tested with usb debug, arm64 and emulator on vs2022 preview 7/30/2022 latest update.

compile some shaders and some other assets.. some are old and untested , but the clip one works on gL , dx , 
and winodws and it wanst easy.. render target is used.

Basic Effect or stencils can probably do it but i couldn get it to work so i just made a shader cause i need 
to learn how to write shaders that transpiles anyways.  

Ive only tested my Clipshader.  it works but there mere more bugs then and mabye things would be simler witn mg 3.81
i did it on MG 3.8  and some of the issues like multisampling or aliasing mayb have been fixed.


if you see a yellow hole in the mess is being clipped and has a transparent hole, like a mask.

im filling the screen fully on a samsung with  a notch.





it basically ths tutorial https://gmjosack.github.io/posts/my-first-2d-pixel-shaders-part-1/ but with code u can run anything with no repeat or special mods.



