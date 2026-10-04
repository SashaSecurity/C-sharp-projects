class Player
{
    public string name;
    public int location;
    public State state = State.NotIngame;
    public int distance;

    public Player(string name)
    {
        this.name = name;
        this.location = -1;
       
    }

    public void Move(int steps)
    {

    }
}