Most of the shaders were collected from various samples years old. But none of the projects built in both Gl and DX and worked without tons of extra complexity..  the onces manually put in the shared do build and at least invert works  some of the shaders in MGCore/Content  may need the #ifdefs and right shader models added to top and bottom.    They should work with render targets but there are nuances there and i might add some clipper sample oncde i get mine working.  at least this is a sanity test u can revert to, there is alot of state to tweak that can make a blank result on GL only or something so its not easy to muck with but fx should work on all platfroms, wiht rendertargets and generating mipmaps at runtime from vector primitives too.  


havent tried with vscode either.

Androind builds but not tested since emulator is broken on win11 still.   

this was made after over a week of hunting old samples and bringing them up to date w latest .net 6 standard and content stuff, i decided i need a barebones sample when things get complex, then broken adn i cant figure out why.

dont used the content editor for the linked Content.Mgcb it will put a Target in the file, which will override the one, just erase that TArget line windows or desktopGL if you see it..   best  to  just edit it as a text file.

This is how monogame is supposed to work.. not complex shaders it might not be enough, but to just tweak and fx file, then build and 

run anyh target it is not fussing around.  Ive seen countless extentionsions and workarounds and they might be outdated... So I thought Id contribute this.


it basically ths tutorial https://gmjosack.github.io/posts/my-first-2d-pixel-shaders-part-1/ but with code u can run anything with no repeat or special mods.

you might need netcore 3.1 for the content builder to work im not sure...


