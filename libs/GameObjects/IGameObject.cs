namespace libs;

    // Base Component that defines operations that can be altered by decorators.
    public interface IGameObject
    {
        // IGameObject ManufactureGameObject();
        void onCollision(ref GameObject gameObject);
    }