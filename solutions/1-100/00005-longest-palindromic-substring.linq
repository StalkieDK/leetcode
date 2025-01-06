<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

/*
5. Longest Palindromic Substring
Given a string s, return the longest palindromic substring in s.
*/

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}


public string LongestPalindrome(string s)
{
	string result = s.Substring(0, 1);
	for (int i = 0; i < s.Length - 1 && s.Length - i > result.Length; i++)
	{
		int size = 0;
		for (int j = s.Length - 1; j > i && (size = j - i + 1) > result.Length; j--)
		{
			if (s[i] == s[j])
			{
				for (int k = i, l = j; l >= k; k++, l--)
				{
					if (s[k] != s[l]) break;
					
					if (k == l || k == l - 1)
					{
						result = s.Substring(i, size);
					}
				}
			}
		}
	}

	return result;
}



#region private::Tests
[Fact] void Example1() => Assert.Equal("bab", LongestPalindrome("babad"));
[Fact] void Example2() => Assert.Equal("bb", LongestPalindrome("cbbd"));
[Fact] void Fail1() => Assert.Equal("a", LongestPalindrome("a"));
[Fact] void Fail2() => Assert.Equal("a", LongestPalindrome("ac"));
#endregion