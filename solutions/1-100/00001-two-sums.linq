<Query Kind="Statements" />

/*
Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
You may assume that each input would have exactly one solution, and you may not use the same element twice.
You can return the answer in any order.
*/


$"[{string.Join(',', TwoSum([2,7,11,15], 9))}]; Expected [0,1]".Dump();
$"[{string.Join(',', TwoSum([3,2,4], 6))}]; Expected [1,2]".Dump();
$"[{string.Join(',', TwoSum([3,3], 6))}]; Expected [0,1]".Dump();


int[] TwoSum(int[] nums, int target)
{
	for (int i = 0; i < nums.Length - 1; i++)
	{
		for (int j = i + 1; j < nums.Length; j++)
		{
			if (nums[i] + nums[j] == target)
			{
				return [i,j];
			}
		}
	}
	
	return [0,0];
}