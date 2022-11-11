NOTEs   the clipshader lets ClipShader is the only one tested and used.



///COMPUTENOTES
it builds on compute and shader conductor but sampling doesnt work

its a bunch of workarounds and the whole thign might be too complex


mipmap leves are supported in dx 10..     i dont know how well the conduct to GL


evne my basic shader woudnt compile.    mabye  it doenst neeed a render target either.. to clip..


there i s no iOS package..


mabye i can use the s0 register now.
////END COMPUTE


the mogogame mult platform sampe means i should need console dx and windows dx... just a one projects
the windowing n MG 3.8.1 is generalized.. im not sure how well it works on linxu thoug.


so setting windo to maximized and position and dpiawaerness MIGHT work.. property...





you draw two textures, on will ChipShader a texture is provided and a mask texture.. the white pixels defines what is is the clip region.. 
Everything else is not drawn so the hole should be the backgronund coor.



e white pixes are considered transparent part  on the mask testure.  So the clip region is defined by white pixels,255,255,255,255.


everything esle is not drawn.


clippig might have oehr ways but they are complex and
I wanted to make a simple shader that works on desktop GL , dX and and droid, and not open up the Basic effect or figure out the stencil stuff..


its uses render target and wasnt easy to make it work on all... muttisample wokrs on GL and DX destop but not on android so i left it out..

might be a issue or i might have set it up wrong.  


The other shaders are from old XNA samples they might not work.. I just left them as samples .. they do compile 


Android works on debug but not in release and deploy