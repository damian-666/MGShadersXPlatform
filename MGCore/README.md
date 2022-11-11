NOTEs   the clipshader lets ClipShader is the only one tested and used.

you draw two textures, on will ChipShader a texture is provided and a mask texture.. the white pixels defines what is is the clip region.. 
Everything else is not drawn so the hole should be the backgronund coor.


to move to net 7 just change Net6 to 7 in all the project files.

e white pixes are considered transparent part  on the mask testure.  So the clip region is defined by white pixels,255,255,255,255.


everything esle is not drawn.


clippig might have oehr ways but they are complex and
I wanted to make a simple shader that works on desktop GL , dX and and droid, and not open up the Basic effect or figure out the stencil stuff..


its uses render target and wasnt easy to make it work on all... muttisample wokrs on GL and DX destop but not on android so i left it out..

might be a issue or i might have set it up wrong.  


The other shaders are from old XNA samples they might not work.. I just left them as samples .. they do compile 


Android works on debug but not in release and deploy
