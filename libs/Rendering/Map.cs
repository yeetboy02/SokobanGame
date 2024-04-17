namespace libs;
using Newtonsoft.Json;

public class Map {
    private char[,] RepresentationalLayer;
    private GameObject?[,] GameObjectLayer;

    public List<GameObject?[,]> history = new List<GameObject?[,]>();

    public bool resetHistory = false;

    private int _mapWidth;
    private int _mapHeight;

    public Map () {
        _mapWidth = 30;
        _mapHeight = 8;
        RepresentationalLayer = new char[_mapHeight, _mapWidth];
        GameObjectLayer = new GameObject[_mapHeight, _mapWidth];
    }

    public Map (int width, int height) {
        _mapWidth = width;
        _mapHeight = height;
        RepresentationalLayer = new char[_mapHeight, _mapWidth];
        GameObjectLayer = new GameObject[_mapHeight, _mapWidth];
    }

    public GameObject?[,] GetMap(){
        return GameObjectLayer;
    }

    public void Initialize()
    {

            GameObjectLayer = new GameObject[_mapHeight, _mapWidth];
            // Initialize the map with some default values
            for (int i = 0; i < GameObjectLayer.GetLength(0); i++)
            {
                for (int j = 0; j < GameObjectLayer.GetLength(1); j++)
                {
                    GameObjectLayer[i, j] = new Floor();
                }
            }
        RepresentationalLayer = new char[_mapHeight, _mapWidth];
    }

    public int MapWidth
    {
        get { return _mapWidth; } // Getter
        set { _mapWidth = value; Initialize();} // Setter
    }

    public int MapHeight
    {
        get { return _mapHeight; } // Getter
        set { _mapHeight = value; Initialize();} // Setter
    }

    public GameObject Get(int x, int y){
        return GameObjectLayer[x, y];
    }

    public void SaveToHistory() {
        if (resetHistory) {
            resetHistory = false;
        }
        else if (history.Count == 0 || (history[history.Count - 1] != GameObjectLayer)) {
            history.Add(GameObjectLayer.Clone() as GameObject?[,]);
        }
    }

    public void revertHistory() {
        if (history.Count > 1) {
            history.RemoveAt(history.Count - 1);
            GameObjectLayer = history[history.Count - 1];
        };
    }

    public void clearHistory() {
        history = new List<GameObject?[,]>();
    }

    public void Set(ref GameObject gameObject){
        int posY = gameObject.PosY;
        int posX = gameObject.PosX;
        int prevPosY = gameObject.GetPrevPosY();
        int prevPosX = gameObject.GetPrevPosX();
        
        if (prevPosX >= 0 && prevPosX < _mapWidth &&
                prevPosY >= 0 && prevPosY < _mapHeight)
        {
            if (GameObjectLayer[prevPosY, prevPosX] is Floor) {
                GameObjectLayer[prevPosY, prevPosX] = new Floor();
            }
        }

        if (posX >= 0 && posX < _mapWidth &&
                posY >= 0 && posY < _mapHeight)
        {
            GameObjectLayer[gameObject.PosY, gameObject.PosX] = gameObject;
            RepresentationalLayer[gameObject.PosY, gameObject.PosX] = gameObject.CharRepresentation;
        }
    }
}