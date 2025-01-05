<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

/*
3. Longest Substring Without Repeating Characters
Given a string s, find the length of the longest substring without repeating characters.
*/

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}

int LengthOfLongestSubstring(string s)
{
	int largest = 0;
	
	var lookup = new Dictionary<char, int>();
	int start = 0;
	int end = 0;
	while (end < s.Length)
	{
		while (end < s.Length && !lookup.ContainsKey(s[end]))
		{
			lookup.Add(s[end], end);
			end++;
		}
		
		int len = end - start;
		if (len > largest)
		{
			largest = len;
		}
		
		// Move sliding window, if not already at the end
		if (end < s.Length)
		{
			int newStart = lookup[s[end]] + 1;
			for (int i = start; i < newStart; i++)
			{
				lookup.Remove(s[i]);
			}
			start = newStart;
		}
	}
	
	return largest;
}



#region private::Tests
[Fact] void Example1() => Assert.Equal(LengthOfLongestSubstring("abcabcbb"), 3);
[Fact] void Example2() => Assert.Equal(LengthOfLongestSubstring("bbbbb"), 1);
[Fact] void Example3() => Assert.Equal(LengthOfLongestSubstring("pwwkew"), 3);
#endregion