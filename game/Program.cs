using libs;

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

        // Main game loop
        while (true)
        {
            engine.Render();

            // CHECK WIN CONDITION
            if (engine.allTargetsFilled()) {
                endGame();
                break;
            }

            // Handle keyboard input
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            inputHandler.Handle(keyInfo);
            engine.Update();
        }
    }

    static private void endGame() {
        currLevel++;
        Console.Clear();
        Main(null);
    }
}