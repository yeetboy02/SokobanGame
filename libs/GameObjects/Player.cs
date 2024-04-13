namespace libs;

public class Player : GameObject {

    public Player () : base(){
        Type = GameObjectType.Player;
        CharRepresentation = '☻';
        Color = ConsoleColor.DarkYellow;
    }

    public override void onCollision(ref GameObject gameObject) {
        if (gameObject.Type == GameObjectType.Obstacle) {
            this.PosX = this.GetPrevPosX();
            this.PosY = this.GetPrevPosY();
        }
    }
}