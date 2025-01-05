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
	
	bool[] lookup = new bool[127];
	int start = 0;
	int end = 0;
	while (end < s.Length && largest < s.Length - start)
	{
		while (end < s.Length && !lookup[(int)s[end]])
		{
			lookup[(int)s[end]] = true;
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
			while (s[start] != s[end])
			{
				lookup[(int)s[start]] = false;
				start++;
			}
			
			lookup[(int)s[start]] = false;
			start++;
		}
	}
	
	return largest;
}



#region private::Tests
[Fact] void Example1() => Assert.Equal(LengthOfLongestSubstring("abcabcbb"), 3);
[Fact] void Example2() => Assert.Equal(LengthOfLongestSubstring("bbbbb"), 1);
[Fact] void Example3() => Assert.Equal(LengthOfLongestSubstring("pwwkew"), 3);
#endregion
