<Query Kind="Statements" />

/*
1. Two Sum
Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
You may assume that each input would have exactly one solution, and you may not use the same element twice.
You can return the answer in any order.
*/


$"[{string.Join(',', TwoSum([2,7,11,15], 9))}]; Expected [0,1]".Dump();
$"[{string.Join(',', TwoSum([3,2,4], 6))}]; Expected [1,2]".Dump();
$"[{string.Join(',', TwoSum([3,3], 6))}]; Expected [0,1]".Dump();
$"[{string.Join(',', TwoSum([1,1,1,1,1,4,1,1,1,1,1,7,1,1,1,1,1], 11))}]; Expected [5,11]".Dump();



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
