# CarromProject

A simple Unity 2D carrom Game.


Striker: On Touch, a different object is dragged and A vector value is recorded (in the direction of the other object) and then a vector in the opposite direction is recorded and a force is applied in that direction making a pull and release effect. localScale is also used to increase or decrease the object in accordance to how far the other object is from the striker.

Ai Striker: The AI striker iterates through a list of pucks that it has to put in the hole. With a little bit of delay, the striker applies a force towards the direction of the puck in the current iteration. 

Scoring System:  A circle collider is put inside the holes (smaller than the hole as the possibility of a puck skimming by the edges of a hole in real life). On collision the pucks are moved to a transform outside of the main camera view. If white pucks go inside the hole, the Score for white increases. If black pucks go inside the hole, black score increases. If Queen Puck goes into the hole, points are increased depending on whose turn it was (With the use of booleans).
