namespace libs;

public class Player : GameObject {

    public Player () : base(){
        Type = GameObjectType.Player;
        CharRepresentation = '☻';
        Color = ConsoleColor.DarkYellow;
    }
}