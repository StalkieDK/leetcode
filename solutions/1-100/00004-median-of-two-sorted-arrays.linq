<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

/*
4. Median of Two Sorted Arrays
Given two sorted arrays nums1 and nums2 of size m and n respectively, return the median of the two sorted arrays.
The overall run time complexity should be O(log (m+n)).
*/

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}


double FindMedianSortedArrays(int[] nums1, int[] nums2)
{
	int[] merged = new int[nums1.Length + nums2.Length];
	for (int i = 0, i1 = 0, i2 = 0; i < merged.Length; i++)
	{
		if (i1 < nums1.Length && i2 < nums2.Length)
		{
			if (nums1[i1] <= nums2[i2])
			{
				merged[i] = nums1[i1++];
			}
			else
			{
				merged[i] = nums2[i2++];
			}
		}
		else if (i1 < nums1.Length)
		{
			merged[i] = nums1[i1++];
		}
		else
		{
			merged[i] = nums2[i2++];
		}
	}

	int idx = merged.Length / 2;
	if (merged.Length % 2 == 0)
	{
		return (merged[idx - 1] + merged[idx]) / 2d;
	}
	else
	{
		return merged[idx];
	}
}



#region private::Tests
[Fact] void Example1() => Assert.Equal(2.0, FindMedianSortedArrays([1,3], [2]));
[Fact] void Example2() => Assert.Equal(2.5, FindMedianSortedArrays([1,2], [3,4]));
#endregion