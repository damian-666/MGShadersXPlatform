
put all the game code in one place, in on soln, with links, no maintainence of duplicates or manual copying or linking
add assets to the code, mgcb , build targets and go.

tested with usb debug, arm64 and emulator on vs2022 preview 7/30/2022 latest update.

compile some shaders and some other assets.. some are old and untested , but the clip one works on gL , dx , 
and winodws and it wanst easy.. render target is used.

Basic Effect or stencils can probably do it but i couldn get it to wokr so i just made a shader cause i need 
to learn how to write shader that transpile anyways.  

Ive only tested my Clipshader.  it works but there mere more bugs then and mabye things would be simler witn mg 3.81
i did it on MG 3.8  and some of the issues like multisampling or aliasing mayb have been fixed.


if you see a yellow hole in the mess is being clipped and has a transparent hole, like a mask.

im filling the screen fully on a samsung with  a notch, using old tips but i dont konw if they are still relevant..
i get warnings on ths from the android build..