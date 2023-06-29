using PigLibrary.Game;


bool playAgain;

do
{
    int playerCount = UIMessages.GetPlayerCount(); // Gets the player count

    Gameplay pigGamee = new Gameplay(playerCount); // Instantiates game with the player count

    pigGamee.StartGame(); // Starts the game 

    playAgain = UIMessages.ReplayPrompt(); // Prompts a game restart

} while (playAgain == true);




Console.ReadLine();

