namespace libs;

public class Box : GameObject {

    public Box () : base(){
        Type = GameObjectType.Player;
        CharRepresentation = '○';
        Color = ConsoleColor.DarkGreen;
    }

    public override void onCollision(GameObject gameObject) {
        if (gameObject.Type == GameObjectType.Obstacle) {
            Console.WriteLine("You hit a Box!");
        }
    }
}