namespace libs;

public class Target : GameObject {

    public Target () : base(){
        Type = GameObjectType.Target;
        CharRepresentation = 'X';
        Color = ConsoleColor.Red;
    }
}