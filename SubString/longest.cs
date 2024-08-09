namespace SubString;
public static class longest
{
    public static string longestSubString(string input)
    {
        string longestSubstring = "";
        List<char> currentSubString = new List<char>();

        foreach (char c in input)
        {
            if (currentSubString.Count != 0)
            {
                foreach (char c2 in currentSubString)
                {
                    if (c2 == c)
                    {
                        string temp = new string(currentSubString.ToArray());
                        if (temp.Length > longestSubstring.Length)
                        {
                            longestSubstring = temp;
                        }
                        currentSubString.Clear();
                        break;
                    }
                }
                currentSubString.Add(c);
            }
            else
            {
                currentSubString.Add(c);
            }
        }
        string final = new string(currentSubString.ToArray());
        if (final.Length > longestSubstring.Length)
        {
            longestSubstring = final;
        }
        return longestSubstring;
    }

    public static int longestSubStringLength(string input)
    {
        int indexer = 0;
        List<char> fullString = new List<char>(input);
        List<char> substring = new List<char>();
        string longestSubString = "";
        while (indexer <= (fullString.Count - 1))
        {
            if (ListContainsThisChar(substring, fullString[indexer]))
            {
                if (isCurrentLongerThanStored(longestSubString, substring))
                {
                    longestSubString = new string(substring.ToArray());
                }
                try
                {
                    indexer = transitionIndex(indexer, substring.Count, indexOfRepeat(substring, fullString[indexer]));
                }
                catch (Exception e)
                {
                    Console.Error.WriteLine(e);
                    Environment.Exit(1);
                }
                substring.Clear();
            }
            else
            {
                substring.Add(fullString[indexer]);
                ++indexer;
            }
        }
        if (isCurrentLongerThanStored(longestSubString, substring))
        {
            longestSubString = new string(substring.ToArray());
        }
        return longestSubString.Length;
    }

    private static int transitionIndex(int indexer, int count, int indexOfRepeat)
    {
        return indexer - (count - (indexOfRepeat + 1));
    }

    private static int indexOfRepeat(List<char> substring, char target)
    {
        var counter = 0;
        foreach (char c in substring)
        {
            if (c == target)
            {
                return counter;
            }
            counter++;
        }
        throw new ArgumentOutOfRangeException();
    }

    private static bool isCurrentLongerThanStored(string longestSubString, List<char> substring)
    {
        if (longestSubString.Length <= substring.Count)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private static bool ListContainsThisChar(List<char> substring, char v)
    {
        foreach (char c in substring)
        {
            if (c == v)
            {
                return true;
            }
        }
        return false;
    }
}
