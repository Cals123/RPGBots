- HELP! #F.DroneSpeed.3.2 #F.DroneName.Charles
* What?
* Eh?!
* No thanks, bro. -> END
- I HAVE LEAKY FLUIDS, PLEASE OPEN THE DOOR. #E.ShowGreenDoor
* Why can't you do that? -> help
* Nah, bro, that's nasty. -> END

== help ==
- I HAVE NO HANDS. PLEASE USE THE PANEL IN THE BACKROOM #E.ShowHiddenDoor
* Okay. -> ending

== ending ==
#E.HideGreenDoor
#E.HideHiddenDoor
#E.OpenHiddenDoor
#Q.InspectThePanel
-> END