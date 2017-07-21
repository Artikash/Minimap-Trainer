# Starcraft 2 Minimap Trainer
Program to train minimap awareness in Starcraft 2 (and other games)  

How it works:  
If you entered your settings into the config file enter "yes" without quotes to "Use preset settings?"  
Enter the coordinates of the top left and bottom right of your minimap, then the minimum and maximum times between appearances, then the RGB color you want the dot on your minimap to be.  
A dot will then appear near the middle of your screen, please click near it.  
After a random amount of time (specified earlier) the dot will appear on your minimap. Double click near it as soon as you notice it.  
This will cause the dot to dissapear, and after another random time period it will reappear on your minimap. Double click near the dot as soon as you notice it. Repeat.  
You can see how long you took to recognize the dot was there and click by looking at the console window afterwards.  

Notes:  
Only works on windowed mode.  
I didn't add any error handling. If you input something you're not supposed to (e.g. minimum time is greater than maximum time), the program will probably crash or behave strangely.

