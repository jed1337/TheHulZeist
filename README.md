###Game Design Document  	
https://docs.google.com/document/d/1eKr6nUUIoVuXqGCYKZ1zLZIJqzwPFcsfhedado_33sc/edit

###Unity notes:  
https://docs.google.com/document/d/1Ao9UhQioaY14J-6KhoiFjg_dBrLWD4Wctiub9AjgkuE/edit

###Trello board:  
https://trello.com/c/b2p2Z8IA/11-the-gentlemen-caychingco-merle-monzon

###Spritesheet specifics  
######Kromme  
* Run 164x155
* Idle 95x155

###Issues:  
* Placeholder art (Currently solving)
* Game balance
	* Speed, jump height, etc.
	* Enemy things
* Code Quality
	* Possible Coupling between player scripts (I feel this is the case)
		* PlayerAttack.cs
		* PlayerController.cs
		* PlayerAnimationController.cs
* Bugs
	* Enemies get a null reference error when player gets destroyed (It's null)