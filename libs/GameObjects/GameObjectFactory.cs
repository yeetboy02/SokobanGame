namespace libs;

public class GameObjectFactory : IGameObjectFactory
{
    public GameObject CreateGameObject(dynamic obj) {

        GameObject newObj = new GameObject();
        int type = obj.Type;

        switch (type)
        {
            case (int) GameObjectType.Player:
                newObj = Player.Instance;
                newObj.PosX = obj.PosX;
                newObj.PosY = obj.PosY;
                newObj.Color = obj.Color;
                break;
            case (int) GameObjectType.Obstacle:
                newObj = obj.ToObject<Obstacle>();
                break;
            case (int) GameObjectType.Box:
                newObj = obj.ToObject<Box>();
                break;
            case (int) GameObjectType.Target:
                newObj = obj.ToObject<Target>();
                break;
        }

        return newObj;
    }
}