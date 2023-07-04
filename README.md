# BloonsTD6Inspector
For my tool development C# assignment we were tasked to make a WPF application that displayed data of a chosen API. The main focusses of this assignment where:
- Use [MVVM](https://www.nuget.org/packages/CommunityToolkit.Mvvm)
- Use meaningful inheritance and interfaces 
- Have a master (overview) and detail page
- There are multiple ways to access the data (Through API calls or local files)
- sourcecontrol is used as it should be (regular commits with meaningful commit messages)

For the git commit messages I am currently using the [following guide](https://www.freecodecamp.org/news/how-to-write-better-git-commit-messages/) as convention.
    
## API
I chose the [STATSNITE Bloons TD6 API](https://statsnite.com/btd/api). I focused on the towers since those are the most common elements in the game.
Each tower falls under a certain category. You have primary, military, magic and support. Each tower has unique stats and 3 seperate build paths.
These paths change the visuals of the tower, both the icon and in game model.

## DAE / GD profile
Games like Bloons TD6 have a very committed community. Because of the nature of the game, the one that rewards micro optimisation, statistics and testing, players that want to reach the highest level of play will want to see the exact values the game uses. Often those values are hidden in the game from the player which makes tools to display these incredibly useful and wanted. Hence, I thought this is an excellent excercise and chose an API of a game that has a playerbase with this desire.

## Swapping repository
By default, the application will use the API repository. If you want to change the default repository you can do that in `OverviewPageVM.cs` in the constructor of the class. Assigning a different class that implements the `IRepos` interface to the `Repository` property.
It is possible to change between API repository and local repository when the application is already booted up, the button to do this is at the bottom of the application.
