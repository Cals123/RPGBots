INCLUDE ControlPanel.ink

I've been waiting forever, I'm glad you're finally here.
*   What? Why are you waiting for me?
    - I need you to open that door for me. #E.ShowGreenDoor
    * I'll try, but i'm not sure what to do. -> instructions #E.HideGreenDoor
    * I don't think I want to do that right now.
    -  Ahh okay, bye then, thanks for nothing.. -> END

== instructions ==
-Go to the panel, it's in the back room. #E.ShowHiddenDoor
    * Why can't you do that?
    -  Got no hands.. #E.OpenHiddenDoor
      * * Okay, I'm on it! #E.HideHiddenDoor
        -  Thanks!  -> END 

- ->END