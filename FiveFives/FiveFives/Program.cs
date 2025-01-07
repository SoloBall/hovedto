// jeg har lavet noget uoptimeret kode som nok ikke kan blive færdigt, men over en lang periode skal det nok virke

Console.WriteLine("me starté");
List<string> words = new();
List<List<string>> sortedWords = new();
for (int i = 0; i < 6; i++)
{
    sortedWords.Add(new());
}
StreamReader reader = new("C:\\Users\\HFGF\\source\\repos\\SoloBall\\hovedto\\FiveFives\\FiveFives\\Resources\\words.txt"); // ugly... change
int count = 0;
while (true)
{
    string currentLine = reader.ReadLine() ?? "bingusBoingus";      //wtf ---> change
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
Console.WriteLine("filtering anagrams :( \n and naturally also separating the wrongs from the rights");
foreach (string line in words)          // crazy --->   change... maybe add all characters
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
List<List<string>> result = new();
Console.WriteLine("will never go beyond this point :))");           // fix
for (int first = 0; first < words.Count; first++)
{
    for (int second = 0; second < words.Count; second++)
    {
        if ((words[first] + words[second]).Distinct().Count() == 10)
        {
            for (int third = 0; third < words.Count; third++)
            {
                if ((words[first] + words[second] + words[third]).Distinct().Count() == 15)
                {
                    for (int fourth = 0; fourth < words.Count; fourth++)
                    {
                        if ((words[first] + words[second] + words[third] + words[fourth]).Distinct().Count() == 20)
                        {
                            for (int fifth = 0; fifth < words.Count; fifth++)
                            {
                                if ((words[first] + words[second] + words[third] + words[fourth] + words[fifth]).Distinct().Count() == 25)
                                {
                                    result.Add(new List<string> { words[first], words[second], words[third], words[fourth], words[fifth] });
                                }
                            }
                        }
                    }
                }
            }
        }
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
// mix top and bottom methods into one
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
static bool HasAnagram(string line, List<string> words)         // awful ---> change
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