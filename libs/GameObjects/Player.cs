namespace libs;

public class Player : GameObject {

    public Player () : base(){
        Type = GameObjectType.Player;
        CharRepresentation = '☻';
        Color = ConsoleColor.DarkYellow;
    }

    public override void onCollision(GameObject gameObject) {
        if (gameObject.Type == GameObjectType.Obstacle) {
            Console.WriteLine("You hit an obstacle!");
        }
    }
}