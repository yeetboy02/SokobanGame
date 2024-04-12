using libs;

class Program
{    
    static void Main(string[] args)
    {
        //Setup
        Console.CursorVisible = false;
        var engine = GameEngine.Instance;
        var inputHandler = InputHandler.Instance;
        
        engine.Setup();

        // Main game loop
        while (true)
        {
            engine.Render();

            // Handle keyboard input
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            inputHandler.Handle(keyInfo);
        }
    }
}