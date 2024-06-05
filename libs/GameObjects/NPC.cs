namespace libs;

public class NPC : GameObject {
    public NPC () : base() {
        Type = GameObjectType.NPC;
        CharRepresentation = 'ඞ';
        Color = ConsoleColor.Red;
    }
}