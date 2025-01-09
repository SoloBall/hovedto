// koden virker, recursive samt bit masking. Tager dog lidt tid
using System.Diagnostics;
using System.Threading.Channels;

Console.WriteLine("me starté");
Stopwatch stopwatch = Stopwatch.StartNew();
StreamReader reader = new("Resources\\words.txt"); // ugly... change
Dictionary<string, int> words = new();
while (true)
{
    string currentLine = reader.ReadLine() ?? "";      // wtf ---> change
    if (currentLine != "")
    {
        if (currentLine.Length == 5 && currentLine.Distinct().Count() == 5)
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

List<int>[] wordsList = new List<int>[26];
for (int i = 0; i < 26; i++)
{
    wordsList[i] = new();
}
foreach (string word in words.Keys)
{
    wordsList[LowestCharacter(word)].Add(words[word]);
}
int solutions = 0;
MatchWords(new());
stopwatch.Stop();
Console.WriteLine(stopwatch.ToString());

void MatchWords(List<int> usedWords, int word = 0, int wordIndex = 0, int alphabetIndex = 0) // Kunne være bedere! mate den virker jo ikke engang
{
    for (int k = alphabetIndex; k < 26; k++) 
    {
        if (usedWords.Count == 5)
        {
            Console.WriteLine("did");
            solutions++;
            return;
        }
        int wordCount = wordsList[k].Count();
        for (int i = wordIndex; i < wordCount; i++)
        {
            int tmpWord = wordsList[k][i];
            if ((tmpWord & word) == 0)
            {
                List<int> tmpList = new(usedWords);
                tmpList.Add(tmpWord);
                MatchWords(tmpList, word | tmpWord, 0, k + 1);
            }
            /*if (i == wordCount - 1)
            {
                alphabetIndex++;
                wordCount = wordsList[alphabetIndex].Count();
                i = 0;
            }*/
        }
    }
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
int LowestCharacter(string line)
{
    int result = 26;
    foreach (char c in line)
    {
        if ((int)c - 'a' < result)
        {
            result = (int)c - 'a';
        }
    }
    return result;
}

Console.WriteLine(solutions);
Console.WriteLine("done!!!!!😃😃😃😃😃");
Console.WriteLine("Penus kh. Philip!");
Console.WriteLine("All that works, is made by Philip. Everything that don't is akmandas.");