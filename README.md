Most of the shaders were collected from various samples years old. But none of the projects built in both Gl and DX and worked without tons of extra complexity..  the onces manually put in the shared do build and at least invert works  some may need the #ifdefs and right shader models added.  

Androind builds but not tested since emulator is broken on win11 still.   


this was made after over a week of hunting old samples and bringing them up to date w latest .net 6 standard and content stuff..

dont used the content editor for the linked Content.Mgcb it will put a Target in the file.    just edit as a text file.


This is how monogame is supposed to work.. not complex shaders it might not be enough, but to just tweak and fx file, then build and 

run anyh target it is not fussing around.  Ive seen countless extentionsions and workarounds and they might be outdated... So I thought Id contribute this.


it basically ths tutorial https://gmjosack.github.io/posts/my-first-2d-pixel-shaders-part-1/ but with code u can run anything with no repeat or special mods.

you might need netcore 3.1 for the content builder to work im not sure...


