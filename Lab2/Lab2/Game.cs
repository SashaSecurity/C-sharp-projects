public class Game
{
    public int size;
    public Player cat;
    public Player mouse;
    public GameState state;

    public Game(int size) {
        this.size = size;
        cat=new Player("Cat");
        mouse = new Player("Mouse");
        state = new GameState.Start;
    }

    public void Run()
    {
        while(state!= GameState.END)
        {
            List<>  = LoadData();

            if (geneticDataList.Count == 0)
            {
                Console.WriteLine($"Файл {sequencesFile} не найден или пуст.");
                return;
            }

            if (!File.Exists(commandsFile))
            {
                Console.WriteLine($"Файл команд {commandsFile} не найден.");
                return;
            }
        }
    }
}
