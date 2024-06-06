using libs;

using System.Security.Cryptography;
using Newtonsoft.Json;

class Program
{    
    static private int currLevel = 0;
    static private bool wasMainMenuDisplayed = false;
    static void Main(string[] args)
    {
        // Display the main menu
        if(!wasMainMenuDisplayed){
            MainMenu();

        }

        StartGame();

    }

    static void StartGame(){
        //Setup
        Console.CursorVisible = false;
        var engine = GameEngine.Instance;
        var inputHandler = InputHandler.Instance;
        
        engine.Setup(currLevel);
        currLevel = engine.GetCurrentLevel();

        // Main game loop
        while (true)
        {
            engine.Render();

            // CHECK WIN CONDITION
            if (engine.allTargetsFilled()) {
                nextLevel(engine);
                break;
            }

            // Check for restart key press
            if (engine.GetRestartGame()) {
                restartGame(engine);
                break;
            }
            
            // Handle keyboard input
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            inputHandler.Handle(keyInfo);
            engine.Update();
        }
    }

    static private void MainMenu()
    {
        Console.Clear();
        Console.WriteLine("Welcome to the Console Game!");
        Console.WriteLine("Press Enter to start the game...");
        while (Console.ReadKey(true).Key != ConsoleKey.Enter)
        {
            // Wait for the Enter key to be pressed
        }
        Console.Clear();
        wasMainMenuDisplayed = true;
    }
    static private void nextLevel(GameEngine engine) {
        // remove map history once level completed
        engine.removeHistory();

        // end level or increse current level and set it in game engine
        if (currLevel == 2) endGame();
        currLevel++;
        engine.SetCurrentLevel(currLevel);

        Console.Clear();
        Main(null);
    }

    static private void endGame() {
        // overwrite saved JSON game state 
        var gameState = new GameState { currentLevel = null, gameObjects =  new List<GameObject>() };
        string output = JsonConvert.SerializeObject(gameState);
        File.WriteAllText("../SavedFile.json", output);

        Console.Clear();
        Console.WriteLine("Congratulations! You have completed the game!");
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
        Environment.Exit(0);
    }


    static private void restartGame(GameEngine engine) {
        // overwrite saved JSON game state
        var gameState = new GameState { currentLevel = null, gameObjects =  new List<GameObject>() };
        string output = JsonConvert.SerializeObject(gameState);
        File.WriteAllText("../SavedFile.json", output);

        // remove map history, set level to 0, set flag to false
        engine.removeHistory();
        currLevel = 0;
        engine.SetCurrentLevel(currLevel);
        engine.SetRestartGame(false);

        wasMainMenuDisplayed = false;
        Console.Clear();
        Main(null);
    }
}