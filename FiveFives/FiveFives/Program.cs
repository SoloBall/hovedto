// jeg har lavet noget uoptimeret kode som nok ikke kan blive færdigt, men over en lang periode skal det nok virke

// to make recursive -> just use all required variables as arguments, the recursive part is when a new, working word has been found, whereas all of the previous
// variables get used as arguments again to find the next word

// it might be faster to use a list of sorted lines and a list of bit values
using System.Diagnostics;

Console.WriteLine("me starté");
Stopwatch stopwatch = Stopwatch.StartNew();
StreamReader reader = new("C:\\Users\\HFGF\\source\\repos\\SoloBall\\hovedto\\FiveFives\\FiveFives\\Resources\\words_beta.txt"); // ugly... change
Dictionary<string, int> words = new();
while (true)
{
    string currentLine = reader.ReadLine() ?? "bingusBoingus";      // wtf ---> change
    if (currentLine != "bingusBoingus")
    {
        if (currentLine.Length == 5 && !HasMoreOfAKind(currentLine))
        {
            if (!words.ContainsKey(string.Concat(currentLine.OrderBy(x => x))))
            {
                words.Add(string.Concat(currentLine.OrderBy(x => x)), BitValue(currentLine)); // EW.
            }
        }
    }
    else
    {
        break;
    }
}

int[] wordsArray = words.Values.ToArray();
int wordsCount = wordsArray.Length;
int resultCount = 0;
int solutions = 0;
MatchWords(0, 0, new());
stopwatch.Stop();
Console.WriteLine(stopwatch.ToString());

void MatchWords(int word, int index, List<int> usedWords) // Kunne være bedere! mate den virker jo ikke engang
{
    if (usedWords.Count() == 5)
    {
        solutions++;
        foreach (int num in usedWords)
        {
            Console.Write(StringValue(num) + " ");
        }
        Console.WriteLine();
        resultCount++;
        return;
    }

    for (int i = index; i < wordsCount; i++)
    {
        if ((wordsArray[i] & word) == 0)
        {
            List<int> tmpList = new(usedWords);
            tmpList.Add(wordsArray[i]);
            MatchWords(word | wordsArray[i], i + 1, tmpList);
        }
    }
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

int BitValue(string line)
{
    int result = 0;
    foreach (char c in line)
    {
        result |= 1 << (int)(c - 'a');
    }
    return result;
}
string StringValue(int bitArray)
{
    // List to store characters in the original order
    List<char> characters = new List<char>();

    // Iterate through the 32 bits (as we're using an int, it has 32 bits)
    for (int i = 0; i < 32; i++)
    {
        // Check if the i-th bit is set
        if ((bitArray & (1 << i)) != 0)
        {
            // Add corresponding character to the result string
            // We assume the letters are 'a' to 'z', so we convert the bit index to a character
            // Check if i is within 0-25 range (for a-z)
            if (i < 26)
            {
                characters.Add((char)('a' + i));
            }
        }
    }
    // Convert the list of characters to a string
    return new string(characters.ToArray());
}

Console.WriteLine(solutions);
Console.WriteLine("done!!!!!😃😃😃😃😃");
Console.WriteLine("Penus kh. Philip!");
Console.WriteLine("All that works, is made by Philip. Everything that don't is akmandas.");