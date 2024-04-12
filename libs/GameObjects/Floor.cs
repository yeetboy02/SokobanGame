namespace libs;

public class Floor : GameObject {

    public Floor () : base(){
        Type = GameObjectType.Floor;
        CharRepresentation = '.';
    }
}