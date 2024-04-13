namespace libs;

public class Box : GameObject {

    public Box () : base(){
        Type = GameObjectType.Player;
        CharRepresentation = '○';
        Color = ConsoleColor.DarkGreen;
    }
}