namespace libs;

    // Base Component that defines operations that can be altered by decorators.
    public interface IGameObject
    {
        // IGameObject ManufactureGameObject();
        void onCollision(GameObject gameObject, GameObject?[,] map);
    }