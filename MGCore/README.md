NOTEs   the clipshader should probably use a stencil
 
 even a simple branch if ( color == vec4(1, 1,1,1)  doesnt work in opengl
                             

to move to net 7 just change Net6 to 7 in all the project files.

e white pixes are considered transparent part  on the mask testure.  So the clip region is defined by white pixels,255,255,255,255.


everything esle is not drawn.


I wanted to make a simple shader that works on desktop GL , dX and and droid, and not open up the Basic effect or figure out the stencil stuff..


press space to toggle new tests,   add shaders,   press E to toggle shader effect 

not all work yet

 

