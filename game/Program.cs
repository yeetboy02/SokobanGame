using libs;

using System.Security.Cryptography;
using Newtonsoft.Json;

class Program
{    
    static private int currLevel = 0;
    static void Main(string[] args)
    {
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

    static private void nextLevel(GameEngine engine) {
        engine.removeHistory();

        if (currLevel == 2) endGame();
        currLevel++;
        engine.SetCurrentLevel(currLevel);

        Console.Clear();
        Main(null);
    }

    static private void endGame() {
        var gameState = new GameState
        {
            currentLevel = null,
            gameObjects =  new List<GameObject>()
        };

        string output = JsonConvert.SerializeObject(gameState);
        File.WriteAllText("../SavedFile.json", output);

        Console.Clear();
        Console.WriteLine("Congratulations! You have completed the game!");
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
        Environment.Exit(0);
    }


    static private void restartGame(GameEngine engine) {
        var gameState = new GameState
        {
            currentLevel = null,
            gameObjects =  new List<GameObject>()
        };
        string output = JsonConvert.SerializeObject(gameState);
        File.WriteAllText("../SavedFile.json", output);

        engine.removeHistory();
        currLevel = 0;
        engine.SetCurrentLevel(currLevel);
        engine.SetRestartGame(false);

        Console.Clear();
        Main(null);
    }
}