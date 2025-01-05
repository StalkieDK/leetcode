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
	int totalSize = nums1.Length + nums2.Length;
	int idx = totalSize / 2;
	
	int a = 0, b = 0;
	int idx1 = 0, idx2 = 0;
	while ((idx1 + idx2) <= idx)
	{
		a = b;
		if (idx1 < nums1.Length && idx2 < nums2.Length)
		{
			if (nums1[idx1] <= nums2[idx2])
			{
				b = nums1[idx1++];
			}
			else
			{
				b = nums2[idx2++];
			}
		}
		else if (idx1 < nums1.Length)
		{
			b = nums1[idx1++];
		}
		else
		{
			b = nums2[idx2++];
		}
	}
	
	return (totalSize % 2 == 0) ? (a + b) / 2d : b;
}



#region private::Tests
[Fact] void Example1() => Assert.Equal(2.0, FindMedianSortedArrays([1,3], [2]));
[Fact] void Example2() => Assert.Equal(2.5, FindMedianSortedArrays([1,2], [3,4]));
#endregion