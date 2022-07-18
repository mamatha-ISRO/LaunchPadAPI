Assumptions:
	Design and place holder of tick tack toe is assumed as below 
	1 2 3
	4 5 6
	7 8 9
	Winning combinations are:
            1, 2, 3 
            4, 5, 6
            7, 8, 9                        
            1, 4, 7 
            2, 5, 8
            3, 6, 9                        
            1, 5, 9 
            3, 5, 7
            
            
	Client side validation- X and O Player are decided at client side, alternate player entry is handled at client side.
How to run in development and production environment 
	Clone GIthub repository to your system, install MsSQL 
	Open solution in Visual Studio, 
              Below libraries are resolved from public nuget    
         Microsoft.EntityFrameworkCore
         Microsoft.EntityFrameworkCore.Design
         Microsoft.EntityFrameworkCore.SqlServer
        # to install dotnet entity framework
	dotnet tool install --global dotnet-ef

	# to generate initial migration files
	dotnet ef migrations add CreateInitial
	# to create tables in sql server database
	dotnet ef database update         
*update the database connection to  -"Server=localhost;Database=TicTacToe;Trusted_Connection=True;"( I have used MSSQL community version) in appsettings .jason then 
 	 *Build the solution file in visual studio
           	  *and run the webAPI 
 How to run in Docker
	docker Support file is added to solution
	Run with docker 
	Image and containers are created 
	it can be seen in container list at Docker Desktop app
	and the image is pushed in my personal docker account(public repository)
Code Description 
	I have used entity framework’s code first approach  
Run in system - postman or swagger 
end point 1 using post verb the game id and two player id are registered with game status , and row is  created in data base table -TicTacToe  
	endpoint 2 using put verb with the player ID and the move is updated 
	endpoint 3 using get verb the game status and the moves register for each player are returned.
         
        Exception handling: for each valid move of the payer, for game draw is verified  

Question: What is the appropriate OAuth 2/OIDC grant to use for a web application using a SPA (Single 
Page Application) and why?
Answer:

OAuth 2.0 is an open standard authorization used for single page application authorization because it can be used for accessing different third party applications from single page.As per the requirement its extension Open ID connect can also be implemented. 

With OAuth, you can log into third party websites without having the necessity to provide your passwords. This way you can avoid creating accounts and remembering passwords on each and every web application that you use on the Internet.
OAuth is based on an access token concept. When you authenticate yourself using let’s say your Google account, to a third party web application. Google authorization server issues an access token to that web application with the approval of the owner. Thus, the web application can use that access token to access your data hosted in the resource server.  Hence, OAuth is a simple way to publish and interact with protected resource data. It’s also a safer and more secure way for people to give you access to their resource data.


