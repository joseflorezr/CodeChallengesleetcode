namespace ChallengeImplementation.Model
{
		internal class ListNode(int val = 0,ListNode? next = null)
		{
				public int val = val;
				public ListNode? next = next;

				public override string ToString()
				{
						string returnString = next != null ? $"{val},{next}" : $"{val}";
						return returnString;
				}
		}
}
