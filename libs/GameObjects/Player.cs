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
        if (gameObject.Type == GameObjectType.Obstacle) {
            this.PosX = this.GetPrevPosX();
            this.PosY = this.GetPrevPosY();
        }
        else if (gameObject.Type == GameObjectType.Box) {
            bool moved = false;
            int posX = this.PosX + (this.PosX - this.GetPrevPosX());
            int posY = this.PosY + (this.PosY - this.GetPrevPosY());
            // CHECK IF ALL BOXES BEFORE THE PLAYER CAN BE MOVED
            while (!(map[posY, posX] is Obstacle)) {
                if (map[posY, posX] is Floor || map[posY, posX] is Target) {
                    // MOVE ALL BOXES BEFORE THE PLAYER
                    while (posX != gameObject.PosX || posY != gameObject.PosY) {
                        if (map[posY, posX] is Box) {
                            map[posY, posX].Move(this.PosX - this.GetPrevPosX(), this.PosY - this.GetPrevPosY());
                            break;
                        }
                        posX += -1 * (this.PosX - this.GetPrevPosX());
                        posY += -1 * (this.PosY - this.GetPrevPosY());
                    }
                    gameObject.Move(this.PosX - this.GetPrevPosX(), this.PosY - this.GetPrevPosY());
                    moved = true;
                    break;
                }
                posX += (this.PosX - this.GetPrevPosX());
                posY += (this.PosY - this.GetPrevPosY());
            }
            // AVOID PLAYER MOVEMENT IF BOXES CANNOT BE MOVED
            if (!moved) {
                this.PosX = this.GetPrevPosX();
                this.PosY = this.GetPrevPosY();
            }
        }
    }
}