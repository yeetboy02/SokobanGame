namespace libs;

public class Floor : GameObject {

    public Floor () : base(){
        Type = GameObjectType.Floor;
        CharRepresentation = '.';
    }

    override public void onCollision(GameObject gameObject) {
        // Do nothing
    }
}