namespace Taboo.Data;

public class WordGeneration
{
    public string wordToGuess;
    public string[] words;
    private string csv = "data/words_data.csv";
    private Random random = new();
    
    public void NextWord()
    {
        using var reader = new StreamReader(csv);
        int numberOfLines = NumberOfLines(reader);
        int lineNumber = random.Next(0, numberOfLines);
        for (int i = 0; i < lineNumber; i++)
        {
            reader.ReadLine();
        }
        string line = reader.ReadLine();
        string[] values = line.Split(',');
        ToPascalCase(values);
        wordToGuess = values[0];
        words = values.Skip(1).ToArray();
    }

    private int NumberOfLines(StreamReader reader)
    {
        var lineCount = 0;
        while (reader.ReadLine() != null)
        {
            lineCount++;
        }
        reader.BaseStream.Seek(0, SeekOrigin.Begin);
        return lineCount;
    }

    private void ToPascalCase(string[] values)
    {
        for (int i = 0; i < values.Length; i++)
        {
            char firstLetter = char.ToUpper(values[i][0]);
            values[i] = firstLetter + values[i][1..];
        }
    }
}