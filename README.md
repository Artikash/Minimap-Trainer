# Starcraft 2 Minimap Trainer
Program to train minimap awareness in Starcraft 2 (and other games)  

How it works:  
If you entered your settings into the config file enter "yes" without quotes to "Use preset settings?"  
If you want a custom color for the dot enter "yes" without quotes to "Custom Color?"  

A dot will then appear near the middle of your screen, please click near it.  
After a random amount of time (specified earlier) the dot will appear on your minimap. Click near it as soon as you notice it.  
This will cause the dot to dissapear, and after another random time period it will reappear on your minimap. Click near the dot as soon as you notice it. Repeat. The dot will grow bigger the longer you don't click it.  
You can see exactly how long you took to recognize the dot was there and click by looking at the console window afterwards.  

Notes:  
Any .NET after 4.0 should be all that is required to run this program.  
Only works on windowed and fullscreen window mode.  
I didn't add any error handling. If you input something you're not supposed to (e.g. minimum time is greater than maximum time), the program will probably crash or behave strangely.


