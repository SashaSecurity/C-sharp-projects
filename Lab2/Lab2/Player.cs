public class Player
{
    public string name;
    public int location;
    public State state;
    public int distance;

    public Player(string name)
    {
        this.name = name;
        this.location = -1;
        this.state = State.NotInGame;
        this.distance = 0;


    }

    public void Move(int steps, int fieldSize)
    {
        if (fieldSize <= 0) return;

        if (state == State.NotInGame)
        {
            
            int position = (steps - 1) % fieldSize;
            if (position < 0)
            {
                position += fieldSize;
            }
            location = position + 1;
            state = State.Playing;
        }
        else if (state == State.Playing)
        {
            int steps_2 = (location - 1 + steps) % fieldSize;
            if (steps_2 < 0)
            {
                steps_2 += fieldSize;
            }
            location = steps_2 + 1;
            distance += Math.Abs(steps);
        }
    }
}