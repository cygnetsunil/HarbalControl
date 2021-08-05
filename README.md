# Harbal Control


# Projects

1) WEB

1.1) HC.Web - Front End (Angular 11)
	- Including bootstrap for CSS

2) API (.NET 5 Framework)

2.1) HC.API (WEB API)
	
	- This is API project contails API end points

2.2) HC.Library
	
	- This project contains common utility files and common class

2.3) HC.Entitie
	
	- This project contains list of models 

2.4) HC.Core
	
	- This contains list of manager where we can write business logic.

	Interfaces :
		- Interface contains list of method declarations
	
	Manager :
		- This contains implemenations for interface methods.
	
# Steps 
	
1) Step 1: Build and run HC.API Project 
	- It will automatically restore the packages required.

2) Step 2: Pick base url from opened browser (Exclude '/index.html').

3) Step 3: Open HC.Web --> harbal-control --> src --> environments --> environment.ts and paste copied url in baseUrl and replace with existing value.

4) Step 4: Open cmd(Terminal) and run command 'npm install'

5) Step 5: Once done with all the required packages installation run next command 'npm start OR ng serve'

6) Step 6: Open "http://localhost:4200" in browser