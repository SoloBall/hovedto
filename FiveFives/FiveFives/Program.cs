// jeg har lavet noget uoptimeret kode som nok ikke kan blive færdigt, men over en lang periode skal det nok virke

// to make recursive -> just use all required variables as arguments, the recursive part is when a new, working word has been found, whereas all of the previous
// variables get used as arguments again to find the next word

Console.WriteLine("me starté");
List<List<string>> sortedWords = new();
for (int i = 0; i < 6; i++)
{
    sortedWords.Add(new());
}
StreamReader reader = new("C:\\Users\\HFGF\\source\\repos\\SoloBall\\hovedto\\FiveFives\\FiveFives\\Resources\\words.txt"); // ugly... change
int count = 0;
Dictionary<string, string> words = new();
while (true)
{
    string currentLine = reader.ReadLine() ?? "bingusBoingus";      // wtf ---> change
    if (currentLine != "bingusBoingus")
    {
        if (currentLine.Length == 5 && !HasMoreOfAKind(currentLine))
        {
            if (!words.ContainsKey(string.Concat(currentLine.OrderBy(x => x))))
            {
                words.Add(string.Concat(currentLine.OrderBy(x => x)), currentLine); // EW.
            }
        }
    }
    else
    {
        break;
    }
}

void MatchWords(string currentWord, int wordsMatched, int index, List<string> usedWords) // Kunne være bedere!
{
    if (wordsMatched == 5)
    {
        Console.WriteLine(string.Join(" ", usedWords));
        return;
    }
    if (string.Concat(usedWords, currentWord).Distinct().Count() == (wordsMatched + 1) * 5)
    {
        Console.WriteLine("Penus kh. Philip!");
    }
}
/*
Console.WriteLine("will never go beyond this point :))");           // fix
for (int first = 0; first < words.Count; first++)       // make recursive
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
*/
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
        List<char> wordChars = new();                   // Fuck jeg er bange for bananer.
        foreach (char c in word)
        {
            wordChars.Add(c);
        }
        wordChars.Sort();
        foreach (char c in wordChars)
        {
            sortedWord += c;
        }
        if (sortedWord == line)                         // Certified brownie lover <3 <3 <3 <3
        {
            return true;
        }
    }
    return false;    
}
Console.WriteLine("done!!!!!😃😃😃😃😃");
Console.WriteLine("Penus kh. Philip!");
Console.WriteLine("All that works, is made by Philip. Everything that don't is akmandas.");