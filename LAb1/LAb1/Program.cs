using System;
using System.Text;

struct MainData{
    public string protein;
    public string organism;
    public string aminoAcid;

}

class Program
{


    static void main(string[] args)
    {
        string sequenceFile = "sequences.1.txt";
        string commandFile = "command.1.txt";
        string outputFile = "gendata.1.txt";
        List<MainData> geneticDataList = LoadMainData(sequenceFile);

        if (geneticDataList.Count == 0)
        {
            Console.WriteLine($"Файл {sequenceFile} не найден или пуст.");
            return;
        }

        if (!File.Exists(commandFile))
        {
            Console.WriteLine($"Файл команд {commandFile} не найден.");
            return;
        }
        

        Console.WriteLine($"Обработка завершена. Результаты сохранены в {outputFile}");
    }
    static string Decoding(string amino_acids)
    {
        if (string.IsNullOrEmpty(amino_acids)) return amino_acids;

        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < amino_acids.Length; i++)
        {
            char c = amino_acids[i];
           
            if (char.IsDigit(c))
            {
                int count = c - '0';
                if (i + 1 < amino_acids.Length)
                {
                    char nextChar = amino_acids[i + 1];
                    sb.Append(nextChar, count);
                    i++; 
                }
            }
            else
            {
                sb.Append(c);
            }
        }
        return sb.ToString();
    }

    static List<MainData> LoadMainData(string filePath)
    {
        List<MainData> list = new List<MainData>();
        if (!File.Exists(filePath)) return list;

        string[] lines = File.ReadAllLines(filePath);
        foreach (string line in lines)
        {
            if (string.IsNullOrWhiteSpace(line)) continue;

            string[] parts = line.Split('\t');
            if (parts.Length >= 3)
            {
                MainData data = new MainData
                {
                    protein = parts[0].Trim(),
                    organism = parts[1].Trim(),
                    // Декодируем RLE при загрузке данных
                    aminoAcid = Decoding(parts[2].Trim())
                };
                list.Add(data);
            }
        }
        return list;
    }
}
        

