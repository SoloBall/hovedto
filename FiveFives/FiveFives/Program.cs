List<string> words = new();
List<List<string>> sortedWords = new();
for (int i = 0; i < 6; i++)
{
    sortedWords.Add(new());
}
StreamReader reader = new("C:\\Users\\HFGF\\source\\repos\\SoloBall\\hovedto\\FiveFives\\FiveFives\\Resources\\words.txt");
int count = 0;
while (true)
{
    string currentLine = reader.ReadLine() ?? "bingusBoingus";
    if (currentLine != "bingusBoingus")
    {
        if (currentLine.Length == 5 && !HasMoreThanOneVocal(currentLine) && !HasMoreOfAKind(currentLine))
        {
            words.Add(currentLine);
        }
    }
    else
    {
        break;
    }
}
foreach (string line in words)
{
    count++;
    if (count % 100 == 0)
    {
        Console.Write(".");
    }
    if (line.Contains("a"))
    {
        if (HasAnagram(line, sortedWords[0]))
        {
            continue;
        }
        sortedWords[0].Add(line);
    }
    if (line.Contains("e"))
    {
        if (HasAnagram(line, sortedWords[1]))
        {
            continue;
        }
        sortedWords[1].Add(line);
    }
    if (line.Contains("i"))
    {
        if (HasAnagram(line, sortedWords[2]))
        {
            continue;
        }
        sortedWords[2].Add(line);
    }
    if (line.Contains("o"))
    {
        if (HasAnagram(line, sortedWords[3]))
        {
            continue;
        }
        sortedWords[3].Add(line);
    }
    if (line.Contains("u"))
    {
        if (HasAnagram(line, sortedWords[4]))
        {
            continue;
        }
        sortedWords[4].Add(line);
    }
    if (line.Contains("y"))
    {
        if (HasAnagram(line, sortedWords[5]))
        {
            continue;
        }
        sortedWords[5].Add(line);
    }
}
for (int first = 0; first < words.Count; first++)
{
    for (int second = 0; second < words.Count; second++)
    {
        if (words[first])
    }
}

static bool HasMoreThanOneVocal(string line)
{
    int vocals = 0;
    foreach (char c in line)
    {
        if (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u' || c == 'y')
        {
            vocals++;
        }
    }
    return vocals > 3;
}
static bool HasMoreOfAKind(string line)
{
    string usedCharacters = "";
    foreach (char c in line)
    {
        if (usedCharacters.Contains(c))
        {
            return true;
        }
        usedCharacters += c;

    }
    return false;
}
static bool HasAnagram(string line, List<string> words)
{
    string sortedWord = "";
    List<char> lineChars = new();
    foreach (char c in line)
    {
        lineChars.Add(c);
    }
    lineChars.Sort();
    line = "";
    foreach (char c in lineChars)
    {
        line += c;
    }

    foreach (string word in words)
    {
        List<char> wordChars = new();
        foreach (char c in word)
        {
            wordChars.Add(c);
        }
        wordChars.Sort();
        foreach (char c in wordChars)
        {
            sortedWord += c;
        }
        if (sortedWord == line)
        {
            return true;
        }
    }
    return false;    
}
Console.WriteLine("done!!!!!😃😃😃😃😃");