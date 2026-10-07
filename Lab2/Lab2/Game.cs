using System;
using System.IO;
public class Game
{
    public static string InputFile = "1.ChaseData.txt";
    public static string OutFile = "1.Pursuit.txt";

    public int size;
    public Player cat;
    public Player mouse;
    public Player dog;
    public GameState state;
    public StringWriter buffer;

    public Game() {

        cat=new Player("Cat");
        dog = new Player("Dog");
        mouse = new Player("Mouse");
        state =  GameState.START;
        buffer = new StringWriter();
    }

    public void Run()
    {
        if (!File.Exists(InputFile))
        {
            Console.WriteLine($"Файл {InputFile} не найден.");
            return;
        }

        string[] lines = File.ReadAllLines(InputFile);
        if (lines.Length == 0) return;

        if (int.TryParse(lines[0].Trim(), out int parsedSize))
        {
            size = parsedSize;
        }
        buffer.WriteLine("Cat and Mouse");
        buffer.WriteLine();
        buffer.WriteLine("Cat\tMouse\tDog\tDistance");
        buffer.WriteLine("---------------------------------");


        for (int i = 1; i < lines.Length; i++) {

            if (state == GameState.END) break;
            string line = lines[i].Trim();
            if (string.IsNullOrEmpty(line)) continue;
            string[] parts = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            char command = parts[0][0];

            if (command == 'P')
            {
                PrintCommand();
            }
            else if (command == 'M' || command == 'C' || command == 'D')
            {
                if (parts.Length > 1 && int.TryParse(parts[1], out int steps))
                {
                    MoveCommand(command, steps);
                }
            }
        }

        

        buffer.WriteLine("---------------------------------");
        buffer.WriteLine();
        buffer.WriteLine();
        buffer.WriteLine("Distance traveled:");
        buffer.WriteLine($"Dog\t{dog.distance}");
        buffer.WriteLine($"Mouse\t{mouse.distance}");
        buffer.WriteLine($"Cat\t{cat.distance}");
        buffer.WriteLine();


        if(dog.state== State.Winner)
        {
            buffer.WriteLine($"Собака поймала кота на: {cat.location}");
        }
        else if (cat.state == State.Winner)
                {
                    buffer.WriteLine($"Мышь поймана на: {mouse.location}");
                }
                else
                {
                    buffer.WriteLine("Мышь убежала от кота и кот убежал от собаки");
                }
        File.WriteAllText(OutFile, buffer.ToString());
        Console.WriteLine(buffer.ToString());

    }

    public void MoveCommand(char command, int steps)
    {
        switch (command)
        {
            case 'M':
                {
                    mouse.Move(steps, size);
                    break;
                }
            case 'C':
                {
                    cat.Move(steps, size);
                    break;
                }
            case 'D':
                {
                    dog.Move(steps, size);
                    break;
                }
        }
                
                if(cat.state==State.Playing && mouse.state==State.Playing && cat.location==mouse.location) {
                    cat.state = State.Winner;
                    mouse.state = State.Looser;
                    dog.state = State.Looser;
                    state = GameState.END;
                }
                else if(cat.state==State.Playing && dog.state==State.Playing && dog.location == cat.location)
        {
                    cat.state = State.Looser;
                    mouse.state = State.Winner;
                    dog.state= State.Winner;
                    state = GameState.END;
        }


        }

    public void PrintCommand()
    {
        string dogLoc = dog.state == State.NotInGame ? "??" : dog.location.ToString();
        string catLoc = cat.state == State.NotInGame ? "??" : cat.location.ToString();
        string mouseLoc = mouse.state == State.NotInGame ? "??" : mouse.location.ToString();
        string distance = GetDistance();

        buffer.WriteLine($"{catLoc}\t{mouseLoc}\t{dogLoc}\t{distance}");
    }

    public string GetDistance()
    {
        if (cat.state == State.NotInGame || mouse.state == State.NotInGame )
        {
            return "??";
        }
        return Math.Abs(cat.location - mouse.location).ToString();
    }
}

    

