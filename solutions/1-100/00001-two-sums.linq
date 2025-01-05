<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

/*
1. Two Sum
Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
You may assume that each input would have exactly one solution, and you may not use the same element twice.
You can return the answer in any order.
*/

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}


int[] TwoSum(int[] nums, int target)
{
	var lookup = new Dictionary<int, int>();

	for (int i = 0; i < nums.Length; i++)
	{
		if (lookup.TryGetValue(nums[i], out int pos))
		{
			return [pos, i];
		}
	
		int remaining = target - nums[i];
		lookup[remaining] = i;
	}
	
	return [0,0];
}


#region private::Tests
[Fact] void Example1() => Assert.True(TwoSum([2,7,11,15], 9).SequenceEqual([0,1]));
[Fact] void Example2() => Assert.True(TwoSum([3,2,4], 6).SequenceEqual([1,2]));
[Fact] void Example3() => Assert.True(TwoSum([3,3], 6).SequenceEqual([0,1]));
[Fact] void Fail1() => Assert.True(TwoSum([1,1,1,1,1,4,1,1,1,1,1,7,1,1,1,1,1], 11).SequenceEqual([5,11]));
#endregion
