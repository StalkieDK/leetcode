<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

/*
2. Add Two Numbers
You are given two non-empty linked lists representing two non-negative integers. The digits are stored in reverse order, and each of their nodes contains a single digit. Add the two numbers and return the sum as a linked list.
You may assume the two numbers do not contain any leading zero, except the number 0 itself.
*/

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}

ListNode AddTwoNumbers(ListNode l1, ListNode l2)
{
	int rv = l1.val + l2.val;
	var first = new ListNode(rv % 10);
	var current = first;
	
	var a = l1.next;
	var b = l2.next;
	bool hasCarry = rv >= 10;
	while (a != null || b != null)
	{
		int av = a != null ? a.val : 0;
		int bv = b != null ? b.val : 0;
		rv = av + bv + (hasCarry ? 1 : 0);
		current.next = new ListNode(rv % 10);
		current = current.next;
		
		hasCarry = rv >= 10;
		a = a != null ? a.next : null;
		b = b != null ? b.next : null;
	}
	
	if (hasCarry)
	{
		current.next = new ListNode(1);
	}
	
	return first;
}


class ListNode {
     public int val;
     public ListNode next;

	 public ListNode(int val=0, ListNode next=null)
	 {
         this.val = val;
         this.next = next;
     }
	 
	 #region Helpers
	 public static ListNode Create(IEnumerable<int> values)
	 {
	 	var first = new ListNode(values.FirstOrDefault());
		var current = first;
		foreach (int v in values.Skip(1))
		{
			current.next = new ListNode(v);
			current = current.next;
		}
		
		return first;
	 }
	 
	 public override string ToString()
	 {
	 	var values  = new List<int>();
		var current = this;
		while (current != null)
		{
			values.Add(current.val);
			current = current.next;
		}
		
		return $"[{string.Join(',', values)}]";
	 }
	 #endregion
 }



#region private::Tests
[Fact] void Example1() => Assert.Equal("[7,0,8]", AddTwoNumbers(ListNode.Create([2,4,3]), ListNode.Create([5,6,4])).ToString());
[Fact] void Example2() => Assert.Equal("[0]", AddTwoNumbers(ListNode.Create([0]), ListNode.Create([0])).ToString());
[Fact] void Example3() => Assert.Equal("[8,9,9,9,0,0,0,1]", AddTwoNumbers(ListNode.Create([9,9,9,9,9,9,9]), ListNode.Create([9,9,9,9])).ToString());
[Fact] void Fail1() => Assert.Equal("[0,0,0,0,0,0,0,0,0,0,1]", AddTwoNumbers(ListNode.Create([9]), ListNode.Create([1,9,9,9,9,9,9,9,9,9])).ToString());
[Fact] void Fail2() => Assert.Equal("[6,6,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1]", AddTwoNumbers(ListNode.Create([1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1]), ListNode.Create([5,6,4])).ToString());
#endregion
