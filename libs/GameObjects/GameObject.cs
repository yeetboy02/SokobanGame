namespace libs;

public class GameObject : IGameObject, IMovement
{
    private char _charRepresentation = '#';
    private ConsoleColor _color;

    private int _posX;
    private int _posY;
    
    private int _prevPosX;
    private int _prevPosY;

    public Dialog currDialog = null;

    public GameObjectType Type;

    public void createDialog() {
        DialogOption option2 = new DialogOption("TestDialog 2", null);
        Answer[] answers = new Answer[2]{new Answer("Schnitzel", option2), new Answer("Spinatgelee", option2)};
        DialogOption option1 = new DialogOption("TestDialog 1", answers);
        this.currDialog = new Dialog(option1);
        Task dialog = Task.Run(() => {
            this.currDialog.Run();
        });
        dialog.Wait();
        this.currDialog = null;
    }

    public GameObject() {
        this._posX = 5;
        this._posY = 5;
        this._color = ConsoleColor.Gray;
    }

    public GameObject(int posX, int posY){
        this._posX = posX;
        this._posY = posY;
    }

    public GameObject(int posX, int posY, ConsoleColor color){
        this._posX = posX;
        this._posY = posY;
        this._color = color;
    }

    public char CharRepresentation
    {
        get { return _charRepresentation ; }
        set { _charRepresentation = value; }
    }

    public ConsoleColor Color
    {
        get { return _color; }
        set { _color = value; }
    }

    public int PosX
    {
        get { return _posX; }
        set { _posX = value; }
    }

    public int PosY
    {
        get { return _posY; }
        set { _posY = value; }
    }

    public int GetPrevPosY() {
        return _prevPosY;
    }
    
    public int GetPrevPosX() {
        return _prevPosX;
    }

    public void Move(int dx, int dy) {
        if (currDialog == null) {
            _prevPosX = _posX;
            _prevPosY = _posY;
            _posX += dx;
            _posY += dy;
        }
    }

    virtual public void onCollision(GameObject obj, GameObject?[,] map) {

    }
}
