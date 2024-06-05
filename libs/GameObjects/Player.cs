namespace libs;

public sealed class Player : GameObject {
    private static Player _instance = null;

    public static Player Instance {
        get{
            if(_instance == null)
            {
                _instance = new Player();
            }
            return _instance;
        }
    }

    private Player () : base(){
        Type = GameObjectType.Player;
        CharRepresentation = '☻';
        Color = ConsoleColor.DarkYellow;
    }

    public override void onCollision(GameObject gameObject, GameObject?[,] map) {
        if (gameObject.Type == GameObjectType.Obstacle || gameObject.Type == GameObjectType.NPC) {
            this.PosX = this.GetPrevPosX();
            this.PosY = this.GetPrevPosY();
        }
        else if (gameObject.Type == GameObjectType.Box) {
            int posX = this.PosX + (this.PosX - this.GetPrevPosX());
            int posY = this.PosY + (this.PosY - this.GetPrevPosY());
            // CHECK IF ALL BOXES BEFORE THE PLAYER CAN BE MOVED
            if (map[posY, posX] is Floor || map[posY, posX] is Target) {
                gameObject.Move(this.PosX - this.GetPrevPosX(), this.PosY - this.GetPrevPosY());
            }
            else {
                // AVOID PLAYER MOVEMENT IF BOXES CANNOT BE MOVED
                this.PosX = this.GetPrevPosX();
                this.PosY = this.GetPrevPosY();
                
            }
        }
    }
}